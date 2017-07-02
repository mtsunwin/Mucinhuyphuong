using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class AccountDAL
    {
        public Account Get(string email, string password)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var acc = db.Accounts.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                    return acc;
                }
            }
            catch
            {
                return null;
            }
        }
        public bool ChangeInfo(Account acc, string email, string password)
        {
            using (var db = new DBWebsite14042017Context())
            {
                try
                {
                    var account = db.Accounts.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                    if (account != null)
                    {
                        account.Email = acc.Email;
                        account.Password = acc.Password;
                        account.Phone = acc.Phone;
                        account.Web = acc.Web;
                        account.Descrip = acc.Descrip;
                        account.Blog = acc.Blog;
                        db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}