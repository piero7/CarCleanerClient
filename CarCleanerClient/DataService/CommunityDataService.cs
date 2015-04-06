using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    class CommunityDataService : IDataService
    {
        public void GetData(Action<List<Community>, Exception> callback)
        {
            List<Community> communityList = new List<Community>();
            #region Add test data.
            CommunityAdministrator admin = new CommunityAdministrator
            {
                IdCard = "310110100110101101",
                Name = "Piero",
                Phone = "13698745612",
                PicPath = "http://img1.imgtn.bdimg.com/it/u=94582967,1026786512&fm=21&gp=0.jpg",
            };

            communityList.AddRange(
                new List<Community>
                {
                    new Community
                    {
                        Address="1226-5 Changle Rd. Shanghai",
                        ImgPath ="http://img3.imgtn.bdimg.com/it/u=1139107028,134589169&fm=21&gp=0.jpg",
                        Name="Shanghai Jian Smart",
                        QRCodePath = "http://img4.cache.netease.com/game/2014/6/27/20140627172239307b9.png",
                        UserCount = 100,
                        Administrator = admin,
                    },
                    new Community
                    {
                        Address="1226-5 Changle Rd. Shanghai",
                        ImgPath ="http://img3.imgtn.bdimg.com/it/u=1139107028,134589169&fm=21&gp=0.jpg",
                        Name="Shanghai Anji Smart",
                        QRCodePath = "http://img4.cache.netease.com/game/2014/6/27/20140627172239307b9.png",
                        UserCount = 200,
                        Administrator = admin,
                    },
                });

            #endregion
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}
