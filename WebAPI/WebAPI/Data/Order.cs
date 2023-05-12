using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Data
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
    }
}
