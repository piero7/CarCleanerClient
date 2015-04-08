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
            this.OrderList = db.OrderSet.Include("OrderType").Where(o => o.UserId == user.UserId).ToList();
            AddTestData();

            if (callback != null)
            {
                callback(this.OrderList, null);
            }
            return this.OrderList;
        }

        public List<Order> GetData(OrderType type, Action<List<Order>, Exception> callback)
        {
            var db = new ModelContext();
            if (type == null)
            {
                this.OrderList = null;
                return null;
            }

            this.OrderList = new List<Order>(db.OrderSet.Where(o => o.OrderTypeId == type.OrderTypeId));
            AddTestData();
            return this.OrderList;
        }

        private void AddTestData()
        {
            this.OrderList.Add(new Order
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                OrderNumber = "t201504070001",
                Remarks = "测试使用记录，由构造方法添加。",
                OrderType = new OrderType
                {
                    Name = "测试订单类型",
                    Price = 98.00,
                    Times = 30,
                    Remarks = "测试使用订单类型。"
                }
            });
        }
    }
}
