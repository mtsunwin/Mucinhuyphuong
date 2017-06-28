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
        public ImageDAL()
        {
            root = HttpContext.Current.Server.MapPath("/Areas/Admin/Images/");
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
    }
}