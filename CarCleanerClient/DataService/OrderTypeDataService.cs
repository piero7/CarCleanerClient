using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    class OrderTypeDataService
    {
        public List<OrderType> OrderTypeList { get; set; }

        public List<OrderType> GetData(Action<DataItem, Exception> callback)
        {
            var db = new ModelContext();

            this.OrderTypeList = db.OrderTypeSet.Where(ot => true).ToList();
            AddTestData();
            return this.OrderTypeList;
        }

        private void AddTestData()
        {
            this.OrderTypeList.Add(new OrderType
            {
                Name = "测试天天洗",
                Price = 99.00,
                Remarks = "测试使用订单类型",
                Times = 30
            });
        }
    }
}
