namespace Exo3Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            HttpClient client = new HttpClient();
            string URI = "http://localhost:8080/Incr";
            string number;

            while (true)
            {
                Console.WriteLine("Please write a number so we can add 1 to it ...");
                number = Console.ReadLine();
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URI+ "?intParam="+number);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}