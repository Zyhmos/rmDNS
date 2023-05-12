using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shop.Data
{
    [Serializable]
    internal class Order
    {
        public Person? Person { get; set; }
        public int Amount { get; set; }
        public DateTime? Date { get; set; }

        public Person? GetPerson()
        {
            return Person;
        }
        public void SetPerson(Person? value)
        {
            Person = value;
        }

        public int GetAmount()
        {
            return Amount;
        }
        public void SetAmount(int value)
        {
            Amount = value;
        }


        public DateTime? GetDate()
        {
            return Date;
        }
        public void SetDate(DateTime? value)
        {
            Date = value;
        }

        public double TotalSum()
        {
            return Math.Round(Amount * 98.99 - (Amount * 98.99 * Discounter() / 100), 2);
        }

        public int Discounter()
        {
            int disc = 0;
            if (Amount >= 50) { disc = 15; }
            else if (Amount >= 10) { disc = 5; }
            return disc;
        }
    }
}
