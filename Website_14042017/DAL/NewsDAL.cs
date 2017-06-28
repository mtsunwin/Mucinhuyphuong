using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_14042017.Models;

namespace Website_14042017.DAL
{
    public class NewsDAL
    {
        public void Add(News news)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    news.Status = "writing";
                    db.Newses.Add(news);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }
        public void PostNews(News nNews)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == nNews.Id).FirstOrDefault();
                    if (news != null)
                    {
                        news.Title = nNews.Title;
                        news.Descrip = nNews.Descrip;
                        news.Content = nNews.Content;
                        news.DatePost = DateTime.Now;
                        news.Author = nNews.Author;
                        news.Status = "post";
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void PostIntroduction(News nNews)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == nNews.Id).FirstOrDefault();
                    if (news != null)
                    {
                        news.Title = nNews.Title;
                        news.Descrip = nNews.Descrip;
                        news.Content = nNews.Content;
                        news.DatePost = DateTime.Now;
                        news.Author = nNews.Author;
                        news.Status = "post introduction";
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void PostContactInfo(News nNews)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == nNews.Id).FirstOrDefault();
                    if (news != null)
                    {
                        news.Title = nNews.Title;
                        news.Descrip = nNews.Descrip;
                        news.Content = nNews.Content;
                        news.DatePost = DateTime.Now;
                        news.Author = nNews.Author;
                        news.Status = "post contact info";
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public void UpDate(News nNews)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == nNews.Id).FirstOrDefault();
                    if (news != null)
                    {
                        news.Title = nNews.Title;
                        news.Descrip = nNews.Descrip;
                        news.Content = nNews.Content;
                        news.DatePost = nNews.DatePost;
                        news.Author = nNews.Author;
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public News GetById(int? id)
        {
            try
            {
                if (id == null)
                    return null;
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == id).FirstOrDefault();
                    if (news != null)
                        return news;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == id).FirstOrDefault();
                    if (news != null)
                    {
                        db.Newses.Remove(news);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<News> GetAll()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).ToList();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<News> GetWriting()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).Where(y => y.Status == "writing").ToList();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<News> GetPosted()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).Where(y => y.Status == "post" || y.Status== "post introduction" || y.Status== "post contact info").ToList();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
        public void PostNews(int id)
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var news = db.Newses.Where(x => x.Id == id).FirstOrDefault();
                    if (news != null)
                    {
                        news.Status = "post";
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
            }
        }
        public IEnumerable<News> GetNewNews(int count)
        {
            try
            {
                if (count <= 0)
                    return null;
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).Take(count).ToList();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
        public News GetIntroduction()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).Where(y => y.Status == "post introduction").FirstOrDefault();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
        public News GetContactInfo()
        {
            try
            {
                using (var db = new DBWebsite14042017Context())
                {
                    var newses = db.Newses.OrderBy(x => x.DatePost).Where(y => y.Status == "post contact info").FirstOrDefault();
                    return newses;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}