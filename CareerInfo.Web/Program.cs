﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CareerInfo.Web
{
     public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                //.UseUrls("http://localhost:8086")
                .Build();

            host.Run();
        }
    }
}
