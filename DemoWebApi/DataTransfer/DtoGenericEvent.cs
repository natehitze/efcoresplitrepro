using System;

namespace DemoWebApi.DataTransfer
{
    public class DtoGenericEvent<TCalendar>
    {
        public string Title { get; set; }
        public TCalendar PrimaryCalendar { get; set; }
        public Guid PrimaryCalendarID { get; set; }
    }
}