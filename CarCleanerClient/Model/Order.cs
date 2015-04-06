using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User OrderUser { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? OrderTypeId { get; set; }

        [ForeignKey("OrderTypeId")]
        public virtual OrderType OrderType { get; set; }


    }
    public class OrderType
    {
        [Key]
        public int OrderTypeId { get; set; }

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
