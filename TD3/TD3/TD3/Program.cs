// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using TD3.models;
using GeoCoordinatePortable;

namespace TD3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        
        private static readonly string apiKey = "a60e0bcccff39ff503bce3936ad041fbcb037642";

        static async Task Main(string[] args)
        {
            Program program = new Program();
            
            List<Contract> contracts = await program.GetAllContracts();
            contracts.ForEach(c => Console.WriteLine(c.ToString()));
            
            List<Station> stations = await program.GetStations(contracts[0].name);
            stations.ForEach(c => Console.WriteLine(c.ToString()));
            
            Station closestStation = await program.GetClosestStation(new Position())
        }
        
        private async Task<List<Contract>> GetAllContracts()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/contracts" + "?apiKey=" + apiKey);
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Contract>>(responseAsString);
        }
        
        private async Task<List<Station>> GetStations(string contract)
        {
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + apiKey);
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Station>>(responseAsString);
        }

        private async Task<Station> GetClosestStation(Position position, Contract contract)
        {
            var stations = await GetStations(contract.name);
            if (stations.Count == 0) return null;
            
            var nearest = stations.Select(x => new GeoCoordinate(x.position.lat, x.position.lng))
                .OrderBy(x => x.GetDistanceTo(new GeoCoordinate(position.lat, position.lng)))
                .First();
            
            return stations.FirstOrDefault(s =>
                new GeoCoordinate(s.position.lat, s.position.lng).Equals(nearest));
        }

    }
    
}