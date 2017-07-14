using System;
using System.IO;
using System.Web;

namespace Website_14042017.Common
{
    public class RWFileText
    {
        public string Read(string fileName)
        {
            string result = String.Empty;
            try
            {
                using (var file = new StreamReader(HttpContext.Current.Server.MapPath(fileName)))
                {
                    string text = null;
                    
                    while ((text = file.ReadLine()) != null)
                    {
                        result += text;
                    }
                }

            }
            catch
            {
                result = "Read file error!";
            }
            return result;
        }
        public void Write(string fileName, string content)
        {
            try
            {
                using (var file = new StreamWriter(HttpContext.Current.Server.MapPath(fileName)))
                {
                    file.WriteLine(content);
                }
            }
            catch
            {
            }
        }
    }
}