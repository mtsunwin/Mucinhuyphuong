using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class ProductTypeDAL
    {
        public void Add(ProductType prType)
        {
            try
            {
                if (prType != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        prType.Name = prType.Name.Trim();
                        db.ProductTypes.Add(prType);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {

            }
        }
        public void Update(ProductType prType)
        {
            try
            {
                if (prType != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var pr = db.ProductTypes.Where(x => x.Name == prType.Name).FirstOrDefault();
                        if (pr != null)
                        {
                            pr.Descrip = prType.Descrip;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public void Delete(string prTypeName)
        {
            try
            {
                if (prTypeName != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var pr = db.ProductTypes.Where(x => x.Name == prTypeName).FirstOrDefault();
                        if (pr != null)
                        {
                            db.ProductTypes.Remove(pr);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<ProductType> GetAll()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var prTypes = db.ProductTypes.ToList();
                    return prTypes;
                }
            }
            catch
            {
                return null;
            }
        }
        public ProductType GetByName(string name)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var type = db.ProductTypes.Where(x => x.Name == name).FirstOrDefault();
                    return type;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}