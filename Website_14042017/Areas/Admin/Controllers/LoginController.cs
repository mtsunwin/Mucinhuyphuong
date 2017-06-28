using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Website_14042017.Areas.Admin.Models;
using Website_14042017.DAL;
using Website_14042017.Models;

namespace Website_14042017.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AccountDAL accDAL;
        public LoginController()
        {
            accDAL = new AccountDAL();
        }
        [HttpGet]
        public ActionResult Setting()
        {
            if (Session["accAdmin"] != null)
            {
                Account acc = (Account)Session["accAdmin"];
                if (Request.Params["changeinfo"] == null)
                {
                    ViewBag.Message = "";
                }
                else if (Request.Params["changeinfo"] == "true")
                {
                    ViewBag.Message = "Thay đổi thành công";
                }
                else if (Request.Params["changeinfo"] == "false")
                {
                    ViewBag.Message = "Thay đổi không thành công";
                }
                return View(acc);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ChangeInfo(Account acc)
        {
            if (ModelState.IsValid)
            {
                Account accinfo = (Account)Session["accAdmin"];
                string hash = string.Empty;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, acc.Password);
                }
                acc.Password = hash;
                if (accDAL.ChangeInfo(acc, accinfo.Email, accinfo.Password))
                {
                    return Redirect("/admin/login/setting?changeinfo=true");
                }
                else
                {
                    return Redirect("/admin/login/setting?changeinfo=false");
                }
            }
            else
            {
                return Redirect("/admin/login/setting?changeinfo=false");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            string hash = string.Empty;

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, password);
            }
            var acc = accDAL.Get(email, hash);
            if (acc != null && acc.Email == email && acc.Password == hash)
            {
                Session["accAdmin"] = acc;
                return RedirectToAction("Index", "Index");
            }
            else
            {
                ViewBag.LoginValidatoin = "Email or password incorrected!";
                return View("index");
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
