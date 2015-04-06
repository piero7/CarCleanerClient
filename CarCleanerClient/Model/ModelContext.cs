using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCleanerClient.Model
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class ModelContext : DbContext
    {

        public ModelContext() : base("MyContext") { }

        public DbSet<Model.Order> OrderSet { get; set; }

        public DbSet<Model.OrderType> OrderTypeSet { get; set; }

        public DbSet<Model.Community> CommunitySet { get; set; }

        public DbSet<Model.User> UserSet { get; set; }

        public DbSet<Model.WechatUser> WechatUserSet { get; set; }

        public DbSet<Model.CommunityAdministrator> CommunityAdministratorSet { get; set; }
    }
}
