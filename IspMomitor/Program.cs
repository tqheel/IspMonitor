using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IspMomitor
{
    class Program
    {
        static async void MainAsync(string[] args)
        {
            Console.WriteLine("Hello World!");
            var url = "https://google.com";
            Console.WriteLine($"Sending GET to {url}...");
            await MakeRequest(url).ConfigureAwait(false);
        }

        private static async Task MakeRequest(string url)
        {
            var httpClient = new HttpClient();
            var res = new HttpResponseMessage();
            try
            {
                
                res = await httpClient.GetAsync(url).ConfigureAwait(false);
                await WriteSuccess(res).ConfigureAwait(false);                
            }
            catch (Exception ex)
            {
                await WriteFailure(ex.Message).ConfigureAwait(false);
                WriteToConsole();
            }
            
            WriteToConsole(res);
            
        }

        private static Task WriteFailure(string message)
        {
            throw new NotImplementedException();
        }

        private static void WriteToConsole(HttpResponseMessage res)
        {
            Console.WriteLine($"The response was: {res.ToString()}.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task WriteSuccess(HttpResponseMessage message)
        {
            const string filePath = @"C:\IspLog\log.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Append);
            using (var logFile = new StreamWriter(fileStream))
            {
                var i = 0;
                while (i < 10)
                {
                    i++;
                    await logFile.WriteAsync($"This is iteration {i}:\n{message}\n");
                    
                }
            }
        }
    }
}