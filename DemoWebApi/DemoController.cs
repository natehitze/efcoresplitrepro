using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoWebApi.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi
{
    public class DemoController : Controller
    {
        private readonly MyDbContext _db;

        public DemoController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("api/demo/getevents")]
        public async Task<ActionResult> GetEvents(CancellationToken cancellationToken = default)
        {
            try
            {
                var g = Guid.NewGuid();
                var id = new Guid("140F1713-2D7A-4F78-A8D8-23B3983C0231");
                var events = await _db.CalendarSubscriptions
                    .Where(cs => cs.OrganizationSubscriptionID == id)
                    .SelectMany(cs => cs.Calendar.Events)
                    .Where(e => e.ID != g)
                    .Select(e => new DtoEvent
                    {
                        PrimaryCalendar = new DtoCalendar()
                        {
                            TeamsGameCalendar = e.PrimaryCalendar.TeamsGameCalendar.Select(t => new DtoTeam()
                            {
                            }),
                        },
                    })
                    .AsSplitQuery()
                    .ToListAsync(cancellationToken);
                Console.WriteLine($"{events.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }
    }
}