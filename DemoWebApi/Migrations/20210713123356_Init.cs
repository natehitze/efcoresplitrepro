using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unlisted = table.Column<bool>(type: "bit", nullable: false),
                    TextColor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BackColor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PwCalendarID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PwaTeamID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CalendarSubscriptions",
                columns: table => new
                {
                    OrganizationSubscriptionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalendarID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    TextColor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BackColor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CalendarSubscriptions_PK", x => new { x.OrganizationSubscriptionID, x.CalendarID });
                    table.ForeignKey(
                        name: "CalendarSubscriptions_CalendarID_FK",
                        column: x => x.CalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrimaryCalendarID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Zip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RepeatID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DepartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HostingOrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CancelDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LevelID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SportID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PwEventID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PwaEventID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsCrewEvent = table.Column<bool>(type: "bit", nullable: false),
                    CommunityNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "(case when [StartTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[StartTime],[StartDate]),CONVERT([datetime2],[StartTime]))) end)"),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, computedColumnSql: "(case when [EndTime] IS NULL then CONVERT([datetime2],NULL) else CONVERT([datetime2],dateadd(day,datediff(day,[EndTime],[EndDate]),CONVERT([datetime2],[EndTime]))) end)"),
                    IsAllDay = table.Column<int>(type: "int", nullable: false, computedColumnSql: "(case when [StartTime] IS NULL then (1) else (0) end)"),
                    OfficialInvitationNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForOrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "Events_PrimaryCalendarID_FK",
                        column: x => x.PrimaryCalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    AbbreviationTitle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultDuration = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    OfficialFees = table.Column<decimal>(type: "smallmoney", nullable: true),
                    OfficialExpenses = table.Column<decimal>(type: "smallmoney", nullable: true),
                    GameCalendarID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeCalendarID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PwaTeamID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DefaultTicketCostDollars = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: true),
                    TicketSalesEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultMaxTicketsAllowed = table.Column<int>(type: "int", nullable: true),
                    DefaultAutomaticCreditCardAttendance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "Teams_GameCalendarID_FK",
                        column: x => x.GameCalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Teams_PracticeCalendarID_FK",
                        column: x => x.PracticeCalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSubscriptions_CalendarID",
                table: "CalendarSubscriptions",
                column: "CalendarID");

            migrationBuilder.CreateIndex(
                name: "azure_860FB2",
                table: "Events",
                column: "PrimaryCalendarID");

            migrationBuilder.CreateIndex(
                name: "azure_A102C2",
                table: "Events",
                column: "CancelDateTime");

            migrationBuilder.CreateIndex(
                name: "Events_ContractID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "ContractID" });

            migrationBuilder.CreateIndex(
                name: "Events_HostingOrganizationID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "HostingOrganizationID" });

            migrationBuilder.CreateIndex(
                name: "Events_IsAllDay_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "Events_LevelID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "LevelID" });

            migrationBuilder.CreateIndex(
                name: "Events_LinkID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "LinkID" });

            migrationBuilder.CreateIndex(
                name: "Events_PrimaryCalendarID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "PrimaryCalendarID" });

            migrationBuilder.CreateIndex(
                name: "Events_RepeatID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "RepeatID" });

            migrationBuilder.CreateIndex(
                name: "Events_SportID_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "SportID" });

            migrationBuilder.CreateIndex(
                name: "Events_StartEndDateTime_IX",
                table: "Events",
                columns: new[] { "ID", "StartDateTime", "EndDateTime", "StartDate", "EndDate", "IsAllDay", "StartTime", "EndTime" });

            migrationBuilder.CreateIndex(
                name: "Events_Title_IX",
                table: "Events",
                columns: new[] { "ID", "IsAllDay", "StartDate", "StartTime", "StartDateTime", "EndDate", "EndTime", "EndDateTime", "Title" });

            migrationBuilder.CreateIndex(
                name: "Teams_Active_IX",
                table: "Teams",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "Teams_GameCalendarID_IX",
                table: "Teams",
                column: "GameCalendarID");

            migrationBuilder.CreateIndex(
                name: "Teams_OrganizationID_IX",
                table: "Teams",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "Teams_PracticeCalendarID_IX",
                table: "Teams",
                column: "PracticeCalendarID");

            migrationBuilder.CreateIndex(
                name: "Teams_SportID_IX",
                table: "Teams",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "Teams_Title_IX",
                table: "Teams",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarSubscriptions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Calendars");
        }
    }
}
