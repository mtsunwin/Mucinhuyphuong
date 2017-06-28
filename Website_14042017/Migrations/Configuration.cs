namespace Website_14042017.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Website_14042017.Models.DBWebsite14042017Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Website_14042017.Models.DBWebsite14042017Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            Account acc = new Account();
            acc.Name = "huyphuong";
            acc.Password = "21232f297a57a5a743894a0e4a801fc3";
            acc.Email = "huyphuong@gmail.com";
            context.Accounts.AddOrUpdate(acc);
            context.SaveChanges();
        }
    }
}
