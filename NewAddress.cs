using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace newAddressExample
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            string responseMessage;
            responseMessage = await GetNewAddress();
            Console.WriteLine(responseMessage);
        }

        static async Task<string> GetNewAddress()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.blockonomics.co/api/new_address"),
                Headers = { 
                    { HttpRequestHeader.Authorization.ToString(), "Bearer PlaceYourAPIKeyHere" }
                }
            };
            
            try
            {
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
