using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApi.Models
{
    public class Teams
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Teams()
        {
        }

        public Guid ID { get; set; }
        public Guid OrganizationID { get; set; }
        public Guid SportID { get; set; }
        public string Title { get; set; }
        public string DisplayTitle { get; set; }
        public bool? Active { get; set; }
        public string AbbreviationTitle { get; set; }
        public string AccountNumber { get; set; }
        public decimal DefaultDuration { get; set; }
        public decimal? OfficialFees { get; set; }
        public decimal? OfficialExpenses { get; set; }
        public Guid GameCalendarID { get; set; }
        public Guid PracticeCalendarID { get; set; }
        public string PwaTeamID { get; set; }
        public decimal? DefaultTicketCostDollars { get; set; }
        public bool TicketSalesEnabled { get; set; }
        public int? DefaultMaxTicketsAllowed { get; set; }
        public bool DefaultAutomaticCreditCardAttendance { get; set; }

        public virtual Calendars GameCalendar { get; set; }
        public virtual Calendars PracticeCalendar { get; set; }
    }

    internal class TeamsEntityTypeConfiguration : IEntityTypeConfiguration<Teams>
    {
        public void Configure(EntityTypeBuilder<Teams> entity)
        {
            entity.HasIndex(e => e.Active)
                    .HasDatabaseName("Teams_Active_IX");

                entity.HasIndex(e => e.GameCalendarID)
                    .HasDatabaseName("Teams_GameCalendarID_IX");

                entity.HasIndex(e => e.OrganizationID)
                    .HasDatabaseName("Teams_OrganizationID_IX");

                entity.HasIndex(e => e.PracticeCalendarID)
                    .HasDatabaseName("Teams_PracticeCalendarID_IX");

                entity.HasIndex(e => e.SportID)
                    .HasDatabaseName("Teams_SportID_IX");

                entity.HasIndex(e => e.Title)
                    .HasDatabaseName("Teams_Title_IX");

                entity.Property(e => e.ID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DefaultTicketCostDollars).HasColumnType("DECIMAL(9, 2)");

                entity.Property(e => e.AbbreviationTitle)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultDuration).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DisplayTitle).HasMaxLength(50);

                entity.Property(e => e.OfficialExpenses).HasColumnType("smallmoney");

                entity.Property(e => e.OfficialFees).HasColumnType("smallmoney");

                entity.Property(e => e.PwaTeamID).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.GameCalendar)
                    .WithMany(p => p.TeamsGameCalendar)
                    .HasForeignKey(d => d.GameCalendarID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Teams_GameCalendarID_FK");

                entity.HasOne(d => d.PracticeCalendar)
                    .WithMany(p => p.TeamsPracticeCalendar)
                    .HasForeignKey(d => d.PracticeCalendarID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Teams_PracticeCalendarID_FK");
        }
    }
}