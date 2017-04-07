using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IspMomitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var url = "https://google.com";
            var res =  MakeRequest(url).Result;
            Console.WriteLine($"Sending GET to {url}...");
            Console.WriteLine($"The response was: {res.ToString()}.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task<HttpResponseMessage> MakeRequest(string url)
        {
            var httpClient = new HttpClient();
            return await httpClient.GetAsync(url).ConfigureAwait(false);

        }
    }
}