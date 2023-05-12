using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Shop.Data
{
    internal class API
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Order> PostOrder(string url, Order order)
        {
            try
            {
                var requestJson = JsonSerializer.Serialize<Order>(order);
                var request = new HttpRequestMessage(HttpMethod.Get, url + "?newOrder=" + requestJson);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public async Task<string> GetOrder(string url, int id)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7205/api/Shop/-1");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
