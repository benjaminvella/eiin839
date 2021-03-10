using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/contracts?apiKey=da61842624f2e695d7ab23f406c3fa895df7793c");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                List<Contract> contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);

                for (int i = 0; i < contracts.Count; i++)
                {
                    Console.WriteLine(contracts[i].name);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }

    public class Contract
    {
        public string name { get; set; }
        public string commercial_name { get; set; }
        public string[] cities { get; set; }
        public string country_code { get; set; }
    }
}
