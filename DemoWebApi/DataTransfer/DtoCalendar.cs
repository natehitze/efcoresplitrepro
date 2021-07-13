using System.Collections.Generic;

namespace DemoWebApi.DataTransfer
{
    public class DtoCalendar
    {
        public string Title { get; set; }
        public IEnumerable<DtoTeam> TeamsGameCalendar { get; set; }
    }
}