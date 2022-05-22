using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacementTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CottageNumber = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Сottages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сottages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сottages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CottageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placements_Сottages_CottageId",
                        column: x => x.CottageId,
                        principalTable: "Сottages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Placements_PlacementTypes_PlacementTypeId",
                        column: x => x.PlacementTypeId,
                        principalTable: "PlacementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorValue = table.Column<float>(type: "real", nullable: false),
                    ChangeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Placements_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "Placements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PlacementTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2"), "Heating" },
                    { new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806"), "Kitchen" },
                    { new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca"), "Hall" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1"), "person" },
                    { new Guid("c9f6fb8b-0923-49a8-a1ef-31a9d5030ff5"), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CottageNumber", "FirstName", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("011d8ee1-6bd8-4056-9529-b0c2d7656e40"), 23, "First name 23", "Last name", "person23", "person23", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("0aa9d8bc-04b3-4161-8485-a5228d7bdc73"), 70, "First name 70", "Last name", "person70", "person70", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("0dddf25b-136c-4f6a-b7cf-2c0fb4da1360"), 48, "First name 48", "Last name", "person48", "person48", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("10077bf4-5c55-4d91-806f-57f1b84512c5"), 27, "First name 27", "Last name", "person27", "person27", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("10504a91-adb3-4b55-8044-c91b9d8911f8"), 30, "First name 30", "Last name", "person30", "person30", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("12c16d1f-36e2-4d95-92ad-7958d17ae9d2"), 15, "First name 15", "Last name", "person15", "person15", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("1368259b-e16b-4658-96bb-c9b281dd3b60"), 33, "First name 33", "Last name", "person33", "person33", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("14196f33-955e-4890-9f53-014302f09c67"), 84, "First name 84", "Last name", "person84", "person84", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("1542fcd2-439c-4add-94f3-d7cefbbc24c4"), 16, "First name 16", "Last name", "person16", "person16", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("16659330-a034-40b5-a123-2b76a5dc8cad"), 36, "First name 36", "Last name", "person36", "person36", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("166a0598-16da-47cc-a0d2-8d5f7743a08c"), 3, "First name 3", "Last name", "person3", "person3", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("18eda7e3-ec71-4289-bcb5-d314a53e8415"), 13, "First name 13", "Last name", "person13", "person13", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("1b1e960c-3ea1-4de1-bd50-d7841ffafdde"), 85, "First name 85", "Last name", "person85", "person85", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("1b8cf7a6-a3c5-49bd-a5d0-9b2be848f81e"), 96, "First name 96", "Last name", "person96", "person96", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("1c0f3c61-16ac-41a7-a750-46c89dcf9ad6"), 98, "First name 98", "Last name", "person98", "person98", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("20f4319a-c6c9-4e32-a3e0-d54bbfa08775"), 52, "First name 52", "Last name", "person52", "person52", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("21d5ae52-c4d8-4a5d-8e4e-7edfe11ba033"), 73, "First name 73", "Last name", "person73", "person73", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("255f7d3c-724d-49d0-8700-8767b302baa4"), 47, "First name 47", "Last name", "person47", "person47", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("26690d67-605b-4370-b4da-d4943725d6c5"), 43, "First name 43", "Last name", "person43", "person43", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("26eff59b-b531-45d1-8d92-9df4a0b7f050"), 66, "First name 66", "Last name", "person66", "person66", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("29cf9aae-d4a6-468f-97fd-5a735f3e0be7"), 5, "First name 5", "Last name", "person5", "person5", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("2a396e24-8166-4ef6-afb0-1f5b19cd4b90"), 34, "First name 34", "Last name", "person34", "person34", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("2f3ad876-9637-4fa1-921e-2f8ef0074ebf"), 80, "First name 80", "Last name", "person80", "person80", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("314287f6-f52c-4f92-9f7a-86e89d2f1514"), 69, "First name 69", "Last name", "person69", "person69", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("36322284-a54c-4a7b-915d-8b70ea89fd45"), 79, "First name 79", "Last name", "person79", "person79", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("3a4badd9-a094-4c09-bcde-0a72ea68d0e1"), 78, "First name 78", "Last name", "person78", "person78", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("3f53fa34-5e9b-4e26-a033-b16882744a3a"), 75, "First name 75", "Last name", "person75", "person75", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("435f6da3-083c-4c89-9f8d-4467aac8d77d"), 99, "First name 99", "Last name", "person99", "person99", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("44b052ba-c1d2-4b5a-a856-c4b73f20a4d7"), 63, "First name 63", "Last name", "person63", "person63", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("471b932c-ad80-4a36-8f13-4a1997293b9f"), 55, "First name 55", "Last name", "person55", "person55", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("47f81bac-5757-442e-9313-27ce0b495145"), 9, "First name 9", "Last name", "person9", "person9", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("482cfd84-fd25-4f7b-b4d4-a1cafc8275d3"), 57, "First name 57", "Last name", "person57", "person57", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("4af0f44f-b880-49d6-ae06-948373f7d9b2"), 93, "First name 93", "Last name", "person93", "person93", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("4b8a8977-dbbc-4dd4-bf11-89fa1dbf9fc2"), 7, "First name 7", "Last name", "person7", "person7", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("4c09ced3-74cd-4a1f-936f-15bc2967e3fe"), 97, "First name 97", "Last name", "person97", "person97", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("54f8c3f1-4796-41da-9a89-024a59827a08"), 29, "First name 29", "Last name", "person29", "person29", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("592a26df-4028-4d2d-be2a-c803b557c2cd"), 26, "First name 26", "Last name", "person26", "person26", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("594a23bc-39e1-4781-b446-5c7f6cca8b6e"), 65, "First name 65", "Last name", "person65", "person65", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("5b6e9f0c-5151-4de1-8d1f-fd484f473599"), 12, "First name 12", "Last name", "person12", "person12", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("5cb31074-4b73-467e-9322-0e156c4e1b90"), 92, "First name 92", "Last name", "person92", "person92", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("622f764e-4f09-48ba-9fc8-1027cba910ba"), 44, "First name 44", "Last name", "person44", "person44", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("659d01cf-679a-4ba5-9024-c49e7ead6151"), 86, "First name 86", "Last name", "person86", "person86", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CottageNumber", "FirstName", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("66423f4c-08c3-4f21-a85b-a73348b86c8e"), 14, "First name 14", "Last name", "person14", "person14", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("68dd97cd-999e-44a1-8f4e-8c8cc96eef2e"), 91, "First name 91", "Last name", "person91", "person91", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("6fe9b8d0-8425-4c0a-9ec2-29c7dd94638c"), 100, "First name 100", "Last name", "person100", "person100", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("706ba184-6cbc-438d-9ef0-7534f4c95855"), 45, "First name 45", "Last name", "person45", "person45", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("77b5011d-3a61-4d51-ae60-770889264e98"), 35, "First name 35", "Last name", "person35", "person35", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("7e7d4c37-a72d-40e1-896a-d47d0248c754"), 22, "First name 22", "Last name", "person22", "person22", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("7ea2d119-c282-4735-bd70-d3ca36a90b22"), 31, "First name 31", "Last name", "person31", "person31", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("800d49f2-8fad-43ba-9d38-93b22de4dc17"), 59, "First name 59", "Last name", "person59", "person59", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("81b1d161-a71b-4b21-affd-4d253456ab0e"), 39, "First name 39", "Last name", "person39", "person39", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("83c3cde0-ff4a-41de-bd03-1748786d811a"), 71, "First name 71", "Last name", "person71", "person71", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("8660fba0-db1b-46bf-b5fa-0c4ffba13808"), 51, "First name 51", "Last name", "person51", "person51", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("86f2550c-a14f-4765-88a8-0252373fff87"), 6, "First name 6", "Last name", "person6", "person6", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("890a61e9-999d-44b2-a745-aad7e237d203"), 82, "First name 82", "Last name", "person82", "person82", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("8ceb731f-7a6f-4da3-9686-ea7df4780918"), 2, "First name 2", "Last name", "person2", "person2", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("932c5924-cfc1-4109-a276-906f4d0d2330"), 90, "First name 90", "Last name", "person90", "person90", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("944fecf7-26d9-4014-8a1b-326704081d85"), 19, "First name 19", "Last name", "person19", "person19", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("970aacb2-6387-49d8-80ee-0fad576eafc4"), 46, "First name 46", "Last name", "person46", "person46", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("9a719f5e-f8bd-4d51-ae36-64748206e337"), 61, "First name 61", "Last name", "person61", "person61", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("9f5a4dbe-b225-464a-a95d-439eb47bc5e4"), 17, "First name 17", "Last name", "person17", "person17", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("a12d1244-ee2a-4dfc-8bb0-0aaf763d92aa"), 72, "First name 72", "Last name", "person72", "person72", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("a1a0da24-d482-44d0-b6d6-db142e433b26"), 41, "First name 41", "Last name", "person41", "person41", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("a1e33de9-b71f-4491-8cc1-6a9a8fc2f668"), 60, "First name 60", "Last name", "person60", "person60", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("a9009562-bbe6-463e-8a40-05f41e25e693"), 81, "First name 81", "Last name", "person81", "person81", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("aa54fa1a-7336-45f2-a43b-ffdb8a4507ac"), 68, "First name 68", "Last name", "person68", "person68", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("ad4207ec-74cf-41b1-8a45-4674087654df"), 24, "First name 24", "Last name", "person24", "person24", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("af1bd29b-5d85-491b-9bf6-bbf6439dc078"), 18, "First name 18", "Last name", "person18", "person18", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("afebc6bf-0ae2-4ffc-b8c5-0aac0894ba61"), 83, "First name 83", "Last name", "person83", "person83", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b1c6116f-a4b6-4fa7-8cd8-8acac6d9804b"), 37, "First name 37", "Last name", "person37", "person37", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b3240b01-4a57-4f78-9478-9d4cde031f6f"), 28, "First name 28", "Last name", "person28", "person28", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b38a7d82-651c-4070-b324-403c0fe11b47"), 77, "First name 77", "Last name", "person77", "person77", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b65d22ed-9ca5-49b2-b32b-87beb5c9967d"), 21, "First name 21", "Last name", "person21", "person21", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b78215cf-dfb4-4345-8694-8a8c958957f3"), 49, "First name 49", "Last name", "person49", "person49", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("b7fee639-ff6e-44e8-b244-4f61aac0f139"), 20, "First name 20", "Last name", "person20", "person20", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("bb55e877-45a8-4658-8e29-ed1b251896ac"), 88, "First name 88", "Last name", "person88", "person88", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c132a9f3-c1e2-4481-96a7-a417a2f2c7a3"), 32, "First name 32", "Last name", "person32", "person32", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c1346b5d-27f8-4fc8-a8ea-08cfdc9116b8"), 4, "First name 4", "Last name", "person4", "person4", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c222aa7d-3ff5-4e4c-85fa-9779e3e87fa3"), 58, "First name 58", "Last name", "person58", "person58", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c6aa5538-de43-48c3-bbfb-ec2ba221c993"), 25, "First name 25", "Last name", "person25", "person25", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c7fb4aa7-bc25-4415-b014-a72cde185378"), 11, "First name 11", "Last name", "person11", "person11", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("c8f3d895-7ea6-4cd6-8038-e9ac393bc39e"), 38, "First name 38", "Last name", "person38", "person38", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("ca23b3ec-b079-4344-a562-4f5311e3f9d5"), 95, "First name 95", "Last name", "person95", "person95", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("ce47034c-1d83-460e-9281-dc0a14354371"), 94, "First name 94", "Last name", "person94", "person94", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CottageNumber", "FirstName", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("cebc52fc-5845-4879-8c89-7b9cfe44cb01"), 67, "First name 67", "Last name", "person67", "person67", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("cebca19f-7e0e-4209-adae-dc1a42bcbd16"), 1, "First name 1", "Last name", "person1", "person1", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("dcdb3b58-47e6-4776-8e22-314cc011add8"), 8, "First name 8", "Last name", "person8", "person8", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e5343949-96c3-4509-bd4a-25ddf1604352"), 76, "First name 76", "Last name", "person76", "person76", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e6c935e3-f67c-4f2b-8a8a-fffc26906fc8"), 74, "First name 74", "Last name", "person74", "person74", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e80fb427-62f8-4142-842b-0c989969534a"), 10, "First name 10", "Last name", "person10", "person10", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e8fdeeee-fc47-4c34-bbe8-3fa9b05fc0d0"), 54, "First name 54", "Last name", "person54", "person54", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e90ed2bf-a8f9-497a-b3de-c772bdf57a19"), 64, "First name 64", "Last name", "person64", "person64", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("e98c03bd-fae5-4359-8970-c45671f14fb1"), 40, "First name 40", "Last name", "person40", "person40", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("ecfa77de-2272-4c3b-8023-d15b0a862991"), 0, "Admin first name", "Admin last name", "admin", "admin", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("eef4fb79-0762-42a1-bd51-8a268e37fe9c"), 50, "First name 50", "Last name", "person50", "person50", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("f035e2b3-05fe-4120-90f5-d1ee563dea29"), 87, "First name 87", "Last name", "person87", "person87", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("f1c119f5-3178-4857-a6f4-c68c1c5621a8"), 62, "First name 62", "Last name", "person62", "person62", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("f60d2520-c0b4-4a81-a0ac-4045d604b3a8"), 56, "First name 56", "Last name", "person56", "person56", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("f745dfb5-bf5a-491d-b6dc-881076fd8a62"), 89, "First name 89", "Last name", "person89", "person89", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("f7b5b502-2e85-4b11-8945-8a25581b9daf"), 42, "First name 42", "Last name", "person42", "person42", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") },
                    { new Guid("fa27dd00-53b0-493d-a39d-bc1726f8b0b8"), 53, "First name 53", "Last name", "person53", "person53", new Guid("c8c6c5b9-cbdb-4105-b5d4-516a9779e7d1") }
                });

            migrationBuilder.InsertData(
                table: "Сottages",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[,]
                {
                    { new Guid("05e0e99b-ba3d-4744-81db-6d46b77c3e4c"), 55, new Guid("471b932c-ad80-4a36-8f13-4a1997293b9f") },
                    { new Guid("06b0be25-79ab-4229-a8b4-1877e3d41885"), 96, new Guid("1b8cf7a6-a3c5-49bd-a5d0-9b2be848f81e") },
                    { new Guid("07b5d54f-1e03-41af-83cd-c0d749fe4f6e"), 5, new Guid("29cf9aae-d4a6-468f-97fd-5a735f3e0be7") },
                    { new Guid("09301a47-09dc-4bd1-99f8-afdaff8186f4"), 51, new Guid("8660fba0-db1b-46bf-b5fa-0c4ffba13808") },
                    { new Guid("0bc7658b-e220-42df-8428-afdb1886979a"), 74, new Guid("e6c935e3-f67c-4f2b-8a8a-fffc26906fc8") },
                    { new Guid("0df84fd1-fe35-471c-8348-674aa04d9929"), 21, new Guid("b65d22ed-9ca5-49b2-b32b-87beb5c9967d") },
                    { new Guid("101eb882-19b1-4571-979f-257e5875c43f"), 1, new Guid("cebca19f-7e0e-4209-adae-dc1a42bcbd16") },
                    { new Guid("1220551a-2e8e-486e-8172-c3a0f7f1430a"), 85, new Guid("1b1e960c-3ea1-4de1-bd50-d7841ffafdde") },
                    { new Guid("16d7ed05-0eaa-4768-8aa0-7a2332c7384b"), 91, new Guid("68dd97cd-999e-44a1-8f4e-8c8cc96eef2e") },
                    { new Guid("17754776-07eb-47e3-b449-f33d0ef41338"), 2, new Guid("8ceb731f-7a6f-4da3-9686-ea7df4780918") },
                    { new Guid("1ad23a96-a0ab-4367-8f01-963dbb2768cd"), 26, new Guid("592a26df-4028-4d2d-be2a-c803b557c2cd") },
                    { new Guid("1adfb27c-ce48-4126-a318-de2a3063a051"), 83, new Guid("afebc6bf-0ae2-4ffc-b8c5-0aac0894ba61") },
                    { new Guid("1cbdba42-49c9-4a70-9d40-0454b408d360"), 43, new Guid("26690d67-605b-4370-b4da-d4943725d6c5") },
                    { new Guid("1fb6f050-a370-4115-94c8-1b3956ede2e4"), 48, new Guid("0dddf25b-136c-4f6a-b7cf-2c0fb4da1360") },
                    { new Guid("23f84e93-2b3c-4c27-aa77-bfb970d99936"), 34, new Guid("2a396e24-8166-4ef6-afb0-1f5b19cd4b90") },
                    { new Guid("23fd0a81-a0bc-4bdf-b40e-cdebd1886e99"), 31, new Guid("7ea2d119-c282-4735-bd70-d3ca36a90b22") },
                    { new Guid("247d1f6a-16ed-4882-aca9-40a5c19fc8d1"), 47, new Guid("255f7d3c-724d-49d0-8700-8767b302baa4") },
                    { new Guid("24e1e632-cfad-4279-9966-63d20da4407a"), 40, new Guid("e98c03bd-fae5-4359-8970-c45671f14fb1") },
                    { new Guid("25e1c95a-0eed-418f-b25c-4d61a791bd8c"), 33, new Guid("1368259b-e16b-4658-96bb-c9b281dd3b60") },
                    { new Guid("2fb8bd1e-947a-4501-88de-32c3d1b4a444"), 78, new Guid("3a4badd9-a094-4c09-bcde-0a72ea68d0e1") },
                    { new Guid("34288d2c-5436-4cb8-8fdb-0ff4e0630681"), 54, new Guid("e8fdeeee-fc47-4c34-bbe8-3fa9b05fc0d0") },
                    { new Guid("35b821b1-5741-470a-aadb-5b74d1b70be3"), 99, new Guid("435f6da3-083c-4c89-9f8d-4467aac8d77d") },
                    { new Guid("42fb82ff-13aa-4f24-9476-83f951240c9f"), 79, new Guid("36322284-a54c-4a7b-915d-8b70ea89fd45") },
                    { new Guid("44515f96-748c-4f10-96f5-f34db439b96a"), 15, new Guid("12c16d1f-36e2-4d95-92ad-7958d17ae9d2") },
                    { new Guid("47384ac3-6dd1-49ee-937a-783ab754745c"), 70, new Guid("0aa9d8bc-04b3-4161-8485-a5228d7bdc73") },
                    { new Guid("47f661a7-bc46-4f23-9c60-e321003253d7"), 59, new Guid("800d49f2-8fad-43ba-9d38-93b22de4dc17") },
                    { new Guid("4bc07c0d-5a18-42f1-abab-95e234d14dde"), 45, new Guid("706ba184-6cbc-438d-9ef0-7534f4c95855") },
                    { new Guid("4cc953a5-44ca-4636-9231-1b78332b5c0b"), 16, new Guid("1542fcd2-439c-4add-94f3-d7cefbbc24c4") },
                    { new Guid("4d995bf2-26cd-4e17-87d2-d481d887f0a0"), 60, new Guid("a1e33de9-b71f-4491-8cc1-6a9a8fc2f668") },
                    { new Guid("4dc52f1e-b5f1-4bdc-b03d-dac1c925a7ed"), 89, new Guid("f745dfb5-bf5a-491d-b6dc-881076fd8a62") },
                    { new Guid("50222c52-78fd-47f8-b59e-a25dbbe773ea"), 8, new Guid("dcdb3b58-47e6-4776-8e22-314cc011add8") },
                    { new Guid("511d8e95-675f-4c21-bc30-d0c040f2f8fc"), 32, new Guid("c132a9f3-c1e2-4481-96a7-a417a2f2c7a3") },
                    { new Guid("529878fe-2663-4735-b20c-de2ba6d77ff6"), 49, new Guid("b78215cf-dfb4-4345-8694-8a8c958957f3") },
                    { new Guid("54af5931-b4f0-4584-adcf-7a7c6d1e0034"), 11, new Guid("c7fb4aa7-bc25-4415-b014-a72cde185378") },
                    { new Guid("58aa4907-650c-4ab3-8792-d4c9cb8fa973"), 64, new Guid("e90ed2bf-a8f9-497a-b3de-c772bdf57a19") },
                    { new Guid("591e5261-4948-42be-9ae0-be315f1a6ed9"), 61, new Guid("9a719f5e-f8bd-4d51-ae36-64748206e337") },
                    { new Guid("592066b8-ce64-4059-a250-da111ea92ea2"), 6, new Guid("86f2550c-a14f-4765-88a8-0252373fff87") },
                    { new Guid("5b76bac1-3053-4a47-a6d3-8a09381fe399"), 66, new Guid("26eff59b-b531-45d1-8d92-9df4a0b7f050") },
                    { new Guid("5c9c38cf-dea2-4e89-b32e-0124dc724fe8"), 57, new Guid("482cfd84-fd25-4f7b-b4d4-a1cafc8275d3") },
                    { new Guid("5ebaa817-f406-4578-bba8-783b7d40d7a3"), 77, new Guid("b38a7d82-651c-4070-b324-403c0fe11b47") },
                    { new Guid("603ab051-e797-473d-9666-c9aeb2b25a9e"), 72, new Guid("a12d1244-ee2a-4dfc-8bb0-0aaf763d92aa") },
                    { new Guid("6157468e-1168-4f66-a90b-af202b1539f0"), 38, new Guid("c8f3d895-7ea6-4cd6-8038-e9ac393bc39e") }
                });

            migrationBuilder.InsertData(
                table: "Сottages",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[,]
                {
                    { new Guid("62e0cfcc-8022-445f-a384-5365d1c4806c"), 27, new Guid("10077bf4-5c55-4d91-806f-57f1b84512c5") },
                    { new Guid("6386e02e-71c5-47b7-a6a9-a5b015d89794"), 22, new Guid("7e7d4c37-a72d-40e1-896a-d47d0248c754") },
                    { new Guid("63d6b00d-49d2-4620-85d7-ca24fa15c827"), 100, new Guid("6fe9b8d0-8425-4c0a-9ec2-29c7dd94638c") },
                    { new Guid("64c15571-9f8c-4c31-896f-eea412a98fce"), 4, new Guid("c1346b5d-27f8-4fc8-a8ea-08cfdc9116b8") },
                    { new Guid("69781624-ee0d-440d-b950-dcf9c423d23a"), 69, new Guid("314287f6-f52c-4f92-9f7a-86e89d2f1514") },
                    { new Guid("6befd9a4-8ad2-420d-9430-b6ae6c5b26fc"), 67, new Guid("cebc52fc-5845-4879-8c89-7b9cfe44cb01") },
                    { new Guid("6f47dca3-866a-42d7-9c71-38e68fbe3d3a"), 65, new Guid("594a23bc-39e1-4781-b446-5c7f6cca8b6e") },
                    { new Guid("712cb11b-02a5-423e-bd97-743ebb9026bd"), 12, new Guid("5b6e9f0c-5151-4de1-8d1f-fd484f473599") },
                    { new Guid("71c9870d-0e47-4b66-8f3e-e6b24d89276a"), 23, new Guid("011d8ee1-6bd8-4056-9529-b0c2d7656e40") },
                    { new Guid("739df710-cc24-49d1-a339-a1603eb1a378"), 37, new Guid("b1c6116f-a4b6-4fa7-8cd8-8acac6d9804b") },
                    { new Guid("76ff08b8-7ef2-4eaf-b2e3-e2e962e3ea4b"), 58, new Guid("c222aa7d-3ff5-4e4c-85fa-9779e3e87fa3") },
                    { new Guid("7a28e237-06d4-4893-ba7d-5beb5ddf0af4"), 29, new Guid("54f8c3f1-4796-41da-9a89-024a59827a08") },
                    { new Guid("7b3c5e85-722b-479d-9a6b-e59e2783edc6"), 39, new Guid("81b1d161-a71b-4b21-affd-4d253456ab0e") },
                    { new Guid("7b4020bd-e589-40d3-b626-ce1b5416d6d1"), 19, new Guid("944fecf7-26d9-4014-8a1b-326704081d85") },
                    { new Guid("7d02c671-c284-4af0-94dd-1c791b9f1d6c"), 75, new Guid("3f53fa34-5e9b-4e26-a033-b16882744a3a") },
                    { new Guid("7ed53024-c508-44ba-bf88-98dfa744cf8f"), 84, new Guid("14196f33-955e-4890-9f53-014302f09c67") },
                    { new Guid("801495ab-45f2-427d-bd26-61d429516667"), 88, new Guid("bb55e877-45a8-4658-8e29-ed1b251896ac") },
                    { new Guid("80888b45-89a9-4d94-89db-c8b3dd30daed"), 63, new Guid("44b052ba-c1d2-4b5a-a856-c4b73f20a4d7") },
                    { new Guid("8679fc50-ce09-4223-9ecc-3dfdc5691db1"), 73, new Guid("21d5ae52-c4d8-4a5d-8e4e-7edfe11ba033") },
                    { new Guid("8f7f3310-d0c5-48d9-aa60-cd6cec6b46df"), 68, new Guid("aa54fa1a-7336-45f2-a43b-ffdb8a4507ac") },
                    { new Guid("904761c7-05ab-40d1-8ee6-24f4b9baa729"), 7, new Guid("4b8a8977-dbbc-4dd4-bf11-89fa1dbf9fc2") },
                    { new Guid("9287d01b-ac63-4a96-ba87-11424189a4cd"), 35, new Guid("77b5011d-3a61-4d51-ae60-770889264e98") },
                    { new Guid("94bf5b6a-5b47-448c-a209-b2bc585bc1c8"), 97, new Guid("4c09ced3-74cd-4a1f-936f-15bc2967e3fe") },
                    { new Guid("9752e1ee-a10a-4aaf-9f34-f270ed99900f"), 71, new Guid("83c3cde0-ff4a-41de-bd03-1748786d811a") },
                    { new Guid("9f68c865-62e9-4a88-bd90-41860851c67c"), 53, new Guid("fa27dd00-53b0-493d-a39d-bc1726f8b0b8") },
                    { new Guid("a0dc7272-d3fd-4e27-9949-e372841e1d80"), 98, new Guid("1c0f3c61-16ac-41a7-a750-46c89dcf9ad6") },
                    { new Guid("a38316a9-ccd2-4752-9084-0df4312243d1"), 92, new Guid("5cb31074-4b73-467e-9322-0e156c4e1b90") },
                    { new Guid("a544fa61-71d0-4ecf-b6bd-d149c050c5d4"), 50, new Guid("eef4fb79-0762-42a1-bd51-8a268e37fe9c") },
                    { new Guid("a7902d1c-a1d6-418f-bcae-71cd9aa4d005"), 87, new Guid("f035e2b3-05fe-4120-90f5-d1ee563dea29") },
                    { new Guid("a938d50d-e137-4617-a77f-b6fa4bb73d23"), 56, new Guid("f60d2520-c0b4-4a81-a0ac-4045d604b3a8") },
                    { new Guid("ac65557b-eaf7-4998-b3ad-8a944110803c"), 30, new Guid("10504a91-adb3-4b55-8044-c91b9d8911f8") },
                    { new Guid("afcd6bba-fe90-4b1d-a138-4cccdbf990e4"), 18, new Guid("af1bd29b-5d85-491b-9bf6-bbf6439dc078") },
                    { new Guid("b24f4555-556a-423b-8c99-dcdfd74e1e54"), 13, new Guid("18eda7e3-ec71-4289-bcb5-d314a53e8415") },
                    { new Guid("b2f47d49-d3fa-49e9-ae43-7b8b8dc64b55"), 76, new Guid("e5343949-96c3-4509-bd4a-25ddf1604352") },
                    { new Guid("b9df28d1-d892-4862-b706-5d4a523173c8"), 25, new Guid("c6aa5538-de43-48c3-bbfb-ec2ba221c993") },
                    { new Guid("bfe6906f-9b0e-48b1-8da7-14ba0c504df7"), 93, new Guid("4af0f44f-b880-49d6-ae06-948373f7d9b2") },
                    { new Guid("c4f58319-dcb8-4aea-ae82-9616b1687f47"), 41, new Guid("a1a0da24-d482-44d0-b6d6-db142e433b26") },
                    { new Guid("c52b34a7-820f-42f4-883a-bf8e96861a85"), 95, new Guid("ca23b3ec-b079-4344-a562-4f5311e3f9d5") },
                    { new Guid("c8be91e0-5049-42b2-b864-a93e2a025ba8"), 42, new Guid("f7b5b502-2e85-4b11-8945-8a25581b9daf") },
                    { new Guid("ce1da22f-d71f-4167-b25e-39f0283c7b30"), 17, new Guid("9f5a4dbe-b225-464a-a95d-439eb47bc5e4") },
                    { new Guid("d2e7dda4-cf36-49fe-b880-48fe0adf8327"), 81, new Guid("a9009562-bbe6-463e-8a40-05f41e25e693") },
                    { new Guid("d3235a6f-99f6-4483-a361-ab827fe6420d"), 86, new Guid("659d01cf-679a-4ba5-9024-c49e7ead6151") }
                });

            migrationBuilder.InsertData(
                table: "Сottages",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[,]
                {
                    { new Guid("d35b7108-19ed-4615-b342-8db70c0a1d87"), 36, new Guid("16659330-a034-40b5-a123-2b76a5dc8cad") },
                    { new Guid("d36277c1-8d01-4768-9cb7-749c3158ff12"), 10, new Guid("e80fb427-62f8-4142-842b-0c989969534a") },
                    { new Guid("d464c93a-1aae-4804-91c0-b9b2f7bae7b3"), 90, new Guid("932c5924-cfc1-4109-a276-906f4d0d2330") },
                    { new Guid("d51344ac-5911-4ace-baaf-c34d89f853bd"), 3, new Guid("166a0598-16da-47cc-a0d2-8d5f7743a08c") },
                    { new Guid("d9f3516a-7831-4acf-8972-5c1efdf9750e"), 46, new Guid("970aacb2-6387-49d8-80ee-0fad576eafc4") },
                    { new Guid("db829be3-7f29-4511-8d8f-89f820b44288"), 80, new Guid("2f3ad876-9637-4fa1-921e-2f8ef0074ebf") },
                    { new Guid("dba56e98-53e8-4646-9b41-d55bbbccd45f"), 14, new Guid("66423f4c-08c3-4f21-a85b-a73348b86c8e") },
                    { new Guid("de824e8c-4295-4143-8af8-edb40c58dc24"), 28, new Guid("b3240b01-4a57-4f78-9478-9d4cde031f6f") },
                    { new Guid("e55cacac-6bee-442c-b5ce-49ded79b14b1"), 44, new Guid("622f764e-4f09-48ba-9fc8-1027cba910ba") },
                    { new Guid("e75554f9-588d-40da-ba1d-9086159f99ff"), 24, new Guid("ad4207ec-74cf-41b1-8a45-4674087654df") },
                    { new Guid("ea948d44-0b4c-42b0-a35b-932123e03de0"), 94, new Guid("ce47034c-1d83-460e-9281-dc0a14354371") },
                    { new Guid("ec4effef-d499-4fe4-be3e-0fd32bc09262"), 9, new Guid("47f81bac-5757-442e-9313-27ce0b495145") },
                    { new Guid("f065bda6-44b4-403e-b5f3-ba54c21ed9c5"), 52, new Guid("20f4319a-c6c9-4e32-a3e0-d54bbfa08775") },
                    { new Guid("f26daabe-09e1-42e6-b946-c29630112656"), 82, new Guid("890a61e9-999d-44b2-a745-aad7e237d203") },
                    { new Guid("f6eae055-0910-4933-8c9e-a20850f861a7"), 62, new Guid("f1c119f5-3178-4857-a6f4-c68c1c5621a8") },
                    { new Guid("fd753b78-3bd7-4c4b-a7b3-f0b2355a3e05"), 20, new Guid("b7fee639-ff6e-44e8-b244-4f61aac0f139") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("004c39b9-8df6-4a76-bca1-94b76f1afeda"), new Guid("f065bda6-44b4-403e-b5f3-ba54c21ed9c5"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("012bbe9b-4030-49c5-88ed-7cd9cab860a6"), new Guid("dba56e98-53e8-4646-9b41-d55bbbccd45f"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("0213370b-3ff0-4c7a-93d1-ebcd2d9f3ccd"), new Guid("5b76bac1-3053-4a47-a6d3-8a09381fe399"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("03daddbd-b732-4d88-af97-0103f16da2a9"), new Guid("80888b45-89a9-4d94-89db-c8b3dd30daed"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("04b36dce-b413-4c95-bab6-3ec02a40713b"), new Guid("529878fe-2663-4735-b20c-de2ba6d77ff6"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("06bdf98c-cf01-4c4c-b06f-041a9c77cffa"), new Guid("603ab051-e797-473d-9666-c9aeb2b25a9e"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("07816c2e-c5e3-4371-9848-b7f70413682f"), new Guid("35b821b1-5741-470a-aadb-5b74d1b70be3"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("07b96e53-f933-447c-8b0c-c3771e50977e"), new Guid("a7902d1c-a1d6-418f-bcae-71cd9aa4d005"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("0861cffe-19b4-4450-b213-cc87559d72e5"), new Guid("247d1f6a-16ed-4882-aca9-40a5c19fc8d1"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("090530f0-cd5d-4b2e-ac03-d3e56ae75295"), new Guid("a938d50d-e137-4617-a77f-b6fa4bb73d23"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("095d98f6-cf78-41e3-97f4-651fca6a3f52"), new Guid("e75554f9-588d-40da-ba1d-9086159f99ff"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("0a65c2a7-1617-4364-ac1e-3b267c6158c0"), new Guid("f26daabe-09e1-42e6-b946-c29630112656"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("0c85183d-8dcc-4838-9666-e308b4beaf18"), new Guid("5ebaa817-f406-4578-bba8-783b7d40d7a3"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("0d61ce95-9bdd-4ae9-9041-0f1d8c1c47d5"), new Guid("d3235a6f-99f6-4483-a361-ab827fe6420d"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("0fa63be2-cce2-46cd-986e-cc62ff70e965"), new Guid("42fb82ff-13aa-4f24-9476-83f951240c9f"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("1338642f-79cd-43d0-9cd0-db4896818268"), new Guid("a7902d1c-a1d6-418f-bcae-71cd9aa4d005"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("13c8a99e-68c6-4f1f-8db0-876a16900638"), new Guid("a938d50d-e137-4617-a77f-b6fa4bb73d23"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("13ee55ec-c805-47d8-8038-cab9922e607e"), new Guid("1fb6f050-a370-4115-94c8-1b3956ede2e4"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("15427750-a742-4bfe-9abd-2f02e4972da3"), new Guid("db829be3-7f29-4511-8d8f-89f820b44288"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("15a9cfd3-bfc9-43d1-8381-b3e5aaff8a1d"), new Guid("c8be91e0-5049-42b2-b864-a93e2a025ba8"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("163efe68-d35b-462d-90de-2a88e4bb76da"), new Guid("b24f4555-556a-423b-8c99-dcdfd74e1e54"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("16693336-98b0-4141-9caf-c0ed0cfbb7ac"), new Guid("76ff08b8-7ef2-4eaf-b2e3-e2e962e3ea4b"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("1743d732-2892-4a67-a886-fa06072f9d56"), new Guid("bfe6906f-9b0e-48b1-8da7-14ba0c504df7"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("18e6362d-a2a5-49cf-8e29-70159a47ae4b"), new Guid("ea948d44-0b4c-42b0-a35b-932123e03de0"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("19aae055-60ec-4e94-b22a-a857763494bd"), new Guid("94bf5b6a-5b47-448c-a209-b2bc585bc1c8"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("1a6b12ac-29f7-42c3-9d79-71159ccf4a3c"), new Guid("d464c93a-1aae-4804-91c0-b9b2f7bae7b3"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("1b5afd1d-620a-485b-9919-cfad67d20842"), new Guid("ec4effef-d499-4fe4-be3e-0fd32bc09262"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("1df55dac-d614-4497-88c5-f69db55f6c19"), new Guid("6386e02e-71c5-47b7-a6a9-a5b015d89794"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("1e189537-622d-4756-a6c0-7bafcb2602b0"), new Guid("529878fe-2663-4735-b20c-de2ba6d77ff6"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("1f7be98e-d2ea-40fd-87a5-bc525632c229"), new Guid("e75554f9-588d-40da-ba1d-9086159f99ff"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("20202900-52d6-42f5-9178-584313760662"), new Guid("34288d2c-5436-4cb8-8fdb-0ff4e0630681"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("22312cdb-2883-45c4-b7d5-e776c0885956"), new Guid("591e5261-4948-42be-9ae0-be315f1a6ed9"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("22fadbdc-2fca-4a73-99ac-307784138205"), new Guid("d2e7dda4-cf36-49fe-b880-48fe0adf8327"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("24d44f42-6a1b-4dca-a806-01bb93dad1eb"), new Guid("07b5d54f-1e03-41af-83cd-c0d749fe4f6e"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("27e0229e-0fa3-43bd-b13e-d4b86fa1bb17"), new Guid("69781624-ee0d-440d-b950-dcf9c423d23a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("28c8c136-5a77-471f-984a-3c62727d86b8"), new Guid("afcd6bba-fe90-4b1d-a138-4cccdbf990e4"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("29cf6630-e3ad-48d7-87d2-0c67acd7a7f8"), new Guid("d35b7108-19ed-4615-b342-8db70c0a1d87"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("2a183345-b316-4a47-90bd-3c97850377ac"), new Guid("4cc953a5-44ca-4636-9231-1b78332b5c0b"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("2b32fc0c-1b98-4750-aa02-d5cf4aca91bc"), new Guid("f26daabe-09e1-42e6-b946-c29630112656"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("2b46c276-6f63-40b6-a9a1-97f86e8c9457"), new Guid("4cc953a5-44ca-4636-9231-1b78332b5c0b"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("2bb831cf-49c4-4c69-ad8e-218f0e664ca8"), new Guid("fd753b78-3bd7-4c4b-a7b3-f0b2355a3e05"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("2bde63d3-453a-4ed3-8c90-986cb62f4995"), new Guid("a544fa61-71d0-4ecf-b6bd-d149c050c5d4"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("2e7ded23-b233-47b6-8533-9f942176cf30"), new Guid("0bc7658b-e220-42df-8428-afdb1886979a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("2f47b2f3-36c4-4e9c-9a6d-f9df88e3411b"), new Guid("739df710-cc24-49d1-a339-a1603eb1a378"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("30e58d5d-fd7c-4379-8c1b-8abb3e876063"), new Guid("0bc7658b-e220-42df-8428-afdb1886979a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("337f3f0d-065e-412c-8a9c-77cf5c7ee29e"), new Guid("d2e7dda4-cf36-49fe-b880-48fe0adf8327"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("342ba0d7-c845-44e6-b7d5-403686eee6a5"), new Guid("6157468e-1168-4f66-a90b-af202b1539f0"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("351a4307-2ac9-4269-a33e-75d6f7fe57b8"), new Guid("23f84e93-2b3c-4c27-aa77-bfb970d99936"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("35c55eef-c195-4f43-9fdd-ca8dea8742ce"), new Guid("f6eae055-0910-4933-8c9e-a20850f861a7"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("371bae12-0c84-4231-83f5-775d45a75eb3"), new Guid("7b4020bd-e589-40d3-b626-ce1b5416d6d1"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("372c452b-c0d3-43e2-ad6c-a2076a6b4bfc"), new Guid("06b0be25-79ab-4229-a8b4-1877e3d41885"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("38d12425-926f-401e-b654-746a59ce4f4c"), new Guid("1adfb27c-ce48-4126-a318-de2a3063a051"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("38eb8f8d-bc09-49a7-9a87-54b3f546f5ba"), new Guid("94bf5b6a-5b47-448c-a209-b2bc585bc1c8"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("3a615493-1da3-4618-a7dc-b0490af01d5b"), new Guid("ac65557b-eaf7-4998-b3ad-8a944110803c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("3a917fa3-df45-4613-b901-dcc38a2affa9"), new Guid("5c9c38cf-dea2-4e89-b32e-0124dc724fe8"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("3b16cba4-0082-4754-a758-64dfa6dff6de"), new Guid("50222c52-78fd-47f8-b59e-a25dbbe773ea"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("3ccbadaa-86a1-4443-aebd-6eafcf17c588"), new Guid("511d8e95-675f-4c21-bc30-d0c040f2f8fc"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("3dd2d7ce-246b-4081-9dda-b79ffba5cfb7"), new Guid("54af5931-b4f0-4584-adcf-7a7c6d1e0034"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("3e0c98c1-4801-4580-b146-feaf6d06ca21"), new Guid("58aa4907-650c-4ab3-8792-d4c9cb8fa973"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("3e47dd93-5962-4720-9ba4-89342df9c177"), new Guid("7a28e237-06d4-4893-ba7d-5beb5ddf0af4"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("3f01c190-d3c1-4a36-b52a-35088b346c24"), new Guid("1220551a-2e8e-486e-8172-c3a0f7f1430a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("3ff6c04d-8fc2-4017-9607-ce0a5b739609"), new Guid("603ab051-e797-473d-9666-c9aeb2b25a9e"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("406037eb-938e-4be4-b6b1-f76a2083de12"), new Guid("591e5261-4948-42be-9ae0-be315f1a6ed9"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("4140248d-4c46-44ea-8fcb-e741eaa9e0dc"), new Guid("42fb82ff-13aa-4f24-9476-83f951240c9f"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("432bb492-64d5-4ea9-8817-56c5a42fcb8b"), new Guid("b9df28d1-d892-4862-b706-5d4a523173c8"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("432f36fb-ee54-43fd-8642-e6570673b9c1"), new Guid("9752e1ee-a10a-4aaf-9f34-f270ed99900f"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("437d9efe-48e7-4e67-ab01-fd8e74b69547"), new Guid("47f661a7-bc46-4f23-9c60-e321003253d7"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4400d049-ef5e-471a-9c90-4d992f6d47c9"), new Guid("63d6b00d-49d2-4620-85d7-ca24fa15c827"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("44daeb38-bada-41b3-8f96-23b606d63f70"), new Guid("592066b8-ce64-4059-a250-da111ea92ea2"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("45ae7d7f-39c6-4d56-90ab-99a59537f90c"), new Guid("101eb882-19b1-4571-979f-257e5875c43f"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("4604fb92-5977-4df2-a593-ca1870cddb0d"), new Guid("511d8e95-675f-4c21-bc30-d0c040f2f8fc"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("478fcb2b-8fa9-4f19-a1e8-aabc39e418df"), new Guid("62e0cfcc-8022-445f-a384-5365d1c4806c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("48885af2-5a61-4e4f-a1da-105ca75944e6"), new Guid("801495ab-45f2-427d-bd26-61d429516667"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("48edd72e-0b0e-45f9-b7c5-96eb7f4f2f23"), new Guid("a938d50d-e137-4617-a77f-b6fa4bb73d23"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("4a0fc2d7-0798-4480-9825-2ee1c23fc1c9"), new Guid("24e1e632-cfad-4279-9966-63d20da4407a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4a143b30-61cc-418b-a367-f1d4a4845f28"), new Guid("c4f58319-dcb8-4aea-ae82-9616b1687f47"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4d367a4e-0894-4688-9c74-e674565066c7"), new Guid("0df84fd1-fe35-471c-8348-674aa04d9929"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("4d518ac0-ca83-4d9b-a988-cb046d29d49b"), new Guid("58aa4907-650c-4ab3-8792-d4c9cb8fa973"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4d7c91b2-ac65-47cf-ac8b-af65bfaddd7a"), new Guid("5b76bac1-3053-4a47-a6d3-8a09381fe399"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4e349fa9-0195-46db-af05-6cb4398c608d"), new Guid("6befd9a4-8ad2-420d-9430-b6ae6c5b26fc"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("4f77ea82-07e2-41de-b043-d6dd32548da3"), new Guid("9287d01b-ac63-4a96-ba87-11424189a4cd"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("504562f7-6896-4133-bdea-9eaf57f46328"), new Guid("94bf5b6a-5b47-448c-a209-b2bc585bc1c8"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5106bc19-32fa-4913-afc0-fd0bdf48cfc0"), new Guid("1fb6f050-a370-4115-94c8-1b3956ede2e4"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("519ce6b5-b0ef-4aff-b1aa-e140f6ee0411"), new Guid("0df84fd1-fe35-471c-8348-674aa04d9929"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("52a1cc3c-2ec8-4972-ac19-4b3cab18f09e"), new Guid("50222c52-78fd-47f8-b59e-a25dbbe773ea"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("54e7b7d7-b5bf-45a5-9b46-4280581206c7"), new Guid("5c9c38cf-dea2-4e89-b32e-0124dc724fe8"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("56c3ad72-a9a0-4008-b1a3-440fd66e3598"), new Guid("7ed53024-c508-44ba-bf88-98dfa744cf8f"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("58357c9d-3cba-40c2-bc60-e8d6e81f85c2"), new Guid("d36277c1-8d01-4768-9cb7-749c3158ff12"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("58ea30b2-1b89-41d6-9461-f4b4d12c2bee"), new Guid("e55cacac-6bee-442c-b5ce-49ded79b14b1"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("59992267-47dc-46c9-a986-bd69172131e5"), new Guid("801495ab-45f2-427d-bd26-61d429516667"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("5aa8f9d8-ea8f-4fe0-b569-d75587e89b5a"), new Guid("1220551a-2e8e-486e-8172-c3a0f7f1430a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5ab63ff2-9285-47bb-a79d-eb61606988b0"), new Guid("76ff08b8-7ef2-4eaf-b2e3-e2e962e3ea4b"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5ad82856-3166-41b2-84a1-4e1c72f859ac"), new Guid("62e0cfcc-8022-445f-a384-5365d1c4806c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5b47a444-8d5d-4b3b-92f3-627bd1e38bb2"), new Guid("bfe6906f-9b0e-48b1-8da7-14ba0c504df7"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5cfe56b4-62ae-4ec7-9dc2-0f39917229ba"), new Guid("06b0be25-79ab-4229-a8b4-1877e3d41885"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("5d40a696-f958-48f4-82ea-f56dad875b99"), new Guid("ea948d44-0b4c-42b0-a35b-932123e03de0"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("5e025f29-b281-4259-836f-bb3f1733d09b"), new Guid("35b821b1-5741-470a-aadb-5b74d1b70be3"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("5e53a9a9-9a64-49d3-b498-a5230efe6ef5"), new Guid("34288d2c-5436-4cb8-8fdb-0ff4e0630681"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("5ec986d6-dea3-482d-bf81-a6ac6d71027f"), new Guid("ec4effef-d499-4fe4-be3e-0fd32bc09262"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5f362302-5952-4e4b-85fd-2c74152d02e7"), new Guid("d2e7dda4-cf36-49fe-b880-48fe0adf8327"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("5f4d03fe-5276-4456-a151-26715eef9182"), new Guid("8679fc50-ce09-4223-9ecc-3dfdc5691db1"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("623a10b8-a98d-4020-bc89-f20f0b266150"), new Guid("5ebaa817-f406-4578-bba8-783b7d40d7a3"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("6249fd54-f295-4a17-96cf-ecced96e6a7f"), new Guid("a0dc7272-d3fd-4e27-9949-e372841e1d80"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("62bac3f1-c3d0-435b-bce1-a144b6e19a37"), new Guid("16d7ed05-0eaa-4768-8aa0-7a2332c7384b"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("636eb334-e013-4a02-bb72-5b7cfdd57eae"), new Guid("6157468e-1168-4f66-a90b-af202b1539f0"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("63adac26-d7d5-41a6-82fc-584cea713c06"), new Guid("71c9870d-0e47-4b66-8f3e-e6b24d89276a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("655301c3-22fc-4b06-a9f9-71c91c2dd25d"), new Guid("f065bda6-44b4-403e-b5f3-ba54c21ed9c5"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("65b625a6-36d5-4bf8-b551-dd0518088e76"), new Guid("8679fc50-ce09-4223-9ecc-3dfdc5691db1"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("67983bfb-3241-4669-a29a-c8d91f1bbe1a"), new Guid("23f84e93-2b3c-4c27-aa77-bfb970d99936"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("6878cc8c-269a-4eb1-bbb9-054adfab658f"), new Guid("592066b8-ce64-4059-a250-da111ea92ea2"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("687c7c0c-b90f-4a68-ab4c-4288a9d0cf22"), new Guid("0df84fd1-fe35-471c-8348-674aa04d9929"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("68b0cfc0-9883-4c7c-8de0-f39875fc0ea7"), new Guid("2fb8bd1e-947a-4501-88de-32c3d1b4a444"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("6ae0d759-e64a-428d-b894-2b70ba397814"), new Guid("739df710-cc24-49d1-a339-a1603eb1a378"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("6b9a9cc8-dab4-44f1-8b67-7ca9af51aa68"), new Guid("c52b34a7-820f-42f4-883a-bf8e96861a85"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("6c45bc27-b682-4713-9468-4bd752f45824"), new Guid("1220551a-2e8e-486e-8172-c3a0f7f1430a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("6c6ac71e-f86b-401a-881b-f2ee14b86575"), new Guid("de824e8c-4295-4143-8af8-edb40c58dc24"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("6cf449d8-092f-4e1c-8428-bedaa572cef8"), new Guid("23fd0a81-a0bc-4bdf-b40e-cdebd1886e99"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("6d30affe-85d5-4817-886c-2d34644ba368"), new Guid("ce1da22f-d71f-4167-b25e-39f0283c7b30"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("6fe22370-12f3-4808-a5af-2db3d516620d"), new Guid("e55cacac-6bee-442c-b5ce-49ded79b14b1"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("708595cd-8929-4dca-809c-26d3b5299f31"), new Guid("1cbdba42-49c9-4a70-9d40-0454b408d360"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("709b8e02-ac4c-4506-aca8-3a2e0b528346"), new Guid("ce1da22f-d71f-4167-b25e-39f0283c7b30"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("70bb8cfa-fb17-43bb-8fa9-71b564e8a596"), new Guid("47f661a7-bc46-4f23-9c60-e321003253d7"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("72aae393-9fac-49cd-a893-a400c23467ad"), new Guid("47384ac3-6dd1-49ee-937a-783ab754745c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("74125495-1c7e-4a17-990a-fe938da495f6"), new Guid("4d995bf2-26cd-4e17-87d2-d481d887f0a0"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("75913245-3468-4e98-8c77-995dd937e4e0"), new Guid("ac65557b-eaf7-4998-b3ad-8a944110803c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("77ba404f-23ba-4edc-b055-65c1e93efa07"), new Guid("712cb11b-02a5-423e-bd97-743ebb9026bd"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("782c49c4-ce5f-42c2-b4ef-565c1278a650"), new Guid("9f68c865-62e9-4a88-bd90-41860851c67c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("78550015-92fb-4049-9933-e0a84a8cb326"), new Guid("b2f47d49-d3fa-49e9-ae43-7b8b8dc64b55"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("78f77f6c-9ceb-424d-9ccd-266d906507df"), new Guid("47f661a7-bc46-4f23-9c60-e321003253d7"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("79614a50-d885-4f5e-b68f-af653456ee09"), new Guid("dba56e98-53e8-4646-9b41-d55bbbccd45f"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("79c7a6a8-4254-41f2-adc1-50fa943679a2"), new Guid("d35b7108-19ed-4615-b342-8db70c0a1d87"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("7a631afa-200a-438e-8d02-c7dda20abdc1"), new Guid("63d6b00d-49d2-4620-85d7-ca24fa15c827"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("7aafc80c-bc66-436f-a5bb-31115be20f3b"), new Guid("16d7ed05-0eaa-4768-8aa0-7a2332c7384b"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("7ab18ba8-6493-467b-ab23-e15e5a99a841"), new Guid("7d02c671-c284-4af0-94dd-1c791b9f1d6c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("7b5c03a3-2b71-4c68-b6bb-1998db46bc94"), new Guid("d3235a6f-99f6-4483-a361-ab827fe6420d"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("7d06b548-71d4-44d6-b479-04464ddb1c20"), new Guid("a544fa61-71d0-4ecf-b6bd-d149c050c5d4"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("7e2820a1-35e2-4f3f-9001-17bfa24fc27f"), new Guid("62e0cfcc-8022-445f-a384-5365d1c4806c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("7e634c56-d74f-4e34-aeab-db48331ae76e"), new Guid("c8be91e0-5049-42b2-b864-a93e2a025ba8"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("7f0cc010-d051-4739-9f3f-c7c3e2d122b8"), new Guid("4bc07c0d-5a18-42f1-abab-95e234d14dde"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("7f7d5218-b5bf-4413-a139-c6d03da54564"), new Guid("712cb11b-02a5-423e-bd97-743ebb9026bd"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("7f8aefc4-a0f6-4d4b-9a36-e09b5f248783"), new Guid("603ab051-e797-473d-9666-c9aeb2b25a9e"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("83f1d002-3b4b-469e-a626-b73817678111"), new Guid("4dc52f1e-b5f1-4bdc-b03d-dac1c925a7ed"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("84878eb6-2389-4733-97b7-06ed137539c2"), new Guid("a0dc7272-d3fd-4e27-9949-e372841e1d80"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("848eb3cf-ef89-4532-ad18-4b609851932e"), new Guid("ec4effef-d499-4fe4-be3e-0fd32bc09262"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("858d99e8-ee92-4940-9b8f-b1abe48a2816"), new Guid("44515f96-748c-4f10-96f5-f34db439b96a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("866d0c5b-af80-4d40-8696-949320e7b080"), new Guid("de824e8c-4295-4143-8af8-edb40c58dc24"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("87e696bf-6435-4959-bff6-f9aa7e672a04"), new Guid("54af5931-b4f0-4584-adcf-7a7c6d1e0034"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("8870bd45-63fa-46dd-bec2-1f081519267a"), new Guid("69781624-ee0d-440d-b950-dcf9c423d23a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("89bf4b9a-7774-4b23-8d06-4ddb718f68ae"), new Guid("f26daabe-09e1-42e6-b946-c29630112656"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("8a8acc96-abd3-4985-bf8e-6423f045c14e"), new Guid("25e1c95a-0eed-418f-b25c-4d61a791bd8c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("8c15b64a-e408-4d3e-8c7e-bc865c027885"), new Guid("5c9c38cf-dea2-4e89-b32e-0124dc724fe8"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("8c8b5889-eb6f-4f5e-9475-86b4d9261aee"), new Guid("801495ab-45f2-427d-bd26-61d429516667"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("8cd55929-312c-4fc1-827d-83895dc41689"), new Guid("a7902d1c-a1d6-418f-bcae-71cd9aa4d005"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("8d073e1a-712b-4f6a-a20e-de263aeb66c1"), new Guid("d464c93a-1aae-4804-91c0-b9b2f7bae7b3"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("8d881538-df74-47b1-a55f-4ae394be9f63"), new Guid("09301a47-09dc-4bd1-99f8-afdaff8186f4"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("8ff110d9-a1c4-4f8a-83fe-fd306da73b09"), new Guid("d36277c1-8d01-4768-9cb7-749c3158ff12"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("90975c44-0091-4fba-b22c-95b2d406bf0d"), new Guid("1ad23a96-a0ab-4367-8f01-963dbb2768cd"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("90c1f950-8dc5-452d-b773-0207969d751e"), new Guid("511d8e95-675f-4c21-bc30-d0c040f2f8fc"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("90edb730-379a-48c1-af0d-9ca87d6334f3"), new Guid("24e1e632-cfad-4279-9966-63d20da4407a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("9161b03d-ee93-4a5b-943e-a17cbd3a763c"), new Guid("de824e8c-4295-4143-8af8-edb40c58dc24"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("92989fb7-d3a5-4289-b2bb-61f33f4b6406"), new Guid("0bc7658b-e220-42df-8428-afdb1886979a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("93fa4bf1-be5e-420c-8c38-20a5fe5ee702"), new Guid("09301a47-09dc-4bd1-99f8-afdaff8186f4"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("946c8e72-1b49-4f77-ac48-6e3c09658f8e"), new Guid("101eb882-19b1-4571-979f-257e5875c43f"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9492a112-5d4a-4a2e-beed-2f9dcb4f4f69"), new Guid("712cb11b-02a5-423e-bd97-743ebb9026bd"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("959ceb53-f516-4625-96b6-f6684ae322c1"), new Guid("06b0be25-79ab-4229-a8b4-1877e3d41885"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("97f5ae0b-1731-48ae-b6a1-3b2b9de51db6"), new Guid("6befd9a4-8ad2-420d-9430-b6ae6c5b26fc"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("98f1ccc8-9695-4699-8dd8-b458858a9457"), new Guid("05e0e99b-ba3d-4744-81db-6d46b77c3e4c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("9931b53c-e5e0-4844-93d7-b304e2c409c7"), new Guid("17754776-07eb-47e3-b449-f33d0ef41338"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("9956f904-1115-4419-828c-8b14b4ff10f3"), new Guid("76ff08b8-7ef2-4eaf-b2e3-e2e962e3ea4b"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9963579a-d7cb-4c16-82d2-318c2cb0c3a7"), new Guid("6f47dca3-866a-42d7-9c71-38e68fbe3d3a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("99689ade-3f30-454a-aa34-5bfbceb92a48"), new Guid("7d02c671-c284-4af0-94dd-1c791b9f1d6c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("99c58fb7-4753-4e93-be47-5677f5d862d7"), new Guid("ce1da22f-d71f-4167-b25e-39f0283c7b30"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9a4bc01a-d6f4-4684-90bc-c35d4a7b03b1"), new Guid("1adfb27c-ce48-4126-a318-de2a3063a051"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9ba7a2e1-715a-47e7-af47-a2a00cc55398"), new Guid("05e0e99b-ba3d-4744-81db-6d46b77c3e4c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("9bf3e9fe-08a1-4018-9494-90e08ec3e2dd"), new Guid("44515f96-748c-4f10-96f5-f34db439b96a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9c0aa220-3974-4603-b2f3-daa7b46dfbde"), new Guid("47384ac3-6dd1-49ee-937a-783ab754745c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9c2a194f-908a-4659-91a2-6604bf462d8a"), new Guid("07b5d54f-1e03-41af-83cd-c0d749fe4f6e"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("9d8065f9-7ebc-4bbe-8141-7d01c7a281cf"), new Guid("1ad23a96-a0ab-4367-8f01-963dbb2768cd"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("9ddb8a04-dc2e-48fd-8d55-f2cafdc85753"), new Guid("8f7f3310-d0c5-48d9-aa60-cd6cec6b46df"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9e850ceb-cdd6-41d9-94aa-01e300f9a203"), new Guid("69781624-ee0d-440d-b950-dcf9c423d23a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("9e85e485-fd35-4cf7-a04b-2ac1c7f9552e"), new Guid("b9df28d1-d892-4862-b706-5d4a523173c8"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("9e8b77d7-433e-43c1-a6e4-5acbb05044ae"), new Guid("a544fa61-71d0-4ecf-b6bd-d149c050c5d4"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("9f418dcb-990d-49e8-9f47-2b7d4932523c"), new Guid("7b4020bd-e589-40d3-b626-ce1b5416d6d1"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("9f580d03-b393-406b-9a87-ddfbc2552132"), new Guid("9287d01b-ac63-4a96-ba87-11424189a4cd"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("a11917ba-5783-4666-aa9c-01a9c07a5b85"), new Guid("db829be3-7f29-4511-8d8f-89f820b44288"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("a35c5687-1085-4b0d-bb78-8433997941b8"), new Guid("1cbdba42-49c9-4a70-9d40-0454b408d360"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("a3722785-66e6-4125-861e-1844e1eecf50"), new Guid("42fb82ff-13aa-4f24-9476-83f951240c9f"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a3d49e50-07b9-4b92-831d-00c53ce9e44d"), new Guid("80888b45-89a9-4d94-89db-c8b3dd30daed"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a3ef865c-be89-49c9-bde3-4e2e6cbc7423"), new Guid("6befd9a4-8ad2-420d-9430-b6ae6c5b26fc"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("a44d4530-77d4-41c7-88fd-8f32b24d6c65"), new Guid("17754776-07eb-47e3-b449-f33d0ef41338"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a49ad408-a641-4da0-8efa-3908df0e8f44"), new Guid("a38316a9-ccd2-4752-9084-0df4312243d1"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("a576c38a-e5e2-40be-b400-d9d8787869e9"), new Guid("2fb8bd1e-947a-4501-88de-32c3d1b4a444"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a5ad9c36-377a-4d73-b12e-7b2bc6a96b6e"), new Guid("b9df28d1-d892-4862-b706-5d4a523173c8"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("a5c95858-b9c4-45bd-8c66-a9583a14f8af"), new Guid("71c9870d-0e47-4b66-8f3e-e6b24d89276a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a69c11e3-7ceb-4710-b5e0-547fbf073af9"), new Guid("35b821b1-5741-470a-aadb-5b74d1b70be3"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("a6cd3bd1-f827-4755-b5eb-ba660bd7cb31"), new Guid("34288d2c-5436-4cb8-8fdb-0ff4e0630681"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("a7b307a2-aedd-4d6f-b356-cfe243da357e"), new Guid("9f68c865-62e9-4a88-bd90-41860851c67c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("a981d9ab-2f04-45ed-a84f-19f5122c1e60"), new Guid("4bc07c0d-5a18-42f1-abab-95e234d14dde"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("aae3df16-80bc-4849-818c-7e04c20fe934"), new Guid("63d6b00d-49d2-4620-85d7-ca24fa15c827"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ab6a4aa6-8896-4829-8e80-849f70d51837"), new Guid("09301a47-09dc-4bd1-99f8-afdaff8186f4"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("ab74ac97-4b19-4318-8278-57a677369804"), new Guid("ac65557b-eaf7-4998-b3ad-8a944110803c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("abc60676-1de4-4545-b2bf-4fc907adf058"), new Guid("7b3c5e85-722b-479d-9a6b-e59e2783edc6"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("af545fe7-ede7-4296-aedc-37d36de69117"), new Guid("9f68c865-62e9-4a88-bd90-41860851c67c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("afcd5730-636d-4f93-b3be-dae8d634ba14"), new Guid("904761c7-05ab-40d1-8ee6-24f4b9baa729"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("b0b778d1-eaa5-40a0-89f8-3d69e04d12bc"), new Guid("a38316a9-ccd2-4752-9084-0df4312243d1"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("b279f8cc-3084-4cea-90fe-ae0dd21452e0"), new Guid("b24f4555-556a-423b-8c99-dcdfd74e1e54"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("b3193f56-a0d6-4682-8c31-27f0996cf95f"), new Guid("16d7ed05-0eaa-4768-8aa0-7a2332c7384b"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("b5b5467c-68c3-42de-95e6-86f20fc34fa5"), new Guid("4cc953a5-44ca-4636-9231-1b78332b5c0b"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("b6bced1f-660e-4be7-8a76-184eb1910b98"), new Guid("24e1e632-cfad-4279-9966-63d20da4407a"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("b746c1a5-a678-4fbe-8e59-1df61f5f60c4"), new Guid("c52b34a7-820f-42f4-883a-bf8e96861a85"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("b822672f-96e8-463d-8970-277c6f27a516"), new Guid("a38316a9-ccd2-4752-9084-0df4312243d1"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("b89e92ae-adf2-4530-8cdf-4820048646d5"), new Guid("d464c93a-1aae-4804-91c0-b9b2f7bae7b3"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("b91d7a1d-dc84-4734-a702-2024e6d52737"), new Guid("591e5261-4948-42be-9ae0-be315f1a6ed9"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("be985a1a-9e5d-4026-92cf-2a42d4c6933a"), new Guid("50222c52-78fd-47f8-b59e-a25dbbe773ea"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("bedaba06-387f-47c1-b721-a718189f9c8b"), new Guid("6f47dca3-866a-42d7-9c71-38e68fbe3d3a"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("bf3e9c1e-2d5c-458e-bd43-8c1bb2ef67f1"), new Guid("fd753b78-3bd7-4c4b-a7b3-f0b2355a3e05"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("bfe641b5-3418-4a85-abdf-2675f230dfe4"), new Guid("d3235a6f-99f6-4483-a361-ab827fe6420d"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("c0ba2f01-15f3-4ed5-bfc2-3475ce99aa17"), new Guid("d9f3516a-7831-4acf-8972-5c1efdf9750e"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("c0cb43ab-d19c-40ef-9ea1-77fdde54cacb"), new Guid("8f7f3310-d0c5-48d9-aa60-cd6cec6b46df"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("c2e17838-0bbe-43f0-a3d1-93a34bd5ac79"), new Guid("7ed53024-c508-44ba-bf88-98dfa744cf8f"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("c33dc415-a534-40dc-bdbc-cfe822c09686"), new Guid("7b3c5e85-722b-479d-9a6b-e59e2783edc6"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("c4010df5-a87b-4e50-ad38-61d583f9e4a0"), new Guid("db829be3-7f29-4511-8d8f-89f820b44288"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("c4cee9d6-e8f1-4e3d-abda-06a77275578e"), new Guid("4dc52f1e-b5f1-4bdc-b03d-dac1c925a7ed"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("c5fdc8c6-05f4-491a-9ec1-784fa70b7e02"), new Guid("afcd6bba-fe90-4b1d-a138-4cccdbf990e4"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("c773c4bc-88bc-43c0-a721-b3db092048fc"), new Guid("d51344ac-5911-4ace-baaf-c34d89f853bd"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("c8e84726-f0f4-47a6-b939-597f27c1d938"), new Guid("7d02c671-c284-4af0-94dd-1c791b9f1d6c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("c90529a2-5b32-4cc2-8798-dbca6856f2d8"), new Guid("101eb882-19b1-4571-979f-257e5875c43f"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("c91681eb-8e39-4f47-978a-6bc502e02ac7"), new Guid("592066b8-ce64-4059-a250-da111ea92ea2"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("ca5902e9-8abd-48a2-9460-e3900e8f7aeb"), new Guid("17754776-07eb-47e3-b449-f33d0ef41338"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ca98599c-524b-4844-8ad7-ed6aa565c4ad"), new Guid("d51344ac-5911-4ace-baaf-c34d89f853bd"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("cae5185c-a317-4d2d-a29c-859e5fd90728"), new Guid("6386e02e-71c5-47b7-a6a9-a5b015d89794"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("cb734f32-c7fa-4828-9df2-38ef1d6a21aa"), new Guid("247d1f6a-16ed-4882-aca9-40a5c19fc8d1"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("cc0901d8-38fb-4600-896d-fdccea36d06d"), new Guid("6386e02e-71c5-47b7-a6a9-a5b015d89794"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("d07e7430-054e-467f-af63-1f29838573b5"), new Guid("fd753b78-3bd7-4c4b-a7b3-f0b2355a3e05"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d1856201-ffcb-4045-9805-9f26c0328460"), new Guid("7a28e237-06d4-4893-ba7d-5beb5ddf0af4"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d1d5e1eb-5988-4f35-90b3-142e18d4a794"), new Guid("d9f3516a-7831-4acf-8972-5c1efdf9750e"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("d20aa4c5-0c3c-48b1-92d4-c6e90866140c"), new Guid("9752e1ee-a10a-4aaf-9f34-f270ed99900f"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("d22cc375-0f22-4689-ae79-813581c90949"), new Guid("25e1c95a-0eed-418f-b25c-4d61a791bd8c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d39e4e24-0e6e-48ad-9866-5642994455d8"), new Guid("23fd0a81-a0bc-4bdf-b40e-cdebd1886e99"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d59c7e10-6e9e-4e08-a9be-5ef10d5ec510"), new Guid("6f47dca3-866a-42d7-9c71-38e68fbe3d3a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("d5bb3753-9a0c-4750-85dd-1d880e3fdf16"), new Guid("64c15571-9f8c-4c31-896f-eea412a98fce"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("d6a90994-fa9a-4f3a-953b-1e4be2f5c244"), new Guid("e55cacac-6bee-442c-b5ce-49ded79b14b1"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("d73d1c80-edc6-4e04-8bcf-31311216b5bf"), new Guid("71c9870d-0e47-4b66-8f3e-e6b24d89276a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("d8ace114-4df6-43b5-b3f4-4e275c8ca6d7"), new Guid("8f7f3310-d0c5-48d9-aa60-cd6cec6b46df"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("d8b42617-ad7f-47a9-8c43-69cd6b2dd7e9"), new Guid("05e0e99b-ba3d-4744-81db-6d46b77c3e4c"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d8d2cf0b-4678-44ae-a9bf-2a736156a227"), new Guid("64c15571-9f8c-4c31-896f-eea412a98fce"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d906a92f-6433-4980-8e71-ab48058cd98c"), new Guid("b2f47d49-d3fa-49e9-ae43-7b8b8dc64b55"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("d92545c7-9f34-435e-bbc1-9fa4ce790cce"), new Guid("f065bda6-44b4-403e-b5f3-ba54c21ed9c5"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("d9f5998e-b9d9-4ffc-9374-653845d46d34"), new Guid("d36277c1-8d01-4768-9cb7-749c3158ff12"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("da7bab1d-b20a-4697-b429-bfe14aa3665b"), new Guid("247d1f6a-16ed-4882-aca9-40a5c19fc8d1"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("dcc16215-013a-4413-be84-52fd24f6ff88"), new Guid("c52b34a7-820f-42f4-883a-bf8e96861a85"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("dcf95031-c844-4c25-a274-3350aea2707e"), new Guid("e75554f9-588d-40da-ba1d-9086159f99ff"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("ddb75dc9-7458-4b66-a16f-9f963d34fa2c"), new Guid("d9f3516a-7831-4acf-8972-5c1efdf9750e"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("ddd17ba9-0770-4bb0-ac89-d1cc43cae047"), new Guid("4d995bf2-26cd-4e17-87d2-d481d887f0a0"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("dde4d4e3-19d1-4f86-ac4a-bc2b0caf1f61"), new Guid("7b3c5e85-722b-479d-9a6b-e59e2783edc6"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("de92bc01-03b7-4d28-a3b2-51c91a78ac3d"), new Guid("c8be91e0-5049-42b2-b864-a93e2a025ba8"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("df2ba147-b9ba-4c15-a543-1b7c3947fff0"), new Guid("7b4020bd-e589-40d3-b626-ce1b5416d6d1"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("dfe8ecb3-7022-4dac-97cf-c42378efb527"), new Guid("b2f47d49-d3fa-49e9-ae43-7b8b8dc64b55"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("e0e6f3b2-9767-418e-bb45-08d14a743dc7"), new Guid("1fb6f050-a370-4115-94c8-1b3956ede2e4"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("e0ef8931-edcc-49ae-a34c-83334ab77201"), new Guid("6157468e-1168-4f66-a90b-af202b1539f0"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("e1233f2e-b1be-4c18-a7c0-a977415e2927"), new Guid("7ed53024-c508-44ba-bf88-98dfa744cf8f"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("e3177c5b-d34c-4cda-adf0-d485d54aef52"), new Guid("dba56e98-53e8-4646-9b41-d55bbbccd45f"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("e4aa657a-a9c2-4a00-b964-8d0c770fafe2"), new Guid("54af5931-b4f0-4584-adcf-7a7c6d1e0034"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("e5ba4b11-f85e-43a6-9f89-34d6d2302f5a"), new Guid("bfe6906f-9b0e-48b1-8da7-14ba0c504df7"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("e5d67e60-7938-48d6-a507-be2c94cac9b1"), new Guid("b24f4555-556a-423b-8c99-dcdfd74e1e54"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("e68811da-16c5-471b-ac16-f632e42813bd"), new Guid("c4f58319-dcb8-4aea-ae82-9616b1687f47"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("e8448f3d-6270-4f1d-a334-782121e099f0"), new Guid("529878fe-2663-4735-b20c-de2ba6d77ff6"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("ea989b1a-586a-4983-9a08-135c66739511"), new Guid("739df710-cc24-49d1-a339-a1603eb1a378"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ec01f1d4-5e35-4a7b-8a1c-66ed4f7e5087"), new Guid("c4f58319-dcb8-4aea-ae82-9616b1687f47"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("eca1972d-7b6c-4c00-ac0c-173dbe888686"), new Guid("904761c7-05ab-40d1-8ee6-24f4b9baa729"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("ece38c63-010b-4d94-a7fd-c0eb2caca5aa"), new Guid("f6eae055-0910-4933-8c9e-a20850f861a7"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ed29e404-338f-4a9d-a615-3adbd8bec9ba"), new Guid("5ebaa817-f406-4578-bba8-783b7d40d7a3"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("ed340be0-af9e-40b1-a56f-9258daa801ed"), new Guid("25e1c95a-0eed-418f-b25c-4d61a791bd8c"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("ee3095be-8ac4-4a84-afe3-1c5c8f8de697"), new Guid("4d995bf2-26cd-4e17-87d2-d481d887f0a0"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("ee33c962-15d8-4d30-9b24-d4c1ef2e3897"), new Guid("23f84e93-2b3c-4c27-aa77-bfb970d99936"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ee4505d9-76cc-437f-b9a9-58f5895c2075"), new Guid("4bc07c0d-5a18-42f1-abab-95e234d14dde"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("ef5ba5b3-b45b-4dea-a912-6958dba22967"), new Guid("9287d01b-ac63-4a96-ba87-11424189a4cd"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("ef8db455-388c-4ca9-8bfa-85735afe9fbb"), new Guid("f6eae055-0910-4933-8c9e-a20850f861a7"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("effcd133-1797-4616-84ae-fb127687ec46"), new Guid("d51344ac-5911-4ace-baaf-c34d89f853bd"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("f019efb6-b645-497c-b15a-8830b9cd10b0"), new Guid("9752e1ee-a10a-4aaf-9f34-f270ed99900f"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("f025edb3-b8f0-4961-b3f8-e4bbb2de5a81"), new Guid("58aa4907-650c-4ab3-8792-d4c9cb8fa973"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("f167d14e-a9d9-44d9-ad4a-eb46f9e726b9"), new Guid("1ad23a96-a0ab-4367-8f01-963dbb2768cd"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("f1d6ca19-a19d-4ee2-a368-482de20c4bdb"), new Guid("23fd0a81-a0bc-4bdf-b40e-cdebd1886e99"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f2a60d09-c13f-4971-aa50-e915ae8c295e"), new Guid("5b76bac1-3053-4a47-a6d3-8a09381fe399"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f2af8aec-6050-4808-8dad-ee40295a9fed"), new Guid("d35b7108-19ed-4615-b342-8db70c0a1d87"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f2d36008-edb8-44d1-82c1-6721e109556b"), new Guid("1adfb27c-ce48-4126-a318-de2a3063a051"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f3ba83fc-e18e-4e61-9a79-5032afa6c113"), new Guid("7a28e237-06d4-4893-ba7d-5beb5ddf0af4"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("f4c189b0-de1a-41ca-a228-0daffc96d344"), new Guid("64c15571-9f8c-4c31-896f-eea412a98fce"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("f5dd10d0-3207-47b5-a800-e8353966e7ee"), new Guid("8679fc50-ce09-4223-9ecc-3dfdc5691db1"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("f7184a87-9e1e-48a6-88c4-a3156c046a6d"), new Guid("904761c7-05ab-40d1-8ee6-24f4b9baa729"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f804d155-b16a-4fb0-a495-c602145b2d35"), new Guid("47384ac3-6dd1-49ee-937a-783ab754745c"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f804df21-97c0-43e9-9f12-f052ba20060b"), new Guid("1cbdba42-49c9-4a70-9d40-0454b408d360"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("f877eb0a-d343-4128-bf5e-66fe4b9cedca"), new Guid("07b5d54f-1e03-41af-83cd-c0d749fe4f6e"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("f90afd1c-c1cb-4844-ab6a-40f52a97b6a4"), new Guid("a0dc7272-d3fd-4e27-9949-e372841e1d80"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") }
                });

            migrationBuilder.InsertData(
                table: "Placements",
                columns: new[] { "Id", "CottageId", "Name", "PlacementTypeId" },
                values: new object[,]
                {
                    { new Guid("f9b82852-80f2-4720-84dd-2fa6821c30cf"), new Guid("ea948d44-0b4c-42b0-a35b-932123e03de0"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("f9c82bdd-8fb1-4fae-997f-ce95d4809b06"), new Guid("afcd6bba-fe90-4b1d-a138-4cccdbf990e4"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("fae33872-0420-453f-973e-f02f5b7bd54b"), new Guid("44515f96-748c-4f10-96f5-f34db439b96a"), "heating", new Guid("000eb85f-2ddd-4931-8124-caba59f47ba2") },
                    { new Guid("fc306636-635f-4eaa-a51e-fae1caf4ae32"), new Guid("80888b45-89a9-4d94-89db-c8b3dd30daed"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") },
                    { new Guid("fda8f34f-be22-4dc0-85af-b3e8097b274c"), new Guid("4dc52f1e-b5f1-4bdc-b03d-dac1c925a7ed"), "hall", new Guid("ca9f1c2b-41c0-4cce-a978-29b641586aca") },
                    { new Guid("ffc5b681-51ec-41fb-ac95-abbc80686d5d"), new Guid("2fb8bd1e-947a-4501-88de-32c3d1b4a444"), "kitchen", new Guid("4434ad10-2d11-4d01-9243-fb7e2f2a2806") }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("000c7f18-0632-41d5-bf44-b064a4cb714b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ae0d759-e64a-428d-b894-2b70ba397814"), 0f, "temperature" },
                    { new Guid("03652c1f-ffad-4ba3-96c3-3ac7fd37140d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("848eb3cf-ef89-4532-ad18-4b609851932e"), 0f, "temperature" },
                    { new Guid("043bbf98-1081-4f8c-8db7-122528880e36"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4f77ea82-07e2-41de-b043-d6dd32548da3"), 0f, "temperature" },
                    { new Guid("05349691-bbd9-4db0-922c-3a8511d2ce28"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6c45bc27-b682-4713-9468-4bd752f45824"), 0f, "temperature" },
                    { new Guid("06d81339-26c7-4722-b6e4-142b109040ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("30e58d5d-fd7c-4379-8c1b-8abb3e876063"), 0f, "temperature" },
                    { new Guid("0745baf4-5928-4b15-9461-d96286b6b808"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("99c58fb7-4753-4e93-be47-5677f5d862d7"), 0f, "temperature" },
                    { new Guid("07a95993-67b7-4fb7-992c-7b13159be9ca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58357c9d-3cba-40c2-bc60-e8d6e81f85c2"), 0f, "temperature" },
                    { new Guid("089b4331-d421-4551-b84e-10a408a9991b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8d881538-df74-47b1-a55f-4ae394be9f63"), 0f, "temperature" },
                    { new Guid("0999f05d-f949-4575-90ba-c8fef1aba0a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("709b8e02-ac4c-4506-aca8-3a2e0b528346"), 0f, "temperature" },
                    { new Guid("0a2e1e17-bda9-46c3-80e0-c8c0a2daf8ca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ea989b1a-586a-4983-9a08-135c66739511"), 0f, "temperature" },
                    { new Guid("0a6f3714-8f60-4cde-97cb-ad774e496765"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("371bae12-0c84-4231-83f5-775d45a75eb3"), 0f, "temperature" },
                    { new Guid("0ac93236-ccd0-4632-a601-15811281afdf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("92989fb7-d3a5-4289-b2bb-61f33f4b6406"), 0f, "temperature" },
                    { new Guid("0d9278d9-cdd7-4bb4-9836-58f05c30bb88"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e5d67e60-7938-48d6-a507-be2c94cac9b1"), 0f, "temperature" },
                    { new Guid("0e8bd44c-f2fa-44c8-9750-c60cfbd1c162"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1d5e1eb-5988-4f35-90b3-142e18d4a794"), 0f, "temperature" },
                    { new Guid("0f00c842-e4b3-47c9-aa5b-9f5c6ee9160a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90975c44-0091-4fba-b22c-95b2d406bf0d"), 0f, "temperature" },
                    { new Guid("0f3742ee-84fd-4db0-9425-632028e638d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("effcd133-1797-4616-84ae-fb127687ec46"), 0f, "temperature" },
                    { new Guid("0fce421e-c6ac-4074-a7d7-e4a3fd44d356"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4604fb92-5977-4df2-a593-ca1870cddb0d"), 0f, "temperature" },
                    { new Guid("118a1ffe-0168-44a7-b158-c8c948361b8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("337f3f0d-065e-412c-8a9c-77cf5c7ee29e"), 0f, "temperature" },
                    { new Guid("122801f8-ce5f-451e-8f5b-682a20f291f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("090530f0-cd5d-4b2e-ac03-d3e56ae75295"), 0f, "temperature" },
                    { new Guid("12a26044-f02a-477b-9d39-6dde94f60864"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("15a9cfd3-bfc9-43d1-8381-b3e5aaff8a1d"), 0f, "temperature" },
                    { new Guid("1313355d-3d17-4a36-ab8b-c30496f4861b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("406037eb-938e-4be4-b6b1-f76a2083de12"), 0f, "temperature" },
                    { new Guid("1407edb5-d370-440b-81e8-d01941166c54"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c2e17838-0bbe-43f0-a3d1-93a34bd5ac79"), 0f, "temperature" },
                    { new Guid("1698f641-7d3c-4d23-b0f8-47c9073e561b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c4cee9d6-e8f1-4e3d-abda-06a77275578e"), 0f, "temperature" },
                    { new Guid("17614f9b-6f76-4a61-838d-45c0fbaf83dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("79c7a6a8-4254-41f2-adc1-50fa943679a2"), 0f, "temperature" },
                    { new Guid("177811b1-bdd9-4ad2-ade3-304af0ada03d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3ef865c-be89-49c9-bde3-4e2e6cbc7423"), 0f, "temperature" },
                    { new Guid("17da4be8-3522-421e-9864-ed56448ff4f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("93fa4bf1-be5e-420c-8c38-20a5fe5ee702"), 0f, "temperature" },
                    { new Guid("1adba74e-1b03-4b45-92cb-46fae68d2fb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9f418dcb-990d-49e8-9f47-2b7d4932523c"), 0f, "temperature" },
                    { new Guid("1b25a17c-1855-4d7c-ad38-a1e04f01336a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bfe641b5-3418-4a85-abdf-2675f230dfe4"), 0f, "temperature" },
                    { new Guid("1b3f51ac-cfb9-41f2-9b74-ffb7a5aefb27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70bb8cfa-fb17-43bb-8fa9-71b564e8a596"), 0f, "temperature" },
                    { new Guid("1c6bba71-7cd2-4e18-a108-2342e7e49cc7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fda8f34f-be22-4dc0-85af-b3e8097b274c"), 0f, "temperature" },
                    { new Guid("1d9132e8-214c-4cd2-88c8-01a767bf5c42"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5cfe56b4-62ae-4ec7-9dc2-0f39917229ba"), 0f, "temperature" },
                    { new Guid("1e8a2c3d-00f5-4bae-ad6a-7c0ac5eb7112"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9e85e485-fd35-4cf7-a04b-2ac1c7f9552e"), 0f, "temperature" },
                    { new Guid("1f15fe94-23ae-44bb-981a-6695a311ef0e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("65b625a6-36d5-4bf8-b551-dd0518088e76"), 0f, "temperature" },
                    { new Guid("1f191fef-914c-43a2-9a42-f0ea791ae309"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b16cba4-0082-4754-a758-64dfa6dff6de"), 0f, "temperature" },
                    { new Guid("20d173f0-6ffb-4508-9087-28f9168c337e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e2820a1-35e2-4f3f-9001-17bfa24fc27f"), 0f, "temperature" },
                    { new Guid("2142a420-77b6-4483-8985-c3a9fc8729a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("48edd72e-0b0e-45f9-b7c5-96eb7f4f2f23"), 0f, "temperature" },
                    { new Guid("2174800a-03e0-47c7-9421-fd3932fc8504"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("13ee55ec-c805-47d8-8038-cab9922e607e"), 0f, "temperature" },
                    { new Guid("21fe11e2-a403-4fab-b373-4275f1dcd818"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97f5ae0b-1731-48ae-b6a1-3b2b9de51db6"), 0f, "temperature" },
                    { new Guid("24bfabfa-ecc4-498d-bbcf-34492926a520"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("636eb334-e013-4a02-bb72-5b7cfdd57eae"), 0f, "temperature" },
                    { new Guid("24e9f9f8-76f1-4d8c-b23d-50b528c8202c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9963579a-d7cb-4c16-82d2-318c2cb0c3a7"), 0f, "temperature" },
                    { new Guid("254b509e-1672-4d24-bb77-fa6aebd013e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7ab18ba8-6493-467b-ab23-e15e5a99a841"), 0f, "temperature" },
                    { new Guid("25e860a2-2482-4bdb-937c-3be7d4e55a62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffc5b681-51ec-41fb-ac95-abbc80686d5d"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("2717ddee-b4a9-44a2-b926-52670116d9ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("35c55eef-c195-4f43-9fdd-ca8dea8742ce"), 0f, "temperature" },
                    { new Guid("2884e2dc-4559-4921-8d7b-d872be40f0ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8b42617-ad7f-47a9-8c43-69cd6b2dd7e9"), 0f, "temperature" },
                    { new Guid("28e6d1f7-acb4-4c70-9b5c-d631d1204e08"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9e850ceb-cdd6-41d9-94aa-01e300f9a203"), 0f, "temperature" },
                    { new Guid("29985c15-bf11-4f5b-a85e-dc435d07bd46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf3e9c1e-2d5c-458e-bd43-8c1bb2ef67f1"), 0f, "temperature" },
                    { new Guid("29fde52d-d658-4e4f-9c44-75f82cd9b0d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b91d7a1d-dc84-4734-a702-2024e6d52737"), 0f, "temperature" },
                    { new Guid("2b55f821-8ab4-418d-9abe-720211ef5382"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2bde63d3-453a-4ed3-8c90-986cb62f4995"), 0f, "temperature" },
                    { new Guid("2bd9dc3c-e1b9-481c-b6bf-beac57451dab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58ea30b2-1b89-41d6-9461-f4b4d12c2bee"), 0f, "temperature" },
                    { new Guid("2c3ef755-13c8-4ccb-ba68-7bcdd0503050"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4400d049-ef5e-471a-9c90-4d992f6d47c9"), 0f, "temperature" },
                    { new Guid("2d6048ab-43e7-45f8-9aea-ffb656f0e3e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("20202900-52d6-42f5-9178-584313760662"), 0f, "temperature" },
                    { new Guid("2d93dd15-e6ef-4337-8150-1985c34a4dbe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9c82bdd-8fb1-4fae-997f-ce95d4809b06"), 0f, "temperature" },
                    { new Guid("2ef70580-d0da-4d55-8adf-1075e08f7084"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6a90994-fa9a-4f3a-953b-1e4be2f5c244"), 0f, "temperature" },
                    { new Guid("2f47aa32-d012-4aaf-b179-5a07aa94a658"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("68b0cfc0-9883-4c7c-8de0-f39875fc0ea7"), 0f, "temperature" },
                    { new Guid("2f567860-82db-4781-ae6e-d65df70713ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7d06b548-71d4-44d6-b479-04464ddb1c20"), 0f, "temperature" },
                    { new Guid("2f95d068-6e00-4093-988b-2a26f5f94a9f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a49ad408-a641-4da0-8efa-3908df0e8f44"), 0f, "temperature" },
                    { new Guid("318f14ac-5ccc-4c11-8c5b-87d7c5a97672"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("16693336-98b0-4141-9caf-c0ed0cfbb7ac"), 0f, "temperature" },
                    { new Guid("33ec416a-a1f4-4fe7-8cd0-cc52172d7b72"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("012bbe9b-4030-49c5-88ed-7cd9cab860a6"), 0f, "temperature" },
                    { new Guid("34dfbe00-853d-4c04-9555-620abb3baab6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("437d9efe-48e7-4e67-ab01-fd8e74b69547"), 0f, "temperature" },
                    { new Guid("3511ea81-0ab2-4b81-8482-2f7d5464d80a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab74ac97-4b19-4318-8278-57a677369804"), 0f, "temperature" },
                    { new Guid("356bf1ca-bbe1-42cf-a6fe-c25c2ae6493f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7b5c03a3-2b71-4c68-b6bb-1998db46bc94"), 0f, "temperature" },
                    { new Guid("365f20c5-77fd-4ad3-a08d-81496fe094da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("98f1ccc8-9695-4699-8dd8-b458858a9457"), 0f, "temperature" },
                    { new Guid("36df8ba9-05a3-4dd4-bb5c-d122e9754b44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c773c4bc-88bc-43c0-a721-b3db092048fc"), 0f, "temperature" },
                    { new Guid("37310bca-f5ce-4ae7-878d-78b1bf298f03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f025edb3-b8f0-4961-b3f8-e4bbb2de5a81"), 0f, "temperature" },
                    { new Guid("378ded1a-ce27-4707-b025-264ae50995d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d59c7e10-6e9e-4e08-a9be-5ef10d5ec510"), 0f, "temperature" },
                    { new Guid("39eae815-a4ca-44db-8aec-137290183c1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("48885af2-5a61-4e4f-a1da-105ca75944e6"), 0f, "temperature" },
                    { new Guid("3a32a0c3-7fdf-4fce-90c9-20ae448e39dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cb734f32-c7fa-4828-9df2-38ef1d6a21aa"), 0f, "temperature" },
                    { new Guid("3a49ef75-acc9-4551-9603-33c08798b2f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c90529a2-5b32-4cc2-8798-dbca6856f2d8"), 0f, "temperature" },
                    { new Guid("3acee3db-7dbe-4388-bfdf-648654ee511d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a615493-1da3-4618-a7dc-b0490af01d5b"), 0f, "temperature" },
                    { new Guid("3af5a8d4-ff20-4c09-9d0e-f305db4d8704"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1856201-ffcb-4045-9805-9f26c0328460"), 0f, "temperature" },
                    { new Guid("3c6e5b3d-515a-49d7-9ec5-0d11c0a38762"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6878cc8c-269a-4eb1-bbb9-054adfab658f"), 0f, "temperature" },
                    { new Guid("3d936a56-3326-4e29-afa4-1b2f3483dd8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e3177c5b-d34c-4cda-adf0-d485d54aef52"), 0f, "temperature" },
                    { new Guid("3e24bcb7-7bd2-438f-b91a-4678f1dba760"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d7c91b2-ac65-47cf-ac8b-af65bfaddd7a"), 0f, "temperature" },
                    { new Guid("404e96bf-144f-4fbc-9497-4fb3c3844974"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ee4505d9-76cc-437f-b9a9-58f5895c2075"), 0f, "temperature" },
                    { new Guid("405d32fa-6925-4648-9ae0-97c327e88513"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ece38c63-010b-4d94-a7fd-c0eb2caca5aa"), 0f, "temperature" },
                    { new Guid("40bac920-e2b1-45a1-ba22-74ed1d834d75"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5ad9c36-377a-4d73-b12e-7b2bc6a96b6e"), 0f, "temperature" },
                    { new Guid("4261abf2-7ead-424a-8885-300e94676a0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("be985a1a-9e5d-4026-92cf-2a42d4c6933a"), 0f, "temperature" },
                    { new Guid("4284e233-3e31-420c-aad7-1198b2a4f5cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("687c7c0c-b90f-4a68-ab4c-4288a9d0cf22"), 0f, "temperature" },
                    { new Guid("43d05bff-1b3d-48ac-bd6a-6fd469abfd4f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6b9a9cc8-dab4-44f1-8b67-7ca9af51aa68"), 0f, "temperature" },
                    { new Guid("449045be-1b1c-45a2-b840-6407e84aec58"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f01c190-d3c1-4a36-b52a-35088b346c24"), 0f, "temperature" },
                    { new Guid("454224ab-0d10-46c2-b788-74af0cecf39f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("29cf6630-e3ad-48d7-87d2-0c67acd7a7f8"), 0f, "temperature" },
                    { new Guid("45a85a38-f62c-4b07-a1ab-1d76d5051c7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8d073e1a-712b-4f6a-a20e-de263aeb66c1"), 0f, "temperature" },
                    { new Guid("45ed1bae-3f53-4654-8cde-19a305ca7c4e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8c15b64a-e408-4d3e-8c7e-bc865c027885"), 0f, "temperature" },
                    { new Guid("477628ee-3606-46dc-ae88-6fb7bc4d7d13"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddd17ba9-0770-4bb0-ac89-d1cc43cae047"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("47a4d29b-6aa1-474d-82d4-8a9758bf6dc4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e5ba4b11-f85e-43a6-9f89-34d6d2302f5a"), 0f, "temperature" },
                    { new Guid("48496080-4664-490c-8050-286bacaba1d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f877eb0a-d343-4128-bf5e-66fe4b9cedca"), 0f, "temperature" },
                    { new Guid("48578b84-194b-4379-a508-2650473a55cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1233f2e-b1be-4c18-a7c0-a977415e2927"), 0f, "temperature" },
                    { new Guid("488be78a-7e41-4619-9305-2f8a6e3196d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2a60d09-c13f-4971-aa50-e915ae8c295e"), 0f, "temperature" },
                    { new Guid("48f8d15d-3f66-4135-b2f3-8c37151374f6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f0cc010-d051-4739-9f3f-c7c3e2d122b8"), 0f, "temperature" },
                    { new Guid("49662621-e80d-48d9-8eae-adbf4db47a21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f9b82852-80f2-4720-84dd-2fa6821c30cf"), 0f, "temperature" },
                    { new Guid("4a29c3b8-1be2-4521-a8d2-c9fb560f6d07"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("84878eb6-2389-4733-97b7-06ed137539c2"), 0f, "temperature" },
                    { new Guid("4a503505-b50e-4e30-951b-4edea559e93a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f167d14e-a9d9-44d9-ad4a-eb46f9e726b9"), 0f, "temperature" },
                    { new Guid("4a52debe-cfa9-4475-a916-d7aa3a5da8c3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("866d0c5b-af80-4d40-8696-949320e7b080"), 0f, "temperature" },
                    { new Guid("4c3e850f-1c22-4070-8b7a-ae2f10eb2624"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fc306636-635f-4eaa-a51e-fae1caf4ae32"), 0f, "temperature" },
                    { new Guid("4c6a5722-52f7-4dc0-a628-7afa6e063f33"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8ff110d9-a1c4-4f8a-83fe-fd306da73b09"), 0f, "temperature" },
                    { new Guid("4d1a09f2-31e0-4141-85d4-3fc3aaacc027"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04b36dce-b413-4c95-bab6-3ec02a40713b"), 0f, "temperature" },
                    { new Guid("4d60dd30-5685-44e0-8f71-76f01d1ee031"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("abc60676-1de4-4545-b2bf-4fc907adf058"), 0f, "temperature" },
                    { new Guid("4ee8b22c-2702-4115-bd1a-2aba6d37d6a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5fdc8c6-05f4-491a-9ec1-784fa70b7e02"), 0f, "temperature" },
                    { new Guid("4f10de9b-52f6-4c3c-9167-144d9aa95447"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4a0fc2d7-0798-4480-9825-2ee1c23fc1c9"), 0f, "temperature" },
                    { new Guid("4f51bd2b-0645-44ca-8f60-abb0062a1258"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5ab63ff2-9285-47bb-a79d-eb61606988b0"), 0f, "temperature" },
                    { new Guid("504075a2-8ca0-41a8-8f65-5744b9238d7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90edb730-379a-48c1-af0d-9ca87d6334f3"), 0f, "temperature" },
                    { new Guid("50c75c3f-2ca1-4641-9c0c-523d4f5d4620"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f8aefc4-a0f6-4d4b-9a36-e09b5f248783"), 0f, "temperature" },
                    { new Guid("50d57014-717a-4f6a-9c69-a41088454c93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9f580d03-b393-406b-9a87-ddfbc2552132"), 0f, "temperature" },
                    { new Guid("50e104ba-571f-4ba0-88b4-d1ebd0633763"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("78550015-92fb-4049-9933-e0a84a8cb326"), 0f, "temperature" },
                    { new Guid("52e77e91-75d0-443a-9b17-0c077fa1a9ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75913245-3468-4e98-8c77-995dd937e4e0"), 0f, "temperature" },
                    { new Guid("54afbf3a-5a06-4fd5-a596-34d7be223147"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9ddb8a04-dc2e-48fd-8d55-f2cafdc85753"), 0f, "temperature" },
                    { new Guid("556b94ed-b4cd-4628-a62c-1d5422846537"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44daeb38-bada-41b3-8f96-23b606d63f70"), 0f, "temperature" },
                    { new Guid("582653e7-9ed3-44a3-a197-89d68952c0c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8870bd45-63fa-46dd-bec2-1f081519267a"), 0f, "temperature" },
                    { new Guid("59019460-5485-46fd-9afb-9175a5ea473b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b0b778d1-eaa5-40a0-89f8-3d69e04d12bc"), 0f, "temperature" },
                    { new Guid("59274bc6-3435-46fe-b223-716b37ad07ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c0aa220-3974-4603-b2f3-daa7b46dfbde"), 0f, "temperature" },
                    { new Guid("5a8d9008-ca8b-48b0-bd04-3374a385169d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b746c1a5-a678-4fbe-8e59-1df61f5f60c4"), 0f, "temperature" },
                    { new Guid("5adbb679-37d9-4896-9e27-41383878f6f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8c8b5889-eb6f-4f5e-9475-86b4d9261aee"), 0f, "temperature" },
                    { new Guid("5b1b522b-aeff-413c-ab2d-ee2cb4713c61"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8a8acc96-abd3-4985-bf8e-6423f045c14e"), 0f, "temperature" },
                    { new Guid("5b45e95b-b6b3-4082-858c-c7e19a9cdd3c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5aa8f9d8-ea8f-4fe0-b569-d75587e89b5a"), 0f, "temperature" },
                    { new Guid("5b466c65-38a1-4642-855d-39de3b6eb60d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("83f1d002-3b4b-469e-a626-b73817678111"), 0f, "temperature" },
                    { new Guid("5dc25b25-5557-40fc-8de8-cefee4758473"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f362302-5952-4e4b-85fd-2c74152d02e7"), 0f, "temperature" },
                    { new Guid("60e70943-4b6f-4f77-8b40-4493ab986475"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a576c38a-e5e2-40be-b400-d9d8787869e9"), 0f, "temperature" },
                    { new Guid("613007db-a7e0-4035-ab3c-b48157fd958f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3dd2d7ce-246b-4081-9dda-b79ffba5cfb7"), 0f, "temperature" },
                    { new Guid("6132d307-2a5d-48e5-87da-1ece03471f69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ccbadaa-86a1-4443-aebd-6eafcf17c588"), 0f, "temperature" },
                    { new Guid("623d7bd5-adf3-4253-a5c0-850918279628"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ca5902e9-8abd-48a2-9460-e3900e8f7aeb"), 0f, "temperature" },
                    { new Guid("62b18b4d-afeb-49f9-b00d-1e6e764379e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aae3df16-80bc-4849-818c-7e04c20fe934"), 0f, "temperature" },
                    { new Guid("630c9add-d644-496f-9b75-aa02c7af5d96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c2a194f-908a-4659-91a2-6604bf462d8a"), 0f, "temperature" },
                    { new Guid("65839cd1-072a-4579-8e7e-b8acc59839f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3ff6c04d-8fc2-4017-9607-ce0a5b739609"), 0f, "temperature" },
                    { new Guid("65ba02d8-cdb0-42d5-a8c4-333cebc90043"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5e53a9a9-9a64-49d3-b498-a5230efe6ef5"), 0f, "temperature" },
                    { new Guid("66ca4a99-fc99-4f04-ae77-998e2b57b0b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("df2ba147-b9ba-4c15-a543-1b7c3947fff0"), 0f, "temperature" },
                    { new Guid("6774c9ce-7f62-408b-8422-9f9a4bf0286a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f3ba83fc-e18e-4e61-9a79-5032afa6c113"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("68b00dcf-7117-4dc5-9f2d-3ef8a422eb9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b46c276-6f63-40b6-a9a1-97f86e8c9457"), 0f, "temperature" },
                    { new Guid("69e921c9-13b8-48ed-8f1c-9c641931ec2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed29e404-338f-4a9d-a615-3adbd8bec9ba"), 0f, "temperature" },
                    { new Guid("6a115fb5-17fe-4eb6-ae1e-924d5f9496d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef8db455-388c-4ca9-8bfa-85735afe9fbb"), 0f, "temperature" },
                    { new Guid("6a1f9792-ec8e-40d8-9a7a-5dbf33357fb8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fe22370-12f3-4808-a5af-2db3d516620d"), 0f, "temperature" },
                    { new Guid("6af8d256-a5f9-4920-b005-cd0c64526c98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d22cc375-0f22-4689-ae79-813581c90949"), 0f, "temperature" },
                    { new Guid("6b4e33eb-4e61-4f39-9a7e-fbbd389e726c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("342ba0d7-c845-44e6-b7d5-403686eee6a5"), 0f, "temperature" },
                    { new Guid("6bebf6e3-a07e-4ac9-afe0-718f1f3bdead"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4aa657a-a9c2-4a00-b964-8d0c770fafe2"), 0f, "temperature" },
                    { new Guid("6cc5cc67-951b-408a-96c6-9970b6dee1c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc0901d8-38fb-4600-896d-fdccea36d06d"), 0f, "temperature" },
                    { new Guid("6cd972c0-14e0-44b8-b9ce-8152cb7d9e1d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2af8aec-6050-4808-8dad-ee40295a9fed"), 0f, "temperature" },
                    { new Guid("6f4b675c-c824-42a2-b33b-4d8730db2781"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74125495-1c7e-4a17-990a-fe938da495f6"), 0f, "temperature" },
                    { new Guid("6f96aa05-23c2-4e56-8ff4-b07b72676cb1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b32fc0c-1b98-4750-aa02-d5cf4aca91bc"), 0f, "temperature" },
                    { new Guid("7105f9ae-f433-4e0e-a22f-8c77001b4d6a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef5ba5b3-b45b-4dea-a912-6958dba22967"), 0f, "temperature" },
                    { new Guid("717b5883-1448-4f84-839a-d15f9f553905"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d07e7430-054e-467f-af63-1f29838573b5"), 0f, "temperature" },
                    { new Guid("736a636b-e5fa-433d-906a-7fc33431c458"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0c85183d-8dcc-4838-9666-e308b4beaf18"), 0f, "temperature" },
                    { new Guid("7380baf0-dc1a-4f34-bc3b-eda7f6747687"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0213370b-3ff0-4c7a-93d1-ebcd2d9f3ccd"), 0f, "temperature" },
                    { new Guid("742c9a2d-cb36-43f5-87e0-5e972455d061"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddb75dc9-7458-4b66-a16f-9f963d34fa2c"), 0f, "temperature" },
                    { new Guid("7646310a-a27e-460d-980d-87f6e5dbaaec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9a4bc01a-d6f4-4684-90bc-c35d4a7b03b1"), 0f, "temperature" },
                    { new Guid("76884a36-e21d-4733-bcf8-18ae46a3ef14"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("28c8c136-5a77-471f-984a-3c62727d86b8"), 0f, "temperature" },
                    { new Guid("77d5b728-3090-44c5-8cd5-071767a8bfeb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22fadbdc-2fca-4a73-99ac-307784138205"), 0f, "temperature" },
                    { new Guid("78b7f326-7640-4dc3-b401-2cdb63ae5e1b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1df55dac-d614-4497-88c5-f69db55f6c19"), 0f, "temperature" },
                    { new Guid("7c29844d-54f8-4e1d-b5a2-4c7a09c620e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("78f77f6c-9ceb-424d-9ccd-266d906507df"), 0f, "temperature" },
                    { new Guid("7c4ae6cb-79e6-4a7f-bd64-49204883bd55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6cf449d8-092f-4e1c-8428-bedaa572cef8"), 0f, "temperature" },
                    { new Guid("7c56d1ba-5a96-4508-bbec-ce3c9cc39fa7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bedaba06-387f-47c1-b721-a718189f9c8b"), 0f, "temperature" },
                    { new Guid("7cd98223-701a-409a-af7d-048ed03e49ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3722785-66e6-4125-861e-1844e1eecf50"), 0f, "temperature" },
                    { new Guid("7d0c2f4d-8c40-4a44-82da-e1a124989409"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c91681eb-8e39-4f47-978a-6bc502e02ac7"), 0f, "temperature" },
                    { new Guid("7d51cdce-e3a3-4996-95e7-8bf6bd5e599d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07b96e53-f933-447c-8b0c-c3771e50977e"), 0f, "temperature" },
                    { new Guid("7e8596d5-f7fa-4ac4-81d8-b2d94c5e32c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("afcd5730-636d-4f93-b3be-dae8d634ba14"), 0f, "temperature" },
                    { new Guid("7ebee11a-0cb2-441e-828a-546b8124f123"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("06bdf98c-cf01-4c4c-b06f-041a9c77cffa"), 0f, "temperature" },
                    { new Guid("80592886-e8af-4cec-9478-ae596eb60f68"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9492a112-5d4a-4a2e-beed-2f9dcb4f4f69"), 0f, "temperature" },
                    { new Guid("80b40ded-9840-492b-b675-8fe0a1409e79"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("432f36fb-ee54-43fd-8642-e6570673b9c1"), 0f, "temperature" },
                    { new Guid("8122edee-5d0d-45f4-be40-7162a909f0d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c33dc415-a534-40dc-bdbc-cfe822c09686"), 0f, "temperature" },
                    { new Guid("8139ae0b-82da-4515-9f97-9cf0116d7885"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("89bf4b9a-7774-4b23-8d06-4ddb718f68ae"), 0f, "temperature" },
                    { new Guid("813a7e3f-cea1-417a-a50b-7e14cced46c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("99689ade-3f30-454a-aa34-5bfbceb92a48"), 0f, "temperature" },
                    { new Guid("82b9739c-23b0-41ef-b5c1-8b46b2c655d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07816c2e-c5e3-4371-9848-b7f70413682f"), 0f, "temperature" },
                    { new Guid("832373ae-387a-42d1-9fb5-7d7b5eada849"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a11917ba-5783-4666-aa9c-01a9c07a5b85"), 0f, "temperature" },
                    { new Guid("867943d3-f157-45df-b0c6-c4de138a8988"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0e6f3b2-9767-418e-bb45-08d14a743dc7"), 0f, "temperature" },
                    { new Guid("86e5c4ec-8e30-4c8d-b6cb-938cbe0cbda8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f804d155-b16a-4fb0-a495-c602145b2d35"), 0f, "temperature" },
                    { new Guid("881a5d23-b2bb-44a6-a6d8-226de866c9b8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b6bced1f-660e-4be7-8a76-184eb1910b98"), 0f, "temperature" },
                    { new Guid("8912ce9b-0032-4ccf-8552-2cba73f97fc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed340be0-af9e-40b1-a56f-9258daa801ed"), 0f, "temperature" },
                    { new Guid("894902be-6130-42ad-b4ba-a87c69a6e8a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e0c98c1-4801-4580-b146-feaf6d06ca21"), 0f, "temperature" },
                    { new Guid("89b47ff8-67af-4938-97f8-4b1899faca87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("372c452b-c0d3-43e2-ad6c-a2076a6b4bfc"), 0f, "temperature" },
                    { new Guid("8a89488b-c335-4a26-8d9d-04856313c764"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5dd10d0-3207-47b5-a800-e8353966e7ee"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("8afc042d-211d-4a1a-90f2-e787a51f3b37"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a981d9ab-2f04-45ed-a84f-19f5122c1e60"), 0f, "temperature" },
                    { new Guid("8b2036a6-2683-4e76-8838-0da23e20a936"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67983bfb-3241-4669-a29a-c8d91f1bbe1a"), 0f, "temperature" },
                    { new Guid("8db56814-2a97-4c09-b487-56abe9886d28"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("946c8e72-1b49-4f77-ac48-6e3c09658f8e"), 0f, "temperature" },
                    { new Guid("8dc3c88e-d999-4231-896c-dc3a920a03ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c4010df5-a87b-4e50-ad38-61d583f9e4a0"), 0f, "temperature" },
                    { new Guid("8dd401d5-0b68-4d54-a75a-53effd7e3ecd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b47a444-8d5d-4b3b-92f3-627bd1e38bb2"), 0f, "temperature" },
                    { new Guid("90b030b9-86d0-4b4b-961d-57affbf3762a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4e349fa9-0195-46db-af05-6cb4398c608d"), 0f, "temperature" },
                    { new Guid("913add9c-d821-42ee-a679-305a2e1bc645"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0d61ce95-9bdd-4ae9-9041-0f1d8c1c47d5"), 0f, "temperature" },
                    { new Guid("91d4a044-e559-4c3d-a28e-2b03f092816c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("90c1f950-8dc5-452d-b773-0207969d751e"), 0f, "temperature" },
                    { new Guid("92d9e5fc-bc0b-4a88-9497-46382dad2357"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f019efb6-b645-497c-b15a-8830b9cd10b0"), 0f, "temperature" },
                    { new Guid("92ee68da-91d1-4a1e-b73f-5fe185cce371"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9d8065f9-7ebc-4bbe-8141-7d01c7a281cf"), 0f, "temperature" },
                    { new Guid("96845861-9231-4b0a-892d-9b4bcf70247d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8cd55929-312c-4fc1-827d-83895dc41689"), 0f, "temperature" },
                    { new Guid("96fd331a-89d5-4890-ac58-f595624f0769"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d40a696-f958-48f4-82ea-f56dad875b99"), 0f, "temperature" },
                    { new Guid("97ec028b-7944-467d-9ef7-1a509ab518cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c95858-b9c4-45bd-8c66-a9583a14f8af"), 0f, "temperature" },
                    { new Guid("99596f31-e376-4ebe-ac67-246154f0590c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8ace114-4df6-43b5-b3f4-4e275c8ca6d7"), 0f, "temperature" },
                    { new Guid("9cd9f2ec-f064-40fc-a81a-e53c98372931"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3d49e50-07b9-4b92-831d-00c53ce9e44d"), 0f, "temperature" },
                    { new Guid("9e1220a2-c653-48f2-84af-b1f406356b15"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c0cb43ab-d19c-40ef-9ea1-77fdde54cacb"), 0f, "temperature" },
                    { new Guid("9ece676b-fb5a-46a5-b477-8ea400d3ad21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a631afa-200a-438e-8d02-c7dda20abdc1"), 0f, "temperature" },
                    { new Guid("a1407073-461b-4464-993b-d50f27509a62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56c3ad72-a9a0-4008-b1a3-440fd66e3598"), 0f, "temperature" },
                    { new Guid("a142e5fd-0841-4ec6-8ca3-9789f51acb25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("004c39b9-8df6-4a76-bca1-94b76f1afeda"), 0f, "temperature" },
                    { new Guid("a3b84e5c-b6a3-4c04-937a-e49881538df3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1b5afd1d-620a-485b-9919-cfad67d20842"), 0f, "temperature" },
                    { new Guid("a449073e-5f57-49ec-965e-76c8c5d515ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("432bb492-64d5-4ea9-8817-56c5a42fcb8b"), 0f, "temperature" },
                    { new Guid("a5523d7c-f99e-48ee-9674-c487ddf2d0f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ee3095be-8ac4-4a84-afe3-1c5c8f8de697"), 0f, "temperature" },
                    { new Guid("a57ac0dc-343d-4009-b839-6c3e5481d666"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d367a4e-0894-4688-9c74-e674565066c7"), 0f, "temperature" },
                    { new Guid("a76303c9-14e2-4090-b53a-7d0cc426f2d2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("52a1cc3c-2ec8-4972-ac19-4b3cab18f09e"), 0f, "temperature" },
                    { new Guid("a7ab0d46-7b7e-42fe-ae9f-306ce6a7c522"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af545fe7-ede7-4296-aedc-37d36de69117"), 0f, "temperature" },
                    { new Guid("a8b5dce8-69eb-4d37-a972-d531cfdd83c9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("79614a50-d885-4f5e-b68f-af653456ee09"), 0f, "temperature" },
                    { new Guid("a9d59358-5da7-4fe3-925f-3e9740999a5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e68811da-16c5-471b-ac16-f632e42813bd"), 0f, "temperature" },
                    { new Guid("aad9d7cf-a5a5-4730-a514-a63885cf8aa1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("478fcb2b-8fa9-4f19-a1e8-aabc39e418df"), 0f, "temperature" },
                    { new Guid("ab7aeeb2-e769-4ad9-912c-c98aa214b7bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1338642f-79cd-43d0-9cd0-db4896818268"), 0f, "temperature" },
                    { new Guid("abb57794-3af5-439b-bd09-6775f78ec46c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("708595cd-8929-4dca-809c-26d3b5299f31"), 0f, "temperature" },
                    { new Guid("ad571b3c-79ec-45a3-94a5-d2cae5c17bf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d73d1c80-edc6-4e04-8bcf-31311216b5bf"), 0f, "temperature" },
                    { new Guid("ae0139b4-0876-44fc-a643-2c619d8c715b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("87e696bf-6435-4959-bff6-f9aa7e672a04"), 0f, "temperature" },
                    { new Guid("aef59d40-2b72-4056-86bb-6588898d576b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2f47b2f3-36c4-4e9c-9a6d-f9df88e3411b"), 0f, "temperature" },
                    { new Guid("b0587df0-556a-469c-b04f-ebb9639812ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8e84726-f0f4-47a6-b939-597f27c1d938"), 0f, "temperature" },
                    { new Guid("b06a1781-8ce7-476b-ac43-ecb64f6a62a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4d518ac0-ca83-4d9b-a988-cb046d29d49b"), 0f, "temperature" },
                    { new Guid("b0b24073-9f12-4a98-a69b-703d789bba1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8d2cf0b-4678-44ae-a9bf-2a736156a227"), 0f, "temperature" },
                    { new Guid("b28db78b-6cf7-42ea-8f71-9c196d8fd503"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eca1972d-7b6c-4c00-ac0c-173dbe888686"), 0f, "temperature" },
                    { new Guid("b31a6649-90f2-482f-9fbc-945fe3aa2756"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c0ba2f01-15f3-4ed5-bfc2-3475ce99aa17"), 0f, "temperature" },
                    { new Guid("b31bce71-2431-4325-9e99-6df11b11269d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("38d12425-926f-401e-b654-746a59ce4f4c"), 0f, "temperature" },
                    { new Guid("b409d1b5-757a-4613-ab29-c2f0acb18374"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dfe8ecb3-7022-4dac-97cf-c42378efb527"), 0f, "temperature" },
                    { new Guid("b4346be7-022a-47ab-a009-08102d017e19"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fae33872-0420-453f-973e-f02f5b7bd54b"), 0f, "temperature" },
                    { new Guid("b473a8dc-15e7-43c0-9785-a1d19dc1528b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7f7d5218-b5bf-4413-a139-c6d03da54564"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("b6bf7f4e-005e-482c-ba9a-1cf7063f117a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f1d6ca19-a19d-4ee2-a368-482de20c4bdb"), 0f, "temperature" },
                    { new Guid("b726359a-2e85-4f42-a4d2-15685443d90a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7b307a2-aedd-4d6f-b356-cfe243da357e"), 0f, "temperature" },
                    { new Guid("b7b223c3-3c13-4161-8cc5-dd88c6262e53"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cae5185c-a317-4d2d-a29c-859e5fd90728"), 0f, "temperature" },
                    { new Guid("b7d7ea52-11bc-49ff-be20-621dba4260d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("163efe68-d35b-462d-90de-2a88e4bb76da"), 0f, "temperature" },
                    { new Guid("b8567bb9-18e1-4c61-b784-9afe68cc96a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("15427750-a742-4bfe-9abd-2f02e4972da3"), 0f, "temperature" },
                    { new Guid("b9017fe6-85e4-4f93-afb1-be29c9e04ea2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("504562f7-6896-4133-bdea-9eaf57f46328"), 0f, "temperature" },
                    { new Guid("b935b1fe-ba6d-43a7-9def-d9401bb7488a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de92bc01-03b7-4d28-a3b2-51c91a78ac3d"), 0f, "temperature" },
                    { new Guid("b995b59e-da01-43ce-bf5c-2d0d7fde49f4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6cd3bd1-f827-4755-b5eb-ba660bd7cb31"), 0f, "temperature" },
                    { new Guid("b9d58800-e954-43d9-8e76-359c005b68ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f7184a87-9e1e-48a6-88c4-a3156c046a6d"), 0f, "temperature" },
                    { new Guid("ba55efa8-a3ac-46c4-9be1-e4d8c4817075"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1f7be98e-d2ea-40fd-87a5-bc525632c229"), 0f, "temperature" },
                    { new Guid("ba94e0b9-7e39-4ce2-99f9-3edae9a78311"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5ad82856-3166-41b2-84a1-4e1c72f859ac"), 0f, "temperature" },
                    { new Guid("ba9f5ab3-09e2-4e30-9e25-9fadeb578c3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0a65c2a7-1617-4364-ac1e-3b267c6158c0"), 0f, "temperature" },
                    { new Guid("baf1dacd-289a-4645-a52a-ffb5bbb10ab8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da7bab1d-b20a-4697-b429-bfe14aa3665b"), 0f, "temperature" },
                    { new Guid("bd74ee27-a441-43ed-996a-f4606304cb93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3e47dd93-5962-4720-9ba4-89342df9c177"), 0f, "temperature" },
                    { new Guid("bd8bbbed-78ff-4503-8e93-259806326ab6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6d30affe-85d5-4817-886c-2d34644ba368"), 0f, "temperature" },
                    { new Guid("be6a058c-8896-42e9-b1bc-29097a065ac9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77ba404f-23ba-4edc-b055-65c1e93efa07"), 0f, "temperature" },
                    { new Guid("beeb6bd7-66d7-4bdd-8bb5-0bc68ef2a8b8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2e7ded23-b233-47b6-8533-9f942176cf30"), 0f, "temperature" },
                    { new Guid("bef873cf-ffab-4550-8778-ce44b4adafb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("13c8a99e-68c6-4f1f-8db0-876a16900638"), 0f, "temperature" },
                    { new Guid("bf169b49-4912-4cce-b231-b3fc4f848b9d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("095d98f6-cf78-41e3-97f4-651fca6a3f52"), 0f, "temperature" },
                    { new Guid("bfd9bdbb-390e-4a01-b17b-4e411ce22795"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("959ceb53-f516-4625-96b6-f6684ae322c1"), 0f, "temperature" },
                    { new Guid("c01e83f0-481c-4a91-9628-c0def0581cc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5106bc19-32fa-4913-afc0-fd0bdf48cfc0"), 0f, "temperature" },
                    { new Guid("c09968c3-f2eb-4b19-85e6-dadbaae69e0c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ec01f1d4-5e35-4a7b-8a1c-66ed4f7e5087"), 0f, "temperature" },
                    { new Guid("c149f9bc-3b89-447d-a1a8-e783872d7e7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0fa63be2-cce2-46cd-986e-cc62ff70e965"), 0f, "temperature" },
                    { new Guid("c1691c73-8440-40a4-9ea9-51193a09447d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("858d99e8-ee92-4940-9b8f-b1abe48a2816"), 0f, "temperature" },
                    { new Guid("c2ca8e4e-628f-4697-b425-28e829f6220a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8448f3d-6270-4f1d-a334-782121e099f0"), 0f, "temperature" },
                    { new Guid("c30873d2-688a-4837-bd70-bc0fbc59b408"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("519ce6b5-b0ef-4aff-b1aa-e140f6ee0411"), 0f, "temperature" },
                    { new Guid("c6d18823-54ac-41e1-8fab-66f315afcd49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab6a4aa6-8896-4829-8e80-849f70d51837"), 0f, "temperature" },
                    { new Guid("cadce383-677b-4a0f-a96d-5d57415590ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ee33c962-15d8-4d30-9b24-d4c1ef2e3897"), 0f, "temperature" },
                    { new Guid("cc36e963-3f96-4c92-8e5c-1ccf7a08d086"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("62bac3f1-c3d0-435b-bce1-a144b6e19a37"), 0f, "temperature" },
                    { new Guid("cdbd6952-67e8-4d6c-ac90-ec3b8e9d215d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("351a4307-2ac9-4269-a33e-75d6f7fe57b8"), 0f, "temperature" },
                    { new Guid("cf0df238-1748-42a5-a980-31355e91de66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d92545c7-9f34-435e-bbc1-9fa4ce790cce"), 0f, "temperature" },
                    { new Guid("d0b2f704-2100-418e-888e-f564982a2f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("655301c3-22fc-4b06-a9f9-71c91c2dd25d"), 0f, "temperature" },
                    { new Guid("d11dc4fa-9658-4be5-99ed-bd6eacc16a0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9931b53c-e5e0-4844-93d7-b304e2c409c7"), 0f, "temperature" },
                    { new Guid("d167e4c7-b49a-4919-aa1b-dbccc97bc03e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3193f56-a0d6-4682-8c31-27f0996cf95f"), 0f, "temperature" },
                    { new Guid("d190ec6e-3390-48bb-82e3-2b2b37abeb23"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d9f5998e-b9d9-4ffc-9374-653845d46d34"), 0f, "temperature" },
                    { new Guid("d6dfab81-c8ff-47e7-84a1-c27e9010f8e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("623a10b8-a98d-4020-bc89-f20f0b266150"), 0f, "temperature" },
                    { new Guid("d6e2eef0-364e-4851-89ad-a42b5d8a2aae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b279f8cc-3084-4cea-90fe-ae0dd21452e0"), 0f, "temperature" },
                    { new Guid("d72fe449-239a-4059-97cc-9a8eba0a515b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dcf95031-c844-4c25-a274-3350aea2707e"), 0f, "temperature" },
                    { new Guid("d8ff628e-3293-4c5b-885f-81d6b839ce59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2a183345-b316-4a47-90bd-3c97850377ac"), 0f, "temperature" },
                    { new Guid("d9510c4c-1262-4637-90c4-e626c3aa1a14"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9bf3e9fe-08a1-4018-9494-90e08ec3e2dd"), 0f, "temperature" },
                    { new Guid("d9ab35b6-9358-4653-9013-9fa019b5fe3d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9956f904-1115-4419-828c-8b14b4ff10f3"), 0f, "temperature" },
                    { new Guid("d9dd677a-9bd0-4202-833f-1de554dabd6c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a69c11e3-7ceb-4710-b5e0-547fbf073af9"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("dac66d60-3188-4811-b300-79d0d9a8685c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7e634c56-d74f-4e34-aeab-db48331ae76e"), 0f, "temperature" },
                    { new Guid("dbc68de9-0611-41c2-8393-ac49a9f649d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f4c189b0-de1a-41ca-a228-0daffc96d344"), 0f, "temperature" },
                    { new Guid("dcb63ddb-b12c-4518-ab8f-55e79b7c011f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a917fa3-df45-4613-b901-dcc38a2affa9"), 0f, "temperature" },
                    { new Guid("ded6527d-ae1a-437a-8807-533d101c94b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("03daddbd-b732-4d88-af97-0103f16da2a9"), 0f, "temperature" },
                    { new Guid("e045f97d-383d-4968-a270-71b0f3b50450"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dcc16215-013a-4413-be84-52fd24f6ff88"), 0f, "temperature" },
                    { new Guid("e04c6f0b-80f6-455f-a540-57d85e93c8be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4140248d-4c46-44ea-8fcb-e741eaa9e0dc"), 0f, "temperature" },
                    { new Guid("e085aa43-f612-49cc-b7cb-95cef2f97522"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5b5467c-68c3-42de-95e6-86f20fc34fa5"), 0f, "temperature" },
                    { new Guid("e0a33238-4461-4fc4-97b3-85d7ff2db8d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6249fd54-f295-4a17-96cf-ecced96e6a7f"), 0f, "temperature" },
                    { new Guid("e0b5e144-8199-48db-a29b-e45d22b4d9b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0ef8931-edcc-49ae-a34c-83334ab77201"), 0f, "temperature" },
                    { new Guid("e12cdde9-4c87-4e4e-b07e-bd772b05e17f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9e8b77d7-433e-43c1-a6e4-5acbb05044ae"), 0f, "temperature" },
                    { new Guid("e16f47e9-30ac-47d3-8200-942c4f2c0abb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("59992267-47dc-46c9-a986-bd69172131e5"), 0f, "temperature" },
                    { new Guid("e1db005e-c7b4-4bae-82fa-61793df261c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b822672f-96e8-463d-8970-277c6f27a516"), 0f, "temperature" },
                    { new Guid("e1ef8872-ac05-45cc-8fca-67f776865041"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1e189537-622d-4756-a6c0-7bafcb2602b0"), 0f, "temperature" },
                    { new Guid("e41b0897-5ce9-4d9f-ab10-6b03fc7136fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d39e4e24-0e6e-48ad-9866-5642994455d8"), 0f, "temperature" },
                    { new Guid("e4605476-7a28-431e-915a-1ea630093845"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9ba7a2e1-715a-47e7-af47-a2a00cc55398"), 0f, "temperature" },
                    { new Guid("e46d1831-7a7c-41c0-9bce-b251d24d6cdf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("19aae055-60ec-4e94-b22a-a857763494bd"), 0f, "temperature" },
                    { new Guid("e47d823a-b468-4874-833d-14d2a8075b3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a35c5687-1085-4b0d-bb78-8433997941b8"), 0f, "temperature" },
                    { new Guid("e50732c5-389d-4ac3-a6f8-d05f17c27cf5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18e6362d-a2a5-49cf-8e29-70159a47ae4b"), 0f, "temperature" },
                    { new Guid("e5d3a331-ef10-47d7-80c8-eae1c8acda39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4a143b30-61cc-418b-a367-f1d4a4845f28"), 0f, "temperature" },
                    { new Guid("e69d94f5-d4f6-4487-8abc-1087a7ef54d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b89e92ae-adf2-4530-8cdf-4820048646d5"), 0f, "temperature" },
                    { new Guid("e6ba762c-7e42-4e6e-b6c9-e30691c6d288"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a44d4530-77d4-41c7-88fd-8f32b24d6c65"), 0f, "temperature" },
                    { new Guid("e829d8f7-b59d-48d1-901e-5b79feadb71d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63adac26-d7d5-41a6-82fc-584cea713c06"), 0f, "temperature" },
                    { new Guid("e87b2b13-b044-4821-b095-ac4e43baa59e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22312cdb-2883-45c4-b7d5-e776c0885956"), 0f, "temperature" },
                    { new Guid("e98075e1-d9ac-4730-9744-4f9c719b2857"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1a6b12ac-29f7-42c3-9d79-71159ccf4a3c"), 0f, "temperature" },
                    { new Guid("ead083e0-e754-4e68-86a3-dfa0eea478af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5ec986d6-dea3-482d-bf81-a6ac6d71027f"), 0f, "temperature" },
                    { new Guid("eaf4c9e3-32d5-4287-a7ce-69b694bacf42"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f4d03fe-5276-4456-a151-26715eef9182"), 0f, "temperature" },
                    { new Guid("eb03991e-6e1b-4e2d-85c6-c44407637412"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7aafc80c-bc66-436f-a5bb-31115be20f3b"), 0f, "temperature" },
                    { new Guid("ec0b53e7-19d2-4207-a0ca-1e2b9dceb808"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dde4d4e3-19d1-4f86-ac4a-bc2b0caf1f61"), 0f, "temperature" },
                    { new Guid("ed83866e-d994-4a01-b58c-1917167e44b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f804df21-97c0-43e9-9f12-f052ba20060b"), 0f, "temperature" },
                    { new Guid("ee0fe36c-618d-4f5f-9b4d-57d74cd7ea34"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("38eb8f8d-bc09-49a7-9a87-54b3f546f5ba"), 0f, "temperature" },
                    { new Guid("ef4c59ec-7f33-4fa7-9521-4566c16afa55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f90afd1c-c1cb-4844-ab6a-40f52a97b6a4"), 0f, "temperature" },
                    { new Guid("f269ab06-8e80-41f6-8d4e-1cc8d89cd99b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5bb3753-9a0c-4750-85dd-1d880e3fdf16"), 0f, "temperature" },
                    { new Guid("f343201a-f294-4347-84a2-06599fd544f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72aae393-9fac-49cd-a893-a400c23467ad"), 0f, "temperature" },
                    { new Guid("f56bac51-35a8-4279-bfcb-a23f7dd812bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24d44f42-6a1b-4dca-a806-01bb93dad1eb"), 0f, "temperature" },
                    { new Guid("f5a66d64-2a3d-4e59-9dc3-620826addf24"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("54e7b7d7-b5bf-45a5-9b46-4280581206c7"), 0f, "temperature" },
                    { new Guid("f5e2fd72-aa7e-4639-a6ad-ac1da7570cf3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("782c49c4-ce5f-42c2-b4ef-565c1278a650"), 0f, "temperature" },
                    { new Guid("f78098a9-aa92-4067-a702-98e8e11a9d4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ca98599c-524b-4844-8ad7-ed6aa565c4ad"), 0f, "temperature" },
                    { new Guid("f7e8febc-5ab1-489d-b26e-bd2e77ac00c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6c6ac71e-f86b-401a-881b-f2ee14b86575"), 0f, "temperature" },
                    { new Guid("f81ad3c1-c7ac-42d8-ad64-a1fdc382c473"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2d36008-edb8-44d1-82c1-6721e109556b"), 0f, "temperature" },
                    { new Guid("f8abf117-3678-4c85-9edb-9aa601de7407"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d20aa4c5-0c3c-48b1-92d4-c6e90866140c"), 0f, "temperature" },
                    { new Guid("f8d15772-2c81-4b34-81d9-2482c3ef79cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2bb831cf-49c4-4c69-ad8e-218f0e664ca8"), 0f, "temperature" },
                    { new Guid("f91a1574-bf55-4f60-b6e4-5a6be6123685"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27e0229e-0fa3-43bd-b13e-d4b86fa1bb17"), 0f, "temperature" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "ChangeTime", "PlacementId", "SensorValue", "Type" },
                values: new object[,]
                {
                    { new Guid("faeaf406-43e8-4f95-99ae-7315a319c605"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5e025f29-b281-4259-836f-bb3f1733d09b"), 0f, "temperature" },
                    { new Guid("fbb7b232-5af9-41fb-989d-d80a3aaecc99"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1743d732-2892-4a67-a886-fa06072f9d56"), 0f, "temperature" },
                    { new Guid("fbbe55ed-3d88-4ca3-af4d-b881d540a81f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d906a92f-6433-4980-8e71-ab48058cd98c"), 0f, "temperature" },
                    { new Guid("fbf9d647-76f4-427a-b0a7-c03ac3979fac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9161b03d-ee93-4a5b-943e-a17cbd3a763c"), 0f, "temperature" },
                    { new Guid("fde76c1f-06cd-4850-acfd-e8c11af42dfe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45ae7d7f-39c6-4d56-90ab-99a59537f90c"), 0f, "temperature" },
                    { new Guid("fe1a2409-b5e9-47dc-8cd1-eeb5a0b9f39a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0861cffe-19b4-4450-b213-cc87559d72e5"), 0f, "temperature" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сottages_UserId",
                table: "Сottages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_CottageId",
                table: "Placements",
                column: "CottageId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_PlacementTypeId",
                table: "Placements",
                column: "PlacementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_PlacementId",
                table: "Sensors",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "Сottages");

            migrationBuilder.DropTable(
                name: "PlacementTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
