using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace WebAPI.Data
{
    internal class database
    {
        public async Task SaveOrderAsync(Order order)
        {
            List<Order> _data = new List<Order>();
            _data.Add(order);

            await using FileStream createStream = File.Create(@"database.json");
            await JsonSerializer.SerializeAsync(createStream, _data);
        }
    }
}
