using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDCWS.Migrations
{
    public partial class allowedNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveloadShedding",
                columns: table => new
                {
                    ArchiveLoadSheddingSNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadSheddingSNO = table.Column<int>(nullable: false),
                    group = table.Column<string>(nullable: true),
                    block = table.Column<string>(nullable: true),
                    llFeders = table.Column<int>(nullable: true),
                    mlFeeders = table.Column<int>(nullable: true),
                    hlFeeders = table.Column<int>(nullable: true),
                    vhlFeeders = table.Column<int>(nullable: true),
                    totalFeeders = table.Column<int>(nullable: true),
                    spell_1_to_and_From = table.Column<string>(nullable: true),
                    spell_2_to_and_From = table.Column<string>(nullable: true),
                    spell_3_to_and_From = table.Column<string>(nullable: true),
                    spell_4_to_and_From = table.Column<string>(nullable: true),
                    spell_5_to_and_From = table.Column<string>(nullable: true),
                    spell_6_to_and_From = table.Column<string>(nullable: true),
                    planExpiry = table.Column<DateTime>(nullable: true),
                    dataAddedDateTime = table.Column<DateTime>(nullable: true),
                    dataAddedBy = table.Column<int>(nullable: true),
                    ArchiveAddedDateTime = table.Column<DateTime>(nullable: true),
                    ArchiveAddedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveloadShedding", x => x.ArchiveLoadSheddingSNO);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveMasterData",
                columns: table => new
                {
                    MasterDataArchiveSNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterDataSNO = table.Column<int>(nullable: false),
                    ISLAND = table.Column<string>(nullable: true),
                    GridBlock = table.Column<string>(nullable: true),
                    TRAFO = table.Column<string>(nullable: true),
                    FeederID = table.Column<int>(nullable: false),
                    Switch_Number = table.Column<string>(nullable: true),
                    Switch_Name = table.Column<string>(nullable: true),
                    Switch_Type = table.Column<string>(nullable: true),
                    FEEDER_TYPE = table.Column<string>(nullable: true),
                    Switch_Make = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Cable_Status = table.Column<string>(nullable: true),
                    UFR_SW = table.Column<string>(nullable: true),
                    Stage_A = table.Column<string>(nullable: true),
                    Stage_B = table.Column<string>(nullable: true),
                    S1 = table.Column<string>(nullable: true),
                    S2 = table.Column<string>(nullable: true),
                    S3 = table.Column<string>(nullable: true),
                    S4 = table.Column<string>(nullable: true),
                    S5 = table.Column<string>(nullable: true),
                    S6 = table.Column<string>(nullable: true),
                    S7 = table.Column<string>(nullable: true),
                    S8 = table.Column<string>(nullable: true),
                    S9 = table.Column<string>(nullable: true),
                    S10 = table.Column<string>(nullable: true),
                    S11 = table.Column<string>(nullable: true),
                    CAP_OK_MVAR = table.Column<decimal>(nullable: false),
                    CAP_MVAR = table.Column<decimal>(nullable: false),
                    dataAddedDateTime = table.Column<DateTime>(nullable: false),
                    dataAddedBy = table.Column<int>(nullable: false),
                    ArchiveAddedDateTime = table.Column<DateTime>(nullable: false),
                    ArchiveAddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveMasterData", x => x.MasterDataArchiveSNO);
                });

            migrationBuilder.CreateTable(
                name: "loadShedding",
                columns: table => new
                {
                    LoadSheddingSNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group = table.Column<string>(nullable: true),
                    block = table.Column<string>(nullable: true),
                    llFeders = table.Column<int>(nullable: true),
                    mlFeeders = table.Column<int>(nullable: true),
                    hlFeeders = table.Column<int>(nullable: true),
                    vhlFeeders = table.Column<int>(nullable: true),
                    totalFeeders = table.Column<int>(nullable: true),
                    spell_1_to_and_From = table.Column<string>(nullable: true),
                    spell_2_to_and_From = table.Column<string>(nullable: true),
                    spell_3_to_and_From = table.Column<string>(nullable: true),
                    spell_4_to_and_From = table.Column<string>(nullable: true),
                    spell_5_to_and_From = table.Column<string>(nullable: true),
                    spell_6_to_and_From = table.Column<string>(nullable: true),
                    planExpiry = table.Column<DateTime>(nullable: true),
                    dataAddedDateTime = table.Column<DateTime>(nullable: true),
                    dataAddedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loadShedding", x => x.LoadSheddingSNO);
                });

            migrationBuilder.CreateTable(
                name: "MasterData",
                columns: table => new
                {
                    MasterDataSNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISLAND = table.Column<string>(nullable: true, defaultValue: "no inserted"),
                    GridBlock = table.Column<string>(nullable: true, defaultValue: "no inserted"),
                    TRAFO = table.Column<string>(nullable: true, defaultValue: "no inserted"),
                    FeederID = table.Column<int>(nullable: false, defaultValue: 0),
                    Switch_Number = table.Column<string>(nullable: true),
                    Switch_Name = table.Column<string>(nullable: true),
                    Switch_Type = table.Column<string>(nullable: true),
                    FEEDER_TYPE = table.Column<string>(nullable: true),
                    Switch_Make = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Cable_Status = table.Column<string>(nullable: true),
                    UFR_SW = table.Column<string>(nullable: true),
                    Stage_A = table.Column<string>(nullable: true),
                    Stage_B = table.Column<string>(nullable: true),
                    S1 = table.Column<string>(nullable: true),
                    S2 = table.Column<string>(nullable: true),
                    S3 = table.Column<string>(nullable: true),
                    S4 = table.Column<string>(nullable: true),
                    S5 = table.Column<string>(nullable: true),
                    S6 = table.Column<string>(nullable: true),
                    S7 = table.Column<string>(nullable: true),
                    S8 = table.Column<string>(nullable: true),
                    S9 = table.Column<string>(nullable: true),
                    S10 = table.Column<string>(nullable: true),
                    S11 = table.Column<string>(nullable: true),
                    CAP_OK_MVAR = table.Column<decimal>(nullable: false),
                    CAP_MVAR = table.Column<decimal>(nullable: false),
                    dataAddedDateTime = table.Column<DateTime>(nullable: false),
                    dataAddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterData", x => x.MasterDataSNO);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    userRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRoleDesc = table.Column<string>(nullable: true),
                    userRoleAddDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.userRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    userRoleID = table.Column<int>(nullable: false),
                    userAddedby = table.Column<int>(nullable: false),
                    userAddedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleID", "userRoleAddDateTime", "userRoleDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 2, 14, 51, 5, 291, DateTimeKind.Local).AddTicks(8364), "System" },
                    { 2, new DateTime(2021, 2, 2, 14, 51, 5, 291, DateTimeKind.Local).AddTicks(9911), "Admin" },
                    { 3, new DateTime(2021, 2, 2, 14, 51, 5, 291, DateTimeKind.Local).AddTicks(9954), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "userAddedDate", "userAddedby", "userName", "userPassword", "userRoleID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 2, 14, 51, 5, 287, DateTimeKind.Local).AddTicks(3003), 1, "Admin", "Admin", 2 },
                    { 2, new DateTime(2021, 2, 2, 14, 51, 5, 288, DateTimeKind.Local).AddTicks(8031), 1, "user2", "user2", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveloadShedding");

            migrationBuilder.DropTable(
                name: "ArchiveMasterData");

            migrationBuilder.DropTable(
                name: "loadShedding");

            migrationBuilder.DropTable(
                name: "MasterData");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
