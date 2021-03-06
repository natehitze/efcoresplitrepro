// <auto-generated />
using System;
using DemoWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoWebApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210713123356_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoWebApi.Models.CalendarSubscriptions", b =>
                {
                    b.Property<Guid>("OrganizationSubscriptionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalendarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackColor")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TextColor")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("OrganizationSubscriptionID", "CalendarID")
                        .HasName("CalendarSubscriptions_PK");

                    b.HasIndex("CalendarID");

                    b.ToTable("CalendarSubscriptions");
                });

            modelBuilder.Entity("DemoWebApi.Models.Calendars", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("BackColor")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PwCalendarID")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PwaTeamID")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TextColor")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("DemoWebApi.Models.Events", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Address1")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Address2")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("CancelDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CommunityNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ContractID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedByUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DepartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("EndDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("(case when [EndTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[EndTime],[EndDate]),CONVERT([datetime2],[EndTime]))) end)");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("EventType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("ForOrganizationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HostingOrganizationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsAllDay")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("(case when [StartTime] IS NULL then (1) else (0) end)");

                    b.Property<bool>("IsCrewEvent")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LevelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LinkID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("OfficialInvitationNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PrimaryCalendarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PwEventID")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PwaEventID")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("RepeatID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ReturnDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StaffNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("StartDateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("(case when [StartTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[StartTime],[StartDate]),CONVERT([datetime2],[StartTime]))) end)");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Zip")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("ID");

                    b.HasIndex("CancelDateTime")
                        .HasDatabaseName("azure_A102C2");

                    b.HasIndex("PrimaryCalendarID")
                        .HasDatabaseName("azure_860FB2");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "EndDate")
                        .HasDatabaseName("Events_IsAllDay_IX");

                    b.HasIndex("ID", "StartDateTime", "EndDateTime", "StartDate", "EndDate", "IsAllDay", "StartTime", "EndTime")
                        .HasDatabaseName("Events_StartEndDateTime_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "ContractID")
                        .HasDatabaseName("Events_ContractID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "HostingOrganizationID")
                        .HasDatabaseName("Events_HostingOrganizationID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "LevelID")
                        .HasDatabaseName("Events_LevelID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "LinkID")
                        .HasDatabaseName("Events_LinkID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "PrimaryCalendarID")
                        .HasDatabaseName("Events_PrimaryCalendarID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "RepeatID")
                        .HasDatabaseName("Events_RepeatID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "SportID")
                        .HasDatabaseName("Events_SportID_IX");

                    b.HasIndex("ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "Title")
                        .HasDatabaseName("Events_Title_IX");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DemoWebApi.Models.Teams", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AbbreviationTitle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("DefaultAutomaticCreditCardAttendance")
                        .HasColumnType("bit");

                    b.Property<decimal>("DefaultDuration")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int?>("DefaultMaxTicketsAllowed")
                        .HasColumnType("int");

                    b.Property<decimal?>("DefaultTicketCostDollars")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<string>("DisplayTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("GameCalendarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("OfficialExpenses")
                        .HasColumnType("smallmoney");

                    b.Property<decimal?>("OfficialFees")
                        .HasColumnType("smallmoney");

                    b.Property<Guid>("OrganizationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PracticeCalendarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PwaTeamID")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("SportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TicketSalesEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("Active")
                        .HasDatabaseName("Teams_Active_IX");

                    b.HasIndex("GameCalendarID")
                        .HasDatabaseName("Teams_GameCalendarID_IX");

                    b.HasIndex("OrganizationID")
                        .HasDatabaseName("Teams_OrganizationID_IX");

                    b.HasIndex("PracticeCalendarID")
                        .HasDatabaseName("Teams_PracticeCalendarID_IX");

                    b.HasIndex("SportID")
                        .HasDatabaseName("Teams_SportID_IX");

                    b.HasIndex("Title")
                        .HasDatabaseName("Teams_Title_IX");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DemoWebApi.Models.CalendarSubscriptions", b =>
                {
                    b.HasOne("DemoWebApi.Models.Calendars", "Calendar")
                        .WithMany("CalendarSubscriptions")
                        .HasForeignKey("CalendarID")
                        .HasConstraintName("CalendarSubscriptions_CalendarID_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("DemoWebApi.Models.Events", b =>
                {
                    b.HasOne("DemoWebApi.Models.Calendars", "PrimaryCalendar")
                        .WithMany("Events")
                        .HasForeignKey("PrimaryCalendarID")
                        .HasConstraintName("Events_PrimaryCalendarID_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PrimaryCalendar");
                });

            modelBuilder.Entity("DemoWebApi.Models.Teams", b =>
                {
                    b.HasOne("DemoWebApi.Models.Calendars", "GameCalendar")
                        .WithMany("TeamsGameCalendar")
                        .HasForeignKey("GameCalendarID")
                        .HasConstraintName("Teams_GameCalendarID_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DemoWebApi.Models.Calendars", "PracticeCalendar")
                        .WithMany("TeamsPracticeCalendar")
                        .HasForeignKey("PracticeCalendarID")
                        .HasConstraintName("Teams_PracticeCalendarID_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GameCalendar");

                    b.Navigation("PracticeCalendar");
                });

            modelBuilder.Entity("DemoWebApi.Models.Calendars", b =>
                {
                    b.Navigation("CalendarSubscriptions");

                    b.Navigation("Events");

                    b.Navigation("TeamsGameCalendar");

                    b.Navigation("TeamsPracticeCalendar");
                });
#pragma warning restore 612, 618
        }
    }
}
