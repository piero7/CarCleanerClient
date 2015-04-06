using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    class OrderDataService
    {
        public List<Order> OrderList { get; set; }

        public List<Order> GetData(User user, Action<List<Order>, Exception> callback)
        {
            var db = new ModelContext();
            this.OrderList = new List<Order>();

            if (user == null)
            {
                this.OrderList = null;
                return null;
            }
            this.OrderList = db.OrderSet.Where(o => o.UserId == user.UserId).ToList();

            if (callback != null)
            {
                callback(this.OrderList, null);
            }
            return this.OrderList;
        }
    }
}
