using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class ProductDAL
    {
        public void Add(Product pro)
        {
            try
            {
                if (pro != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        db.Products.Add(pro);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void Delete(string name)
        {
            try
            {
                if (name != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var pro = db.Products.Where(x => x.Name == name).FirstOrDefault();
                        if (pro != null)
                        {
                            db.Products.Remove(pro);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public void Update(Product pro)
        {
            try
            {
                if (pro != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var pros = db.Products.ToList();
                        var pr = pros.Where(x => x.Name == pro.Name).FirstOrDefault();
                        if (pr != null)
                        {
                            pr.ProductType = pro.ProductType;
                            pr.Country = pro.Country;
                            pr.Manufacturer = pro.Manufacturer;
                            pr.Price = pro.Price;
                            pr.Descrip = pro.Descrip;
                            pr.Image = pro.Image;
                            db.Products.AddOrUpdate(pr);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public IEnumerable<Product> GetAll()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var pros = db.Products.ToList();
                    return pros;
                }
            }
            catch
            {
                return null;
            }
        }
        public Product GetByName(string name)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var pros = db.Products.ToList();
                    var pro = pros.Where(x => x.Name == name).FirstOrDefault();
                    return pro;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Product> GetByType(string nameType)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var pros = db.Products.ToList();
                    var pro = pros.Where(x => x.ProductType == nameType).ToList();
                    return pro;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Product> GetTop(int top)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var prs = db.Products.Take(top).OrderBy(x => x.Name).ToList();
                    return prs;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}