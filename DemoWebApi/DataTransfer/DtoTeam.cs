using System;

namespace DemoWebApi.DataTransfer
{
    public class DtoTeam
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string DisplayTitle { get; set; }
        public Guid OrganizationID { get; set; }
    }
}