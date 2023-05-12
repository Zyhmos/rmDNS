using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    internal interface IOrder
    {
        public Person? GetPerson();
        public void SetPerson(Person? value);

        public int GetAmount();
        public void SetAmount(int value);

        public DateTime? GetDate();
        public void SetDate(DateTime? value);
    }
}
