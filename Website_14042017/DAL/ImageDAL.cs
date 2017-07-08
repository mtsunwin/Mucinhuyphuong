using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_14042017.Models;
using System.IO;

namespace Website_14042017.DAL
{
    public class ImageDAL
    {
        string root = "";
        string rootBanner = "";
        public ImageDAL()
        {
            root = HttpContext.Current.Server.MapPath("/Areas/Admin/Images/");
            rootBanner = HttpContext.Current.Server.MapPath("/Areas/Admin/Banners/");
        }
        public DirectoryInfo[] GetDirectoryInfo(string path)
        {
            try
            {
                string _path = root + path;
                DirectoryInfo dirInfo = new DirectoryInfo(_path);
                return dirInfo.GetDirectories();
            }
            catch
            {
                return null;
            }
        }
        public DirectoryInfo[] GetDirectoryInfo()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(root);
                return dirInfo.GetDirectories();
            }
            catch
            {
                return null;
            }
        }
        public FileInfo[] GetFileInfor(string path)
        {
            try
            {
                string _path = root + path;
                DirectoryInfo _dirInfor = new DirectoryInfo(_path);
                return _dirInfor.GetFiles();
            }
            catch
            {
                return null;
            }
        }

        public void Create(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            using (var db = new DBWebsite14042017Context())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
        }
        public IEnumerable<Image> GetAllBanner()
        {
            using (var db = new DBWebsite14042017Context())
            {
                var images = db.Images.ToList();
                return images.Where(x => x.Type == "banner" || x.Type == "slider");
            }
        }
        public void Delete(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("name");
            }

            using (var db = new DBWebsite14042017Context())
            {
                db.Entry(image).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public Image GetBy(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            using (var db = new DBWebsite14042017Context())
            {
                return db.Images.AsEnumerable().Where(x => x.Name == name).FirstOrDefault();
            }
        }
        public void Update(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            using (var db = new DBWebsite14042017Context())
            {
                db.Entry(image).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Image GetBanner()
        {
            try
            {
                using(var db = new DBWebsite14042017Context())
                {
                    return db.Images.AsEnumerable().Where(x => x.Type == "banner").FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Image> GetSlider()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    return db.Images.Where(x => x.Type == "slider").ToList(); ;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}