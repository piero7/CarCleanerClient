using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    class Order
    {
        public string OrderNumber { get; set; }

        public User OrderUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public OrderType OrderType { get; set; }


    }
    class OrderType
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Times { get; set; }

        public string Remarks { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
