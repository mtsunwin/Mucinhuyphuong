using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class MenuDAL
    {
        //MenuLevel0
        public void CreateMenu0(MenuLevel0 menu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    db.MenuLevel0s.Add(menu);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }
        public void DeleteMenu0(string name)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel0s.Where(x => x.Name == name).FirstOrDefault();
                    if (menu != null)
                    {
                        var menu1 = db.MenuLevel1s.Where(x => x.IdMenuLevel0 == name);
                        if (menu1 != null)
                        {
                            foreach (var item in menu1)
                            {
                                var menu2 = db.MenuLevel2s.Where(x => x.IdMenuLevel1 == item.Id);
                                if (menu2 != null)
                                {
                                    foreach (var item2 in menu2)
                                    {
                                        db.MenuLevel2s.Remove(item2);
                                    }
                                }
                                db.MenuLevel1s.Remove(item);
                            }
                        }
                        db.MenuLevel0s.Remove(menu);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void UpDateMenu0(MenuLevel0 newMenu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel0s.Where(x => x.Name == newMenu.Name).FirstOrDefault();
                    if (menu != null)
                    {
                        menu.DisplayName = newMenu.DisplayName;
                        menu.Link = newMenu.Link;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<MenuLevel0> GetAllMenu0()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    return db.MenuLevel0s.OrderBy(x => x.Prioritize).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public MenuLevel0 GetMenu0ById(string id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menuLevel0s = db.MenuLevel0s.Where(x => x.Name == id).FirstOrDefault();
                    return menuLevel0s;
                }
            }
            catch
            {
                return null;
            }
        }
        //MenuLeve1
        public void CreateMenu1(MenuLevel1 menu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    db.MenuLevel1s.Add(menu);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }
        public void DeleteMenu1(int id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel1s.Where(x => x.Id == id).FirstOrDefault();
                    if (menu != null)
                    {
                        var menu2 = db.MenuLevel2s.Where(x => x.IdMenuLevel1 == id);
                        if (menu2 != null)
                        {
                            foreach (var item in menu2)
                            {
                                db.MenuLevel2s.Remove(item);
                            }
                        }
                        db.MenuLevel1s.Remove(menu);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void UpDateMenu1(MenuLevel1 newMenu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel1s.Where(x => x.Id == newMenu.Id).FirstOrDefault();
                    if (menu != null)
                    {
                        menu.DisplayName = newMenu.DisplayName;
                        menu.Link = newMenu.Link;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<MenuLevel1> GetMenu1OfMenu0(string id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menuLevel1s = db.MenuLevel1s.Where(x => x.IdMenuLevel0 == id).ToList();
                    return menuLevel1s;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<MenuLevel1> GetAllMenu1()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menus = db.MenuLevel1s.OrderBy(x => x.Id).ToList();
                    return menus;
                }
            }
            catch
            {
                return null;
            }
        }
        public MenuLevel1 GetByDisplayNameMenu1(string name)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel1s.Where(x => x.DisplayName == name).FirstOrDefault();
                    return menu;
                }
            }
            catch
            {
                return null;
            }
        }
        //MenuLevel2
        public void CreateMenu2(MenuLevel2 menu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    db.MenuLevel2s.Add(menu);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }
        public void DeleteMenu2(int id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel2s.Where(x => x.Id == id).FirstOrDefault();
                    if (menu != null)
                    {
                        db.MenuLevel2s.Remove(menu);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void UpDateMenu2(MenuLevel2 newMenu)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel2s.Where(x => x.Id == newMenu.Id).FirstOrDefault();
                    if (menu != null)
                    {
                        menu.DisplayName = newMenu.DisplayName;
                        menu.Link = newMenu.Link;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {

            }
        }
        public IEnumerable<MenuLevel2> GetMenu2OfMenu1(int idMenuLevel1)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menuLevel2s = db.MenuLevel2s.Where(x => x.IdMenuLevel1 == idMenuLevel1).ToList();
                    return menuLevel2s;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<MenuLevel2> GetAllMenu2()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menus = db.MenuLevel2s.OrderBy(x => x.Id).ToList();
                    return menus;
                }
            }
            catch
            {
                return null;
            }
        }
        public MenuLevel2 GetByDisplayNameMenu2(string name, int menu1)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var menu = db.MenuLevel2s.Where(x => x.DisplayName == name && x.IdMenuLevel1 == menu1).FirstOrDefault();
                    return menu;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}