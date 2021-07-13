using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApi.Models
{
    public class CalendarSubscriptions
    {
        public Guid OrganizationSubscriptionID { get; set; }
        public Guid CalendarID { get; set; }
        public bool Visible { get; set; }
        public string TextColor { get; set; }
        public string BackColor { get; set; }

        public virtual Calendars Calendar { get; set; }
    }
    
    internal class CalendarSubscriptionsEntityTypeConfiguration : IEntityTypeConfiguration<CalendarSubscriptions>
    {
        public void Configure(EntityTypeBuilder<CalendarSubscriptions> entity)
        {
            entity.HasKey(e => new { e.OrganizationSubscriptionID, e.CalendarID })
                .HasName("CalendarSubscriptions_PK");

            entity.Property(e => e.BackColor)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.TextColor)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Calendar)
                .WithMany(p => p.CalendarSubscriptions)
                .HasForeignKey(d => d.CalendarID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("CalendarSubscriptions_CalendarID_FK");
        }
    }
}