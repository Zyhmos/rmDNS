using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Data
{
    [Serializable]
    internal class Person : IPerson
    {
        public string? Address { get; set; }
        public string? Name { get; set; }

        public string? GetAddress()
        {
            return Address;
        }
        public void SetAddress(string value)
        {
            Address = value;
        }

        public string? GetName()
        {
            return Name;
        }
        public void SetName(string value)
        {
            Name = value;
        }
    }
}
