using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class WebsiteInforDAL
    {

        public void Add(WebsiteInfor info)
        {
            try
            {
                if (info != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        db.WebsiteInfors.Add(info);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<WebsiteInfor> GetAll()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var infos = db.WebsiteInfors.ToList();
                    return infos;
                }
            }
            catch
            {
                return null;
            }
        }
        public void Delete(string id)
        {
            try
            {
                if (id != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var info = db.WebsiteInfors.Where(x => x.CompanyName == id).FirstOrDefault();
                        if (info != null)
                        {
                            db.WebsiteInfors.Remove(info);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public void Update(WebsiteInfor info)
        {
            try
            {
                if (info != null)
                {
                    using (var db = new DBWebsite14042017Context())
                    {
                        var infos = db.WebsiteInfors.ToList();
                        var _info = infos.Where(x => x.CompanyName == info.CompanyName).FirstOrDefault();
                        if (_info != null)
                        {
                            _info.Address = info.Address;
                            _info.DislayNameWeb = info.DislayNameWeb;
                            _info.Email = info.Email;
                            _info.Hotline = info.Hotline;
                            _info.InforOther = info.InforOther;
                            _info.LinkWeb = info.LinkWeb;
                            db.WebsiteInfors.AddOrUpdate(_info);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public WebsiteInfor GetById(string id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var infos = db.WebsiteInfors.ToList();
                    var info = infos.Where(x => x.CompanyName == id).FirstOrDefault();
                    return info;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}