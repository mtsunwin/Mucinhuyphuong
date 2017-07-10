//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Website_14042017.Models;

//namespace Website_14042017.DAL
//{
//    public class InfoDAL
//    {
//        public void Add(InfoWeb info)
//        {
//            try
//            {
//                //if (info != null)
//                //{
//                //    using (var db = new DBWebsite14042017Context())
//                //    {
//                //        db.Infos.Add(info);
//                //        db.SaveChanges();
//                //    }
//                //}
//            }
//            catch
//            {
//            }
//        }
//        public IEnumerable<InfoWeb> GetAll()
//        {
//            try
//            {
//                //using (var db = new DBWebsite14042017Context())
//                //{
//                //    var infos = db.Infos.ToList();
//                //    return infos;
//                //}
//                return null;
//            }
//            catch
//            {
//                return null;
//            }
//        }
//        public void Delete(int id)
//        {
//            try
//            {
//                //using (var db = new DBWebsite14042017Context())
//                //{
//                //    var info = db.Infos.Where(x => x.Id == id).FirstOrDefault();
//                //    if (info != null)
//                //    {
//                //        db.WebsiteInfors.Remove(info);
//                //        db.SaveChanges();
//                //    }
//                //}
//            }
//            catch
//            {
//            }
//        }
//        public void Update(WebsiteInfor info)
//        {
//            try
//            {
//                if (info != null)
//                {
//                    using (var db = new DBWebsite14042017Context())
//                    {
//                        var infos = db.WebsiteInfors.ToList();
//                        var _info = infos.Where(x => x.CompanyName == info.CompanyName).FirstOrDefault();
//                        if (_info != null)
//                        {
//                            _info.Address = info.Address;
//                            _info.DislayNameWeb = info.DislayNameWeb;
//                            _info.Email = info.Email;
//                            _info.Hotline = info.Hotline;
//                            _info.InforOther = info.InforOther;
//                            _info.LinkWeb = info.LinkWeb;
//                            //db.WebsiteInfors.AddOrUpdate(_info);
//                            db.SaveChanges();
//                        }
//                    }
//                }
//            }
//            catch
//            {

//            }
//        }
//        public WebsiteInfor GetById(string id)
//        {
//            try
//            {
//                using (var db = new DBWebsite14042017Context())
//                {
//                    var infos = db.WebsiteInfors.ToList();
//                    var info = infos.Where(x => x.CompanyName == id).FirstOrDefault();
//                    return info;
//                }
//            }
//            catch
//            {
//                return null;
//            }
//        }
//    }
//}