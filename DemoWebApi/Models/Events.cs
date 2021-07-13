using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NodaTime;

namespace DemoWebApi.Models
{
    public class Events
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Events()
        {
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public Guid PrimaryCalendarID { get; set; }
        public string Location { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string TimeZone { get; set; }
        public Guid? RepeatID { get; set; }
        public string StaffNotes { get; set; }
        public Guid CreatedByUserID { get; set; }
        public Guid? ContractID { get; set; }
        public string EventType { get; set; }
        public Instant? DepartDateTime { get; set; }
        public Instant? ReturnDateTime { get; set; }
        public Guid? LinkID { get; set; }
        public Guid? HostingOrganizationID { get; set; }
        public Instant? CancelDateTime { get; set; }
        public Guid? LevelID { get; set; }
        public Guid? SportID { get; set; }
        public string PwEventID { get; set; }
        public string PwaEventID { get; set; }
        public bool IsCrewEvent { get; set; }
        public string CommunityNotes { get; set; }
        public LocalDate? StartDate { get; set; }
        public LocalTime? StartTime { get; set; }
        public LocalDate? EndDate { get; set; }
        public LocalTime? EndTime { get; set; }
        public Instant? StartDateTime { get; set; }
        public Instant? EndDateTime { get; set; }
        public int IsAllDay { get; set; }
        public string OfficialInvitationNotes { get; set; }
        public Instant? CreatedAt { get; set; }
        public Guid? ForOrganizationID { get; set; }
        public virtual Calendars PrimaryCalendar { get; set; }
    }

    internal class EventsEntityTypeConfiguration : IEntityTypeConfiguration<Events>
    {
        public void Configure(EntityTypeBuilder<Events> entity)
        {
            entity.HasIndex(e => e.CancelDateTime)
                    .HasDatabaseName("azure_A102C2");

                entity.HasIndex(e => e.PrimaryCalendarID)
                    .HasDatabaseName("azure_860FB2");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.EndDate })
                    .HasDatabaseName("Events_IsAllDay_IX");

                entity.HasIndex(e => new { e.ID, e.StartDateTime, e.EndDateTime, e.StartDate, e.EndDate, e.IsAllDay, e.StartTime, e.EndTime })
                    .HasDatabaseName("Events_StartEndDateTime_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.ContractID })
                    .HasDatabaseName("Events_ContractID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.HostingOrganizationID })
                    .HasDatabaseName("Events_HostingOrganizationID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.LevelID })
                    .HasDatabaseName("Events_LevelID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.LinkID })
                    .HasDatabaseName("Events_LinkID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.PrimaryCalendarID })
                    .HasDatabaseName("Events_PrimaryCalendarID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.RepeatID })
                    .HasDatabaseName("Events_RepeatID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.SportID })
                    .HasDatabaseName("Events_SportID_IX");

                entity.HasIndex(e => new { e.ID, e.IsAllDay, e.StartDate, e.StartTime, e.StartDateTime, e.EndDate, e.EndTime, e.EndDateTime, e.Title })
                    .HasDatabaseName("Events_Title_IX");

                entity.Property(e => e.ID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1).HasMaxLength(300);

                entity.Property(e => e.Address2).HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.EndDateTime).HasComputedColumnSql("(case when [EndTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[EndTime],[EndDate]),CONVERT([datetime2],[EndTime]))) end)");

                entity.Property(e => e.EventType).HasMaxLength(200);

                entity.Property(e => e.IsAllDay).HasComputedColumnSql("(case when [StartTime] IS NULL then (1) else (0) end)");

                entity.Property(e => e.Location).HasMaxLength(300);

                entity.Property(e => e.PwEventID).HasMaxLength(255);

                entity.Property(e => e.PwaEventID).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartDateTime).HasComputedColumnSql("(case when [StartTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[StartTime],[StartDate]),CONVERT([datetime2],[StartTime]))) end)");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TimeZone)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrimaryCalendar)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.PrimaryCalendarID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Events_PrimaryCalendarID_FK");
        }
    }
}