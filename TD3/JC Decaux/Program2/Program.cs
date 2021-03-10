using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = @"D:\travail\SOC\eiin839\TD3\JC Decaux\Program1\bin\Debug\netcoreapp3.1\Program1.exe";
                start.Arguments = "";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        string[] names = result.Split('\n');
                        // Call asynchronous network methods in a try/catch block to handle exceptions.
                        try
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contrat_name=" + names[i] + "&apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");
                                response.EnsureSuccessStatusCode();
                                string responseBody = await response.Content.ReadAsStringAsync();
                                // Above three lines can be replaced with new helper method below
                                //string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v1/stations?contrat_name=" + names[i] + "&apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");

                                List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

                                Console.WriteLine("#############################################################################################");
                                Console.WriteLine("Ville : " + names[i]);
                                Console.WriteLine("#############################################################################################");

                                for (int j = 0; j < stations.Count; j++)
                                {
                                    Console.WriteLine("Station name : " + stations[j].name);
                                    Console.WriteLine("Station number : " + stations[j].number);
                                }
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                    }
                }
            } else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contrat_name=" + args[i] + "&apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    //string responseBody = await client.GetStringAsync("https://api.jcdecaux.com/vls/v1/stations?contrat_name=" + names[i] + "&apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");

                    List<Station> stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

                    Console.WriteLine("#############################################################################################");
                    Console.WriteLine("Ville : " + args[i]);
                    Console.WriteLine("#############################################################################################");

                    for (int j = 0; j < stations.Count; j++)
                    {
                        Console.WriteLine("Station name : " + stations[j].name);
                        Console.WriteLine("Station number : " + stations[j].number);
                    }
                }
            }
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
