using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    internal interface IPerson
    {
        public string? GetAddress();
        public void SetAddress(string value);

        public string? GetName();
        public void SetName(string value);
    }
}
