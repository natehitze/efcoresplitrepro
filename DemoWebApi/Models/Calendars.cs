using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApi.Models
{
    public class Calendars
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Calendars()
        {
            CalendarSubscriptions = new HashSet<CalendarSubscriptions>();
            Events = new HashSet<Events>();
            TeamsGameCalendar = new HashSet<Teams>();
            TeamsPracticeCalendar = new HashSet<Teams>();
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public bool Unlisted { get; set; }
        public string TextColor { get; set; }
        public string BackColor { get; set; }
        public string PwCalendarID { get; set; }
        public string PwaTeamID { get; set; }

        public virtual ICollection<CalendarSubscriptions> CalendarSubscriptions { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<Teams> TeamsGameCalendar { get; set; }
        public virtual ICollection<Teams> TeamsPracticeCalendar { get; set; }
    }

    internal class CalendarsEntityTypeConfiguration : IEntityTypeConfiguration<Calendars>
    {
        public void Configure(EntityTypeBuilder<Calendars> entity)
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newid())");

            entity.Property(e => e.BackColor)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PwCalendarID).HasMaxLength(255);

            entity.Property(e => e.PwaTeamID).HasMaxLength(255);

            entity.Property(e => e.TextColor)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}