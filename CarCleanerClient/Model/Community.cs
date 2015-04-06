using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    /// <summary>
    /// 小区
    /// </summary>
    public class Community
    {
        [Key]
        public int CommunityId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ImgPath { get; set; }

        public string QRCodePath { get; set; }

        public int UserCount { get; set; }

        public int? CommunityAdministratorId { get; set; }

        [ForeignKey("CommunityAdministratorId")]
        public virtual CommunityAdministrator Administrator { get; set; }


    }


    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int? WechatUserId { get; set; }

        [ForeignKey("WechatUserId")]
        public virtual WechatUser WeChatAccount { get; set; }

        public string CarInfo { get; set; }

        public string CarLocation { get; set; }

        public string CarNumber { get; set; }

        public int? CommunityId { get; set; }

        [ForeignKey("CommunityId")]
        public virtual Community Community { get; set; }

    }

    public class WechatUser
    {
        [Key]
        public int WechatUserId { get; set; }

        public string OpenId { get; set; }

        public int? CardId { get; set; }

        public string NickName { get; set; }

        public bool IsSubscribe { get; set; }

        public Sex Sex { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Language { get; set; }

        public DateTime? SubscribeTime { get; set; }

        public string HeadImgUrl { get; set; }

    }

    public enum Sex
    {
        男 = 1,
        女 = 2,
        未知 = 0,
    }

    public class CommunityAdministrator
    {
        [Key]
        public int CommunityAdministratorId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string IdCard { get; set; }

        public string PicPath { get; set; }

    }

    class Location
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Y { get; set; }

        //计算距离
        private const double EARTH_RADIUS = 6378.137;//地球半径
        //private static double rad(double d)
        //{
        //    return d * Math.PI / 180.0;
        //}

        public static double GetDistance(Location a, Location b)
        {
            double radLat1 = (a.X * Math.PI / 180.0);
            double radLat2 = (b.X * Math.PI / 180.0);
            double x = radLat1 - radLat2;
            double y = (a.Y - b.Y) * Math.PI / 180.0;

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(x / 2), 2) +
                       Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(y / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;

        }
    }
}
