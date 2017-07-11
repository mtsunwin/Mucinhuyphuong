using Microsoft.AspNet.SignalR;
using System;
using System.Web;
using System.Threading.Tasks;
using System.IO;

namespace Website_14042017.Hubs
{
    public class CounterHub : Hub
    {
        static long counter = 0;
        static long totalUserOfDay = 0;
        static long totalUserOfWeek = 0;
        static bool flagFromDisToCon = false;
        static string dayWrited = DateTime.Now.Day.ToString();

        public override Task OnConnected()
        {
            if(counter <= 0)
            {
                flagFromDisToCon = false;
            }
            ReadInfoNumberUser();
            if (DateTime.Now.DayOfWeek.ToString() == "Monday")
            {
                if (dayWrited != "Monday")
                {
                    totalUserOfDay = 0;
                    totalUserOfWeek = 0;

                    WriteInfoNumberUser(totalUserOfDay, totalUserOfWeek);
                    ReadInfoNumberUser();
                }
            }

            if (dayWrited != DateTime.Now.DayOfWeek.ToString())
            {
                totalUserOfDay = 0;
            }

            if (!flagFromDisToCon)
            {
                totalUserOfWeek++;
                totalUserOfDay++;
                WriteInfoNumberUser(totalUserOfDay, totalUserOfWeek);
            }
            flagFromDisToCon = false;
            counter = counter + 1;
            Clients.All.UpdateCount(counter);
            Clients.All.UpdateWeek(totalUserOfWeek);
            Clients.All.UpdateDay(totalUserOfDay);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            flagFromDisToCon = true;
            if (counter >= 1)
                counter = counter - 1;
            else
                counter = 0;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }

        private void ReadInfoNumberUser()
        {
            //Get info
            try
            {
                //Get info file NumberUser.txt
                using (var file = new StreamReader(HttpContext.Current.Server.MapPath("/NumberUser.txt")))
                {
                    string text = null;
                    int index = 0;
                    int point = 0;
                    while ((text = file.ReadLine()) != null)
                    {
                        point = text.LastIndexOf(':') + 1;
                        if (index == 0)
                        {
                            dayWrited = text.Substring(point);
                        }
                        else if (index == 1)
                        {
                            totalUserOfDay = long.Parse(text.Substring(point));
                        }
                        else if (index == 2)
                        {
                            totalUserOfWeek = long.Parse(text.Substring(point));
                        }
                        index++;
                    }
                }

            }
            catch
            {
            }
        }
        private void WriteInfoNumberUser(long number1, long number2)
        {
            try
            {
                int index = 0;
                using (var file = new StreamWriter(HttpContext.Current.Server.MapPath("/NumberUser.txt")))
                {
                    file.WriteLine("[{0}]:{1}", index, DateTime.Now.DayOfWeek.ToString());
                    index++;
                    file.WriteLine("[{0}]:TotalUserOfDay:{1}", index, number1);
                    index++;
                    file.WriteLine("[{0}]:TotalUserOfWeek:{1}", index, number2);
                }
            }
            catch
            {
            }
        }
    }
}