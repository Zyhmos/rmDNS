using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebAPI.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.IO;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ShopController>
        [HttpGet]
        public IEnumerable<string> Get(string newOrder)
        {
            try
            {
                if (newOrder != null)
                {
                    string path = @"database.json";
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine("," + newOrder);
                        tw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new string[] { ":c" };
        }

        // GET api/<ShopController>/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            string path = @"database.json";
            var select = "";
            var counter = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (id == -1 || id == counter)
                    {
                        select += line + "";
                    }
                    counter++;
                }
                sr.Close();
            }
            return new string[] { select };
        }
    }
}
