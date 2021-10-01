using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace indacoin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> Params = new Dictionary<string, string>()
            {
                {"apiKey", "" }, // Нужно регистрироваться?
                {"secretKey", "" }, 
                // Default BTC
            };

            var answer = GetResponse("https://api.bithumb.com/info/balance", Params).Result;
            Console.WriteLine(answer.ToString());
            Console.ReadLine();
        }

        static async Task<HttpResponseMessage> GetResponse(string address, Dictionary<string, string> Params)
        {
            var client = new HttpClient();
            try
            {
                Uri uri = new Uri(address);
                var content = new FormUrlEncodedContent(Params);
                return await client.PostAsync(address, content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! " + e.ToString());
                Console.ReadLine();
            }
            finally
            {
                client.Dispose();
            }
            return null;
        }
    }
}
