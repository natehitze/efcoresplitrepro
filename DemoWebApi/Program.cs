using System;
using System.Linq;
using DemoWebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace DemoWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                
                db.Database.Migrate();

                var eventsList = db.Events.ToList();
                if (eventsList.Count == 0)
                {
                    var organizationSubscriptionID = new Guid("140F1713-2D7A-4F78-A8D8-23B3983C0231");
                    
                    var calendar = new Calendars()
                    {
                        Title = "test calendar",
                    };
                    db.Calendars.Add(calendar);
                    var team = new Teams()
                    {
                        Title = "test team",
                        AbbreviationTitle = "tt",
                        GameCalendar = calendar,
                        PracticeCalendar = calendar,
                    };
                    db.Teams.Add(team);
                    db.CalendarSubscriptions.Add(new CalendarSubscriptions()
                    {
                        BackColor = "#123456",
                        TextColor = "#123456",
                        Calendar = calendar,
                        OrganizationSubscriptionID = organizationSubscriptionID,
                        Visible = true,
                    });
                    db.Events.Add(new Events()
                    {
                        Title = "test event",
                        TimeZone = "US/Eastern",
                        PrimaryCalendar = calendar,
                    });
                    db.SaveChanges();   
                }
            }
                
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(cfg =>
                {
                    cfg.AddConsole();
                });
    }
}