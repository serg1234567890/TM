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
                name: "Сottages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сottages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorTypes_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RoleEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a6246a17-3a9a-447b-9c33-0ab5f675fe59"), "admin" },
                    { new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), "person" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("010953d8-9263-4e81-8d31-9aa68574a73e"), "First name 92", "Last name", "person92", "person92" },
                    { new Guid("05473a76-9a09-490f-8e70-20814d951290"), "First name 66", "Last name", "person66", "person66" },
                    { new Guid("0556b11a-7e36-432e-9d4e-5b5966ea0aa7"), "First name 27", "Last name", "person27", "person27" },
                    { new Guid("06730fcb-1517-4984-86c1-fac42f3cd1e0"), "First name 75", "Last name", "person75", "person75" },
                    { new Guid("09376356-9f8c-4188-a379-da6156c1e303"), "First name 76", "Last name", "person76", "person76" },
                    { new Guid("0b3482cc-d278-41a3-b5bf-a4831ad971e9"), "First name 20", "Last name", "person20", "person20" },
                    { new Guid("0f5ddd09-e2b6-428b-88f6-17364cae4ccf"), "First name 18", "Last name", "person18", "person18" },
                    { new Guid("1019d3f0-8650-4aa7-a311-03cb3c8eef86"), "First name 74", "Last name", "person74", "person74" },
                    { new Guid("130da61d-dee5-4584-96ff-6b7803ace3ae"), "First name 43", "Last name", "person43", "person43" },
                    { new Guid("15405ef4-d151-4ee9-83d0-e7e20606440f"), "First name 23", "Last name", "person23", "person23" },
                    { new Guid("16419431-30d1-40c8-bd79-24f5bf96f38f"), "First name 32", "Last name", "person32", "person32" },
                    { new Guid("16a55a72-229f-4fc4-a309-08f0f9c8cbc1"), "First name 72", "Last name", "person72", "person72" },
                    { new Guid("171d4f92-2827-4a25-bf6a-59100309867e"), "First name 11", "Last name", "person11", "person11" },
                    { new Guid("174b95ed-c6fd-4ee4-8b32-1ea6c0e0d5b9"), "First name 54", "Last name", "person54", "person54" },
                    { new Guid("1f7fb911-c33f-40e3-8a2f-60bae37449e1"), "First name 9", "Last name", "person9", "person9" },
                    { new Guid("24c4fd20-3cf2-46f6-8f09-1f8018aabfa9"), "First name 48", "Last name", "person48", "person48" },
                    { new Guid("25f6bddd-f3f9-4a60-ae23-969fb47e8bbc"), "First name 53", "Last name", "person53", "person53" },
                    { new Guid("2681412e-e0ff-4bad-8856-7e8c04fde8d6"), "First name 60", "Last name", "person60", "person60" },
                    { new Guid("26d647e9-1cf9-42c9-9ab5-fefec84fccc7"), "First name 56", "Last name", "person56", "person56" },
                    { new Guid("274d0a64-9627-47d0-b671-7f7ae3b6a55c"), "First name 2", "Last name", "person2", "person2" },
                    { new Guid("2b6d1417-9f95-43b9-981c-1ec4d3c65bf1"), "First name 69", "Last name", "person69", "person69" },
                    { new Guid("2bfb5113-39b6-47f9-8395-4e22fc1138a5"), "First name 51", "Last name", "person51", "person51" },
                    { new Guid("2c30d9fd-7490-4f4f-9ddf-83ad478f7d04"), "First name 100", "Last name", "person100", "person100" },
                    { new Guid("2c32dd7c-8112-4f45-99b9-01e5ae5eef6f"), "First name 64", "Last name", "person64", "person64" },
                    { new Guid("2efd74fb-e7d5-4d18-86c0-fa77600ba76d"), null, null, "admin", "admin" },
                    { new Guid("2fcf5865-69da-4fb4-a9f9-a6890499fdf1"), "First name 31", "Last name", "person31", "person31" },
                    { new Guid("307fcb6a-d491-44cf-9318-5cd7095052ac"), "First name 15", "Last name", "person15", "person15" },
                    { new Guid("38e5638f-07d0-4142-a7ef-ce9958dbf927"), "First name 71", "Last name", "person71", "person71" },
                    { new Guid("420aba1f-8646-4f5a-b5a9-c9f4f1147666"), "First name 99", "Last name", "person99", "person99" },
                    { new Guid("48633b8c-73a4-4d5c-b86e-7149eb31b2c2"), "First name 1", "Last name", "person1", "person1" },
                    { new Guid("50473396-40b2-4362-9f6c-b4888f8f878a"), "First name 82", "Last name", "person82", "person82" },
                    { new Guid("51ab2064-0dcd-4d82-8a28-48885fb3dbd5"), "First name 84", "Last name", "person84", "person84" },
                    { new Guid("5277dcf1-1414-49a6-b7c1-22533e214baf"), "First name 29", "Last name", "person29", "person29" },
                    { new Guid("52e4a79b-f5bf-4889-8d6b-5f96778115b5"), "First name 79", "Last name", "person79", "person79" },
                    { new Guid("556eb268-2299-46da-b597-b3ab43f442b0"), "First name 55", "Last name", "person55", "person55" },
                    { new Guid("56f41414-9a58-4d26-867f-2e709286d0a9"), "First name 28", "Last name", "person28", "person28" },
                    { new Guid("611f0c5e-4b56-4797-872c-4209a07493f4"), "First name 83", "Last name", "person83", "person83" },
                    { new Guid("6381e5a1-0404-4862-9f65-a3f8615ce3d3"), "First name 25", "Last name", "person25", "person25" },
                    { new Guid("6812304d-f5b2-45ea-b3e2-d505af72d1c4"), "First name 89", "Last name", "person89", "person89" },
                    { new Guid("6a722c6c-a404-42cb-adb4-b704d329a29a"), "First name 49", "Last name", "person49", "person49" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("6ef9efb7-2515-4fb2-89ae-aad56c8c5c1c"), "First name 17", "Last name", "person17", "person17" },
                    { new Guid("6f3b8b5b-feb4-4380-87b3-caf109f2c51b"), "First name 42", "Last name", "person42", "person42" },
                    { new Guid("7119af9b-93e5-49fb-8870-29c6ff787e85"), "First name 45", "Last name", "person45", "person45" },
                    { new Guid("7208d4f6-a299-4435-9ae8-ddb81e4e6551"), "First name 88", "Last name", "person88", "person88" },
                    { new Guid("7de654fb-af59-4279-b300-051e17055555"), "First name 68", "Last name", "person68", "person68" },
                    { new Guid("7e2929b7-c8b3-445a-ba0e-cbd1f57eef81"), "First name 81", "Last name", "person81", "person81" },
                    { new Guid("7e7d049a-ae40-4179-8ce3-99bef396095f"), "First name 96", "Last name", "person96", "person96" },
                    { new Guid("837ee3d3-ced2-4d6f-a555-e2920e960a77"), "First name 30", "Last name", "person30", "person30" },
                    { new Guid("83df782d-5e2b-4aed-947c-f5d7bd124ded"), "First name 78", "Last name", "person78", "person78" },
                    { new Guid("87602d81-989c-4985-9850-2e52f30b154f"), "First name 21", "Last name", "person21", "person21" },
                    { new Guid("8c051532-4b47-4344-b2be-e70261778f71"), "First name 19", "Last name", "person19", "person19" },
                    { new Guid("8e91287d-1b50-445e-bfa7-c18e311fd828"), "First name 3", "Last name", "person3", "person3" },
                    { new Guid("8eb2ad8e-9b63-477d-90ac-4b1a6b759ad4"), "First name 13", "Last name", "person13", "person13" },
                    { new Guid("90e30517-60af-4d4b-bd54-8166b6a00017"), "First name 8", "Last name", "person8", "person8" },
                    { new Guid("92ff1108-561c-478f-b1d2-dd0e48acf2c6"), "First name 38", "Last name", "person38", "person38" },
                    { new Guid("93f820d1-66ed-4e75-8907-3649be63de6e"), "First name 77", "Last name", "person77", "person77" },
                    { new Guid("994207df-9173-482d-b1e0-f75de959328f"), "First name 85", "Last name", "person85", "person85" },
                    { new Guid("9a7db461-5cc7-4c14-afac-11c5cc1a3bc9"), "First name 93", "Last name", "person93", "person93" },
                    { new Guid("a03fe766-5976-469f-884f-a725609adede"), "First name 65", "Last name", "person65", "person65" },
                    { new Guid("a321c8f0-e324-40d4-a05a-e4b97b6c3060"), "First name 14", "Last name", "person14", "person14" },
                    { new Guid("a5793da8-abfd-4aa1-aeaa-65d04531428f"), "First name 61", "Last name", "person61", "person61" },
                    { new Guid("a88a4665-0418-41f1-bde7-e1045c58d98c"), "First name 59", "Last name", "person59", "person59" },
                    { new Guid("aa5de081-cf9b-46e2-9238-23474003c011"), "First name 41", "Last name", "person41", "person41" },
                    { new Guid("af89229e-4d2d-4402-9e39-ac21f29804b6"), "First name 34", "Last name", "person34", "person34" },
                    { new Guid("b9362601-3f2d-405a-ae98-423d96917a6e"), "First name 10", "Last name", "person10", "person10" },
                    { new Guid("bb520cd4-f09d-4021-aa81-ba9d0762062a"), "First name 6", "Last name", "person6", "person6" },
                    { new Guid("be34d684-62e5-4839-ab47-5c42812df591"), "First name 91", "Last name", "person91", "person91" },
                    { new Guid("c010ca62-bbe8-42a2-9f4b-87f2c72f5184"), "First name 37", "Last name", "person37", "person37" },
                    { new Guid("c1219f3d-bc69-47f3-9d61-a288cea4af57"), "First name 98", "Last name", "person98", "person98" },
                    { new Guid("c21891eb-5841-40ef-9a0b-6b276e24661b"), "First name 26", "Last name", "person26", "person26" },
                    { new Guid("c5d7dc24-d80d-498c-8c41-7a7062948651"), "First name 46", "Last name", "person46", "person46" },
                    { new Guid("c68969b3-92c3-4107-b2a6-d3c73cd87afa"), "First name 50", "Last name", "person50", "person50" },
                    { new Guid("c8761bea-bb1b-4a8a-afa6-a360a3bd8b48"), "First name 94", "Last name", "person94", "person94" },
                    { new Guid("cb2606a2-8f78-46d2-8dc6-f229d654527d"), "First name 47", "Last name", "person47", "person47" },
                    { new Guid("d0784e39-b445-4001-b4ff-8426234a558a"), "First name 33", "Last name", "person33", "person33" },
                    { new Guid("d8bb8bff-65ac-4a49-942e-0ca69c39bc94"), "First name 57", "Last name", "person57", "person57" },
                    { new Guid("d994d069-fe36-4708-b098-e8b3552ab414"), "First name 35", "Last name", "person35", "person35" },
                    { new Guid("db601f12-2abf-4ff5-8727-7e8cf26c9666"), "First name 5", "Last name", "person5", "person5" },
                    { new Guid("dd0af4fd-8d01-466c-a9ca-3bd23139b2d0"), "First name 24", "Last name", "person24", "person24" },
                    { new Guid("dd3b6d71-0a7f-48fb-83d1-2b40638005ed"), "First name 52", "Last name", "person52", "person52" },
                    { new Guid("de51267b-4b91-410f-b897-b4b19f8bed63"), "First name 80", "Last name", "person80", "person80" },
                    { new Guid("e00c21cd-4e69-49ee-b4d3-39ed16edb72f"), "First name 63", "Last name", "person63", "person63" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("e3340851-09fc-46cb-8064-cb2986cc7b0e"), "First name 67", "Last name", "person67", "person67" },
                    { new Guid("e337f5c1-67ad-478f-8cf8-36bbe8e096d9"), "First name 16", "Last name", "person16", "person16" },
                    { new Guid("e5b4032c-05d6-42cc-8e7f-7cd04e182ae4"), "First name 86", "Last name", "person86", "person86" },
                    { new Guid("ea1039ef-1070-4c2c-9356-5fe1dce73617"), "First name 97", "Last name", "person97", "person97" },
                    { new Guid("edaae3d0-4288-4490-9920-fb1cec2fc934"), "First name 58", "Last name", "person58", "person58" },
                    { new Guid("edd55fa0-10cf-4b1b-b746-f3c2708e3ec5"), "First name 39", "Last name", "person39", "person39" },
                    { new Guid("eeaff2d5-a18b-4a57-b5a9-3b268a51d72c"), "First name 62", "Last name", "person62", "person62" },
                    { new Guid("f0b0c073-c409-43a4-b1f9-e777a90695cc"), "First name 44", "Last name", "person44", "person44" },
                    { new Guid("f0dd1dfd-db2a-4293-8ae0-c1b9b93f3bf1"), "First name 7", "Last name", "person7", "person7" },
                    { new Guid("f2e0fdd3-b90a-4906-b382-b69f88bf8206"), "First name 40", "Last name", "person40", "person40" },
                    { new Guid("f33fe090-f3ab-4b84-9bd0-411f8fa45894"), "First name 12", "Last name", "person12", "person12" },
                    { new Guid("f48895c5-6459-4970-8eb4-b7dbaa397f3d"), "First name 70", "Last name", "person70", "person70" },
                    { new Guid("f51baf9b-9c23-4706-8cf5-6c37d5e9a13d"), "First name 4", "Last name", "person4", "person4" },
                    { new Guid("f7b0dfc1-383a-4c3e-aafe-fd453eda8d0d"), "First name 95", "Last name", "person95", "person95" },
                    { new Guid("f8edad64-b38f-46cd-a212-f4c6ebb647b3"), "First name 90", "Last name", "person90", "person90" },
                    { new Guid("fd0c5457-588a-4840-91e9-7f8d4c959288"), "First name 87", "Last name", "person87", "person87" },
                    { new Guid("fd3581e8-9a3a-4d8d-b115-fad8e9e60613"), "First name 22", "Last name", "person22", "person22" },
                    { new Guid("fd435d92-9c40-41a0-8bd0-c7f6f6236ebd"), "First name 73", "Last name", "person73", "person73" },
                    { new Guid("fe9264e1-5827-4675-b366-de5b1a750a1b"), "First name 36", "Last name", "person36", "person36" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("002d0320-532a-4815-9554-e4da2499236e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("6a722c6c-a404-42cb-adb4-b704d329a29a") },
                    { new Guid("03d7c278-e277-4c83-a040-aa785aac3def"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("87602d81-989c-4985-9850-2e52f30b154f") },
                    { new Guid("07d62031-62b4-4f7f-bc92-64cf78a7d226"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("0b3482cc-d278-41a3-b5bf-a4831ad971e9") },
                    { new Guid("08764e32-5e84-4a4e-84d5-667626fd6d36"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("307fcb6a-d491-44cf-9318-5cd7095052ac") },
                    { new Guid("08fc8ae1-a2a3-463f-9340-64f1d13d8bec"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("8e91287d-1b50-445e-bfa7-c18e311fd828") },
                    { new Guid("0908e9f9-27fe-4dad-b63c-3f9963fadac2"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("16a55a72-229f-4fc4-a309-08f0f9c8cbc1") },
                    { new Guid("09782946-113e-4907-a18b-0416367d8122"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("dd0af4fd-8d01-466c-a9ca-3bd23139b2d0") },
                    { new Guid("09df816c-91a8-41cd-ad56-45a9b14bbb9c"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("af89229e-4d2d-4402-9e39-ac21f29804b6") },
                    { new Guid("0a5c9cd3-ec66-448d-a8f6-9678112616c2"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("6812304d-f5b2-45ea-b3e2-d505af72d1c4") },
                    { new Guid("0abe4546-5e38-4cf8-807b-b7ebf477970e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("93f820d1-66ed-4e75-8907-3649be63de6e") },
                    { new Guid("0e525041-9b87-487f-b5ec-7eeb4cfc31d7"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("6381e5a1-0404-4862-9f65-a3f8615ce3d3") },
                    { new Guid("129f50f8-d07b-43f6-b991-417976420b41"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("6ef9efb7-2515-4fb2-89ae-aad56c8c5c1c") },
                    { new Guid("12d9c171-3d18-4e9c-b513-75926504c5c0"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2c30d9fd-7490-4f4f-9ddf-83ad478f7d04") },
                    { new Guid("18cfa534-d055-4c5f-873d-9364fc41fe3e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("05473a76-9a09-490f-8e70-20814d951290") },
                    { new Guid("18ff980b-6ab4-49c0-95bf-b07bb6e2c81b"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("7119af9b-93e5-49fb-8870-29c6ff787e85") },
                    { new Guid("19f1159c-529d-41b1-bd29-8d856e9b60f0"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c8761bea-bb1b-4a8a-afa6-a360a3bd8b48") },
                    { new Guid("22687a4c-97fe-4abc-96bf-165330698717"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("9a7db461-5cc7-4c14-afac-11c5cc1a3bc9") },
                    { new Guid("25031a45-2104-4aec-8ee9-1b75acc452e2"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f51baf9b-9c23-4706-8cf5-6c37d5e9a13d") },
                    { new Guid("2593d58a-9986-439c-b91b-29829ec21c6d"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("171d4f92-2827-4a25-bf6a-59100309867e") },
                    { new Guid("2bc94ff4-2d7d-4495-98a9-c63ddc5e9f8e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f2e0fdd3-b90a-4906-b382-b69f88bf8206") },
                    { new Guid("2bd60941-818c-4540-8e9a-5a32db46a014"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2681412e-e0ff-4bad-8856-7e8c04fde8d6") },
                    { new Guid("34f7b0a1-60e1-4b2e-9a25-5e94a1dae1ca"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("db601f12-2abf-4ff5-8727-7e8cf26c9666") },
                    { new Guid("36b2bb28-a1ea-46f7-9851-dfc58baf72bf"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("15405ef4-d151-4ee9-83d0-e7e20606440f") },
                    { new Guid("39aa3d26-f09c-4795-8f73-5d88d29d8aad"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("7de654fb-af59-4279-b300-051e17055555") },
                    { new Guid("3aede10e-8e49-47e5-a525-fd70a41bae5d"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f8edad64-b38f-46cd-a212-f4c6ebb647b3") },
                    { new Guid("3f5e2a9c-68b4-4b95-8f28-c8e218c0c9c2"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("6f3b8b5b-feb4-4380-87b3-caf109f2c51b") },
                    { new Guid("44abd783-0165-4b71-a7df-342609be1d03"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f0b0c073-c409-43a4-b1f9-e777a90695cc") },
                    { new Guid("44f34959-0730-4130-aca6-d89d5e71938e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c010ca62-bbe8-42a2-9f4b-87f2c72f5184") },
                    { new Guid("45f2d9cb-39e6-4971-b503-f6b5b6bac0dc"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2fcf5865-69da-4fb4-a9f9-a6890499fdf1") },
                    { new Guid("467f59d1-cdd5-494d-b402-1520bbeb7530"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("e337f5c1-67ad-478f-8cf8-36bbe8e096d9") },
                    { new Guid("475e05a3-6b45-42f1-8317-044ce94698e0"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("a88a4665-0418-41f1-bde7-e1045c58d98c") },
                    { new Guid("4a8ffd03-fd17-4f9d-9cfa-cf3664cf2f23"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2b6d1417-9f95-43b9-981c-1ec4d3c65bf1") },
                    { new Guid("4b22c3aa-1f4a-4870-b354-e903a8aa6ed4"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("e5b4032c-05d6-42cc-8e7f-7cd04e182ae4") },
                    { new Guid("4c991ca8-656a-4ab5-951d-385a20791150"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c1219f3d-bc69-47f3-9d61-a288cea4af57") },
                    { new Guid("4ce2b701-cb67-48f4-b935-faf184e2c8bd"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("be34d684-62e5-4839-ab47-5c42812df591") },
                    { new Guid("53852a35-47b8-4b02-bb59-ebedff6aa23b"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("8eb2ad8e-9b63-477d-90ac-4b1a6b759ad4") },
                    { new Guid("59150efe-00c1-4c72-8fdd-0d9d39da56e1"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("fd0c5457-588a-4840-91e9-7f8d4c959288") },
                    { new Guid("59b9d8ce-5ca0-46a4-b577-5e4bc265d947"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("d8bb8bff-65ac-4a49-942e-0ca69c39bc94") },
                    { new Guid("5f701313-905d-430a-8416-dd82be8a8ade"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("cb2606a2-8f78-46d2-8dc6-f229d654527d") },
                    { new Guid("605be9e4-ef92-480b-b65e-bf4a09199d87"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("274d0a64-9627-47d0-b671-7f7ae3b6a55c") },
                    { new Guid("60afe861-190f-4021-974d-249b08186bbf"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("1f7fb911-c33f-40e3-8a2f-60bae37449e1") },
                    { new Guid("61e69b7e-b5fd-445a-bba0-be0b41a509e7"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c68969b3-92c3-4107-b2a6-d3c73cd87afa") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("64b5c538-cfc1-4eb0-b3a5-1d96cf417eae"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("fd435d92-9c40-41a0-8bd0-c7f6f6236ebd") },
                    { new Guid("6bf7bf93-8757-4d07-b2be-7999c0466c7e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("7208d4f6-a299-4435-9ae8-ddb81e4e6551") },
                    { new Guid("6c0db608-4979-46cf-a468-fd9e28256ae4"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("994207df-9173-482d-b1e0-f75de959328f") },
                    { new Guid("71a785e2-a862-45ae-b445-6d3568bc216c"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("edaae3d0-4288-4490-9920-fb1cec2fc934") },
                    { new Guid("7e364767-a05f-4317-8de4-b06055168065"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("0f5ddd09-e2b6-428b-88f6-17364cae4ccf") },
                    { new Guid("82b1236a-2cfd-47c8-8dae-e748fd570d59"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2c32dd7c-8112-4f45-99b9-01e5ae5eef6f") },
                    { new Guid("8413955c-5672-48ec-b90b-9092da76a754"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("56f41414-9a58-4d26-867f-2e709286d0a9") },
                    { new Guid("85f8a367-1c16-4ae9-a219-5c042c52eee8"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("e00c21cd-4e69-49ee-b4d3-39ed16edb72f") },
                    { new Guid("8ad3f7b0-da1f-4c8b-af3a-9f5d8518eb6d"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("26d647e9-1cf9-42c9-9ab5-fefec84fccc7") },
                    { new Guid("8af571f5-45e8-4a00-b8fe-7a6b6f1de02e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("d0784e39-b445-4001-b4ff-8426234a558a") },
                    { new Guid("8b1e57f9-e95b-4625-8b1b-389c1da478da"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c21891eb-5841-40ef-9a0b-6b276e24661b") },
                    { new Guid("90e0c35f-b5ea-46bb-8d18-0c8008d1370f"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("c5d7dc24-d80d-498c-8c41-7a7062948651") },
                    { new Guid("90fcbe0b-d5c4-4ff6-843d-7bea8a1d7cd7"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("010953d8-9263-4e81-8d31-9aa68574a73e") },
                    { new Guid("982c1643-c6db-4f21-9c23-244c97e36d91"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("52e4a79b-f5bf-4889-8d6b-5f96778115b5") },
                    { new Guid("9dceaf3e-5f1f-42ef-af99-2d95199b0699"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("0556b11a-7e36-432e-9d4e-5b5966ea0aa7") },
                    { new Guid("9f8cd987-e096-4de9-9088-cb35fd9524c0"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("ea1039ef-1070-4c2c-9356-5fe1dce73617") },
                    { new Guid("a1c91278-0c6a-4248-bb5c-1749f0b735fd"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("7e2929b7-c8b3-445a-ba0e-cbd1f57eef81") },
                    { new Guid("a367d9c1-b21e-4fcb-a619-ae8e4cb4ba70"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("420aba1f-8646-4f5a-b5a9-c9f4f1147666") },
                    { new Guid("a514dd2b-1fa8-469f-a039-87680acab0f6"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("24c4fd20-3cf2-46f6-8f09-1f8018aabfa9") },
                    { new Guid("a539e702-bb83-4478-8c8d-5d2f795556b0"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("7e7d049a-ae40-4179-8ce3-99bef396095f") },
                    { new Guid("ac3a0c4a-93c7-4ad1-8b14-ba9e954a94c3"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("25f6bddd-f3f9-4a60-ae23-969fb47e8bbc") },
                    { new Guid("b5e03e3a-a3a6-4e09-9a77-636b803415b7"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("38e5638f-07d0-4142-a7ef-ce9958dbf927") },
                    { new Guid("b948ce7c-576b-44ea-b2ab-099f44c66387"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("174b95ed-c6fd-4ee4-8b32-1ea6c0e0d5b9") },
                    { new Guid("bb17d2fe-b7ee-406e-96ff-c74a0e0c6bb7"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("dd3b6d71-0a7f-48fb-83d1-2b40638005ed") },
                    { new Guid("be3e8b12-11ae-4d0f-a817-3a483487f64d"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("eeaff2d5-a18b-4a57-b5a9-3b268a51d72c") },
                    { new Guid("c3fab6a2-0d33-4cce-9f34-8ad2cccddee6"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("fd3581e8-9a3a-4d8d-b115-fad8e9e60613") },
                    { new Guid("c3fd79d7-fc4e-4b84-bd57-92df8147b892"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f0dd1dfd-db2a-4293-8ae0-c1b9b93f3bf1") },
                    { new Guid("c5dc856a-bf6d-4e14-b606-0417602f1858"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("611f0c5e-4b56-4797-872c-4209a07493f4") },
                    { new Guid("c7ea2415-184a-46a2-af7c-48526398dd99"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("556eb268-2299-46da-b597-b3ab43f442b0") },
                    { new Guid("ca7e42e7-c0af-4e0e-9d8a-ac10c12b6926"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("90e30517-60af-4d4b-bd54-8166b6a00017") },
                    { new Guid("cc392152-6902-47c8-8442-1c3e2d31aac2"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f48895c5-6459-4970-8eb4-b7dbaa397f3d") },
                    { new Guid("cd0118d8-c9b3-4edf-aca4-eece46863cbd"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("92ff1108-561c-478f-b1d2-dd0e48acf2c6") },
                    { new Guid("cd0cb5b8-24f9-43ba-8441-e08a016c3d8c"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("e3340851-09fc-46cb-8064-cb2986cc7b0e") },
                    { new Guid("cd136272-ad27-492c-939d-e4d108945877"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("b9362601-3f2d-405a-ae98-423d96917a6e") },
                    { new Guid("d0f8764f-0c36-4aac-8a82-2b127cbd0df3"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("a321c8f0-e324-40d4-a05a-e4b97b6c3060") },
                    { new Guid("d33dbe32-a398-4a6c-9fdf-9a41d0dd35f8"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("d994d069-fe36-4708-b098-e8b3552ab414") },
                    { new Guid("d34bea6a-f014-41e7-845e-da7b15908fb5"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("fe9264e1-5827-4675-b366-de5b1a750a1b") },
                    { new Guid("d443c5e5-9707-4698-a4f9-e6b1b80ecb95"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("16419431-30d1-40c8-bd79-24f5bf96f38f") },
                    { new Guid("d44dfe91-133d-4869-afcc-342540c6af45"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("a5793da8-abfd-4aa1-aeaa-65d04531428f") },
                    { new Guid("d4655eb9-bfba-4b04-8237-cd68bdbedffb"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("5277dcf1-1414-49a6-b7c1-22533e214baf") },
                    { new Guid("d870d304-9aee-45cd-8b0b-5a3f2d619e55"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("a03fe766-5976-469f-884f-a725609adede") },
                    { new Guid("d957db73-8cc9-4bdb-9e50-c5e7a2c83424"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("aa5de081-cf9b-46e2-9238-23474003c011") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("da3ee545-c2fa-48cf-b054-07b03436f876"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("bb520cd4-f09d-4021-aa81-ba9d0762062a") },
                    { new Guid("e1f3e97c-5847-4439-84e1-9fb3a220067c"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("130da61d-dee5-4584-96ff-6b7803ace3ae") },
                    { new Guid("e43f19b7-46c4-4338-9bde-d1c54b3cf220"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("8c051532-4b47-4344-b2be-e70261778f71") },
                    { new Guid("e8f17446-eeb0-4f8d-8845-d11d45a7d1c5"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f33fe090-f3ab-4b84-9bd0-411f8fa45894") },
                    { new Guid("f11ad8f2-21ed-4256-b26f-ab0c9dbc4720"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("f7b0dfc1-383a-4c3e-aafe-fd453eda8d0d") },
                    { new Guid("f22a1496-4612-4554-a7d0-504431ed2bba"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("09376356-9f8c-4188-a379-da6156c1e303") },
                    { new Guid("f252aba1-cb64-49b0-a570-080181bd41cc"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("06730fcb-1517-4984-86c1-fac42f3cd1e0") },
                    { new Guid("f3f0b1e7-d935-4c67-8e43-0663302fafef"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("83df782d-5e2b-4aed-947c-f5d7bd124ded") },
                    { new Guid("f5af144b-1a8f-457a-90a0-e5bce3ac0080"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("2bfb5113-39b6-47f9-8395-4e22fc1138a5") },
                    { new Guid("f6c664ac-4877-4905-98b5-1e6d07fb7d9e"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("edd55fa0-10cf-4b1b-b746-f3c2708e3ec5") },
                    { new Guid("f8aec5c5-e470-4ca1-a254-6381c14fad68"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("1019d3f0-8650-4aa7-a311-03cb3c8eef86") },
                    { new Guid("fdb7ce6d-50b9-406a-a6a6-64d8a9cd0703"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("837ee3d3-ced2-4d6f-a555-e2920e960a77") },
                    { new Guid("fe41800b-a475-4ebb-90d7-073fa74a4afc"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("48633b8c-73a4-4d5c-b86e-7149eb31b2c2") },
                    { new Guid("fe51858d-dee5-47f0-9c9f-1bcadbaea48d"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("51ab2064-0dcd-4d82-8a28-48885fb3dbd5") },
                    { new Guid("fe54ad36-418d-448c-904d-fec5518b49dd"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("50473396-40b2-4362-9f6c-b4888f8f878a") },
                    { new Guid("ffb1c486-0b21-4447-a9d2-e1a68c3568e5"), new Guid("b150872b-cbe4-4e79-8a99-e6d202ddf588"), new Guid("de51267b-4b91-410f-b897-b4b19f8bed63") },
                    { new Guid("fffb99b5-76c9-4014-8f1d-3dbf615634d9"), new Guid("a6246a17-3a9a-447b-9c33-0ab5f675fe59"), new Guid("2efd74fb-e7d5-4d18-86c0-fa77600ba76d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorTypes_SensorId",
                table: "SensorTypes",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сottages");

            migrationBuilder.DropTable(
                name: "SensorTypes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "RoleEntity");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
