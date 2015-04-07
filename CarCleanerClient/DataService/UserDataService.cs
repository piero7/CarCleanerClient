using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    class UserDataService
    {
        public List<User> UserList = new List<User>();
        public List<User> GetData(int skip, int take, Action<List<User>, Exception> callback)
        {
            ModelContext db = new ModelContext();
            this.UserList = db.UserSet.Include("WeChatAccount").OrderBy(u => u.UserId).Skip(skip).Take(take).Where(u => true).ToList();

            //add test data
            AddTestData();

            if (callback != null)
            {
                callback(UserList, null);
            }

            return this.UserList;
        }

        private void AddTestData()
        {
            WechatUser wcUserInfo = new WechatUser
            {
                City = "ShangHai",
                Country = "China",
                HeadImgUrl = "http://img1.imgtn.bdimg.com/it/u=1406315656,3734593399&fm=21&gp=0.jpg",
                IsSubscribe = true,
                Language = "Chinese",
                NickName = "CarCleaner",
                OpenId = "OpenId",
                Province = "Shanghai",
                Sex = Sex.男,
                SubscribeTime = DateTime.Now
            };

            UserList.AddRange(
            new List<User>
            {
                new User
                {
                    Name ="Piero",
                    PhoneNumber="13698745613",
                    WeChatAccount=wcUserInfo,
                },
                new User
                {
                    Name = "Chen",
                    PhoneNumber="18946523198",
                    WeChatAccount = wcUserInfo,
                }
            });
        }
    }
}
