﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Website_14042017.Startup))]

namespace Website_14042017
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
        }
    }
}
