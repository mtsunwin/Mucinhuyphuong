using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.Entity;
using System.Linq;
using System.Web;

namespace Website_14042017.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBWebsite14042017Context : DbContext
    {
        public DBWebsite14042017Context() : base("DBWebsite14042017Connection")
        {
        }
        //1
        public DbSet<MenuLevel0> MenuLevel0s { get; set; }
        //2
        public DbSet<MenuLevel1> MenuLevel1s { get; set; }
        //3
        public DbSet<MenuLevel2> MenuLevel2s { get; set; }
        //4
        public DbSet<Image> Images { get; set; }
        //5
        public DbSet<News> Newses { get; set; }
        //6
        public DbSet<WebsiteInfor> WebsiteInfors { get; set; }
        //7
        public DbSet<ProductType> ProductTypes { get; set; }
        //8
        public DbSet<Product> Products { get; set; }
        //9
        public DbSet<Account> Accounts { get; set; }
    }
}