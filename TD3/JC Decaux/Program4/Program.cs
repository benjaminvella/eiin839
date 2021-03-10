using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Program4
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + args[0] + "&apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            GeoCoordinate positionDebut = new GeoCoordinate();

            Station station = JsonSerializer.Deserialize<Station>(responseBody);

            Console.WriteLine(station.name);
            Console.WriteLine(station.number);
            Console.WriteLine(station.contract_name);
            Console.WriteLine(station.address);
        }
    }

    public class Station
    {
        public long number { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public Boolean banking { get; set; }
        public Boolean bonus { get; set; }
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
        public string status { get; set; }
    }

    public class Position
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
