using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSearch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("28eae083-2a81-46d2-8f61-3caef8da407c"), null, "Founder", null },
                    { new Guid("9d913087-d36d-4a5c-ab9d-e9d7845d48e2"), null, "Worker", null },
                    { new Guid("e119c4fb-5ba5-4bd4-83c3-cb8ec2d72688"), null, "Recruiter", null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Türkiye" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8aaf619e-e69e-4178-b5e0-04344d04b429"), "Software Development" });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f4901614-5e4f-4b47-b72b-7a21585263eb"), "Information Technologies" });

            migrationBuilder.InsertData(
                table: "WorkModels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4cfa49e2-005a-45eb-a87d-63a35aa4a1b0"), "Remote" },
                    { new Guid("5cfdd002-0e17-4f85-9785-af001251c568"), "Hybrid" },
                    { new Guid("be2d4821-3c84-4552-b292-6305887b8fed"), "In-office" }
                });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00b46edd-6fc4-4999-a141-a01d95d82ee3"), "Full-time" },
                    { new Guid("6116ed65-8da7-4820-9a92-8bd89caf03ab"), "Intern" },
                    { new Guid("d68427a8-96bb-4590-bf6f-29abbe47733f"), "Project-basis" },
                    { new Guid("e6d8e023-8061-455a-98c1-ed8ccde1db3f"), "Freelance" },
                    { new Guid("eb124238-70cf-41f6-b5a2-f515c25515f2"), "Part-time" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("01c64893-2322-4d97-a57d-2b027d7094ed"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Muş" },
                    { new Guid("026da2cd-32fa-4cce-b439-3bfdd17890f7"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Erzurum" },
                    { new Guid("068d6c9f-846b-43b3-af78-9d715ff377be"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Elazığ" },
                    { new Guid("07bcd57d-aefb-43f1-9e36-d7d4971a5a8c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Aksaray" },
                    { new Guid("0cf93f07-2a12-48ff-b694-5d2deb35fa13"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kastamonu" },
                    { new Guid("0dac1c81-af4b-4b8f-8d29-c6d2a08b35f2"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kahramanmaraş" },
                    { new Guid("10eb6a1c-bd73-425a-819f-1c4152b58504"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Mersin" },
                    { new Guid("15bb8217-3c85-433f-9f7d-6a503993ec3f"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Hatay" },
                    { new Guid("15ed2dfa-cb2d-4a78-8518-a0b002046e21"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Eskişehir" },
                    { new Guid("1e1eb6c5-d6ca-45d1-b019-5853bcfd2a95"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Hakkâri" },
                    { new Guid("1fa3415d-fab0-4924-821f-d749258b1927"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Van" },
                    { new Guid("226992e1-745e-41f4-9b33-a2f25ac0ac5b"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Nevşehir" },
                    { new Guid("22980679-6595-40e9-b6f7-f96a965f9d50"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bartın" },
                    { new Guid("2302ac73-09fd-4842-82fc-d2ce8ccfc86e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bitlis" },
                    { new Guid("2369d340-b894-4118-bb49-9e37307c9759"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Giresun" },
                    { new Guid("27eaf14a-8dea-454e-ba33-bd13b1b45c54"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Samsun" },
                    { new Guid("2c1b05b9-d901-4f59-b339-8aab9f488573"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ardahan" },
                    { new Guid("2f08590d-617b-4959-ae4b-89fa47ececa1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Erzincan" },
                    { new Guid("33cc6a14-8c88-46be-bd54-9248350f4999"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "İstanbul" },
                    { new Guid("341a9ff6-7bf5-4df8-af4a-c0bfe07d89d6"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Afyonkarahisar" },
                    { new Guid("3af8f7ca-d309-40ef-a0f8-70394f3601ca"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ankara" },
                    { new Guid("3b818efa-0481-44d3-9f7f-06f043e3ce60"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çanakkale" },
                    { new Guid("42a19744-173f-40c3-bd72-31a6a5a0e0ef"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kayseri" },
                    { new Guid("42b8c678-5362-42e8-9329-5bcf8356b550"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Batman" },
                    { new Guid("44b7e10b-3119-4dea-9f5f-c381087b5a94"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bilecik" },
                    { new Guid("4d5a174b-464d-4d8f-b0b8-f82e3e8dbfc4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Zonguldak" },
                    { new Guid("4dee908d-51ff-48c7-a981-427da16adcd4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Trabzon" },
                    { new Guid("56ab7d11-a050-4fa9-9606-df9e08976acc"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Diyarbakır" },
                    { new Guid("58347f51-7074-4e4a-b370-f4111d7781ef"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırıkkale" },
                    { new Guid("5a5d5def-8ed7-454f-a2f0-fee36fdcf77a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sinop" },
                    { new Guid("5c2bb592-8e0c-4fce-a2f6-13cdf313e96a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Muğla" },
                    { new Guid("5d2a90ab-587f-4169-91a6-4fc19054bcac"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tunceli" },
                    { new Guid("61f5cf40-8c8d-4769-91c4-b4b0b287b6bd"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Şanlıurfa" },
                    { new Guid("64d5218b-8c68-4af2-ac5e-904a595c569b"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Siirt" },
                    { new Guid("659673b4-05c7-45c0-b943-6ac90746c4a8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Düzce" },
                    { new Guid("66ac5fd9-5117-4213-b801-1708fd1f7bed"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sivas" },
                    { new Guid("6a050542-1f66-4986-b5eb-19cd20e127f8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırşehir" },
                    { new Guid("7ec2f5f4-8c49-494d-b71a-6900916c73ec"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kütahya" },
                    { new Guid("822e1547-f45f-44eb-8c7b-9c48b6511190"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "İzmir" },
                    { new Guid("84f5b8cb-ef95-46aa-8fee-e3add60c0f47"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Balıkesir" },
                    { new Guid("86297fe6-549e-404b-8916-9025151bf72f"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Karaman" },
                    { new Guid("867b407d-5690-4919-b8c5-550ffd8801b8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Yalova" },
                    { new Guid("88775666-3b0b-4a3d-aeae-4f53ddbc51f1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Uşak" },
                    { new Guid("8882f248-a914-488a-9b07-0eedb7890b3d"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Aydın" },
                    { new Guid("89368a6d-5c07-4c63-b4a8-d85ef5863db1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bayburt" },
                    { new Guid("92012984-1a16-4533-8e84-9747f61742b4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Denizli" },
                    { new Guid("92546053-06c8-4df6-8e7b-d9eba9f92891"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Burdur" },
                    { new Guid("9a147d65-8eda-423c-8598-f255d8fa7904"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Mardin" },
                    { new Guid("9a5ae024-ce77-42f4-8b76-b602a5688977"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Konya" },
                    { new Guid("a2bb2a56-2f4c-4e1a-bfad-13b270529314"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tekirdağ" },
                    { new Guid("a67e7220-0581-47ee-ad12-6712d2130e27"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ordu" },
                    { new Guid("ab4bb637-9c6b-4528-8b20-df90248632f8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Şırnak" },
                    { new Guid("afadb6da-1e5b-4b17-ab6b-aa096e287747"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Adana" },
                    { new Guid("afff5fff-7e5d-44be-b600-0acae61e8c46"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Amasya" },
                    { new Guid("b64c35ea-750e-4e24-9270-d96a26e4bac1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Yozgat" },
                    { new Guid("b75df8f3-816a-4f81-a631-58defbe1fed9"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tokat" },
                    { new Guid("b8430d0d-45dc-4691-a9ef-51b41865609e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kilis" },
                    { new Guid("c7062da2-bb46-4870-a11a-9125f4935017"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bolu" },
                    { new Guid("c72f3d87-b5c4-42f6-b758-0ecd9e00903a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Niğde" },
                    { new Guid("c74b2636-c733-4b5a-9c9a-3af49fae855e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Edirne" },
                    { new Guid("c84997da-7f0b-43e8-9186-9aa0161d3f96"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çankırı" },
                    { new Guid("c871e15a-46b5-4e35-badd-05d22b369451"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırklareli" },
                    { new Guid("c9235fc1-deed-48b7-90a7-98bad6bc645c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sakarya" },
                    { new Guid("cb92bfb2-105e-4e2d-a3ed-d9a9956887bd"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Isparta" },
                    { new Guid("ccf13bae-c912-457c-a9b6-d45d22f1f85a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Manisa" },
                    { new Guid("d0e27f5b-69a4-4da4-bd48-34cb33de5e91"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Malatya" },
                    { new Guid("d1398437-9db7-4a96-9b0b-810f68832538"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kocaeli" },
                    { new Guid("d81d708a-bf1f-488f-89da-7cab2ed48808"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Antalya" },
                    { new Guid("da899578-fb82-46f4-8e75-3f0d7498dc83"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bursa" },
                    { new Guid("dbf9cbf2-0807-4ade-8db4-cc034e480a45"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Artvin" },
                    { new Guid("e0c4e248-f4ea-41ad-8582-fd32a546bff0"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ağrı" },
                    { new Guid("e75da4b0-b49e-4ec1-8617-47d96382ca56"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kars" },
                    { new Guid("e9176056-873a-4ee1-b88c-696f804485a3"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bingöl" },
                    { new Guid("ec2dac58-fa5e-4c77-a838-458aea179e38"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Adıyaman" },
                    { new Guid("f1e8ff25-1c65-494a-8e0f-55091405f709"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Iğdır" },
                    { new Guid("f5f36342-43f6-46e9-9a92-6c95e0d46315"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Gümüşhane" },
                    { new Guid("f86c8bfe-00a9-40e8-afbc-6df0f8ec7932"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çorum" },
                    { new Guid("f8e06883-9d94-4b84-aee2-8947976e9e33"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Karabük" },
                    { new Guid("fac79587-6a53-4ab3-b256-147c7cacea35"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Rize" },
                    { new Guid("fe70d87c-b0d3-481f-bfc6-3ddf274e8fc3"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Gaziantep" },
                    { new Guid("feb74df2-020e-493b-b9c0-b041e64eb9c5"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Osmaniye" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("28eae083-2a81-46d2-8f61-3caef8da407c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d913087-d36d-4a5c-ab9d-e9d7845d48e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e119c4fb-5ba5-4bd4-83c3-cb8ec2d72688"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8aaf619e-e69e-4178-b5e0-04344d04b429"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01c64893-2322-4d97-a57d-2b027d7094ed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("026da2cd-32fa-4cce-b439-3bfdd17890f7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("068d6c9f-846b-43b3-af78-9d715ff377be"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("07bcd57d-aefb-43f1-9e36-d7d4971a5a8c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0cf93f07-2a12-48ff-b694-5d2deb35fa13"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("0dac1c81-af4b-4b8f-8d29-c6d2a08b35f2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("10eb6a1c-bd73-425a-819f-1c4152b58504"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("15bb8217-3c85-433f-9f7d-6a503993ec3f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("15ed2dfa-cb2d-4a78-8518-a0b002046e21"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1e1eb6c5-d6ca-45d1-b019-5853bcfd2a95"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("1fa3415d-fab0-4924-821f-d749258b1927"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("226992e1-745e-41f4-9b33-a2f25ac0ac5b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("22980679-6595-40e9-b6f7-f96a965f9d50"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2302ac73-09fd-4842-82fc-d2ce8ccfc86e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2369d340-b894-4118-bb49-9e37307c9759"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("27eaf14a-8dea-454e-ba33-bd13b1b45c54"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2c1b05b9-d901-4f59-b339-8aab9f488573"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("2f08590d-617b-4959-ae4b-89fa47ececa1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("33cc6a14-8c88-46be-bd54-9248350f4999"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("341a9ff6-7bf5-4df8-af4a-c0bfe07d89d6"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3af8f7ca-d309-40ef-a0f8-70394f3601ca"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("3b818efa-0481-44d3-9f7f-06f043e3ce60"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("42a19744-173f-40c3-bd72-31a6a5a0e0ef"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("42b8c678-5362-42e8-9329-5bcf8356b550"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("44b7e10b-3119-4dea-9f5f-c381087b5a94"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4d5a174b-464d-4d8f-b0b8-f82e3e8dbfc4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("4dee908d-51ff-48c7-a981-427da16adcd4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("56ab7d11-a050-4fa9-9606-df9e08976acc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("58347f51-7074-4e4a-b370-f4111d7781ef"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5a5d5def-8ed7-454f-a2f0-fee36fdcf77a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5c2bb592-8e0c-4fce-a2f6-13cdf313e96a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("5d2a90ab-587f-4169-91a6-4fc19054bcac"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("61f5cf40-8c8d-4769-91c4-b4b0b287b6bd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("64d5218b-8c68-4af2-ac5e-904a595c569b"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("659673b4-05c7-45c0-b943-6ac90746c4a8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("66ac5fd9-5117-4213-b801-1708fd1f7bed"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("6a050542-1f66-4986-b5eb-19cd20e127f8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("7ec2f5f4-8c49-494d-b71a-6900916c73ec"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("822e1547-f45f-44eb-8c7b-9c48b6511190"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("84f5b8cb-ef95-46aa-8fee-e3add60c0f47"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("86297fe6-549e-404b-8916-9025151bf72f"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("867b407d-5690-4919-b8c5-550ffd8801b8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("88775666-3b0b-4a3d-aeae-4f53ddbc51f1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("8882f248-a914-488a-9b07-0eedb7890b3d"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("89368a6d-5c07-4c63-b4a8-d85ef5863db1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("92012984-1a16-4533-8e84-9747f61742b4"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("92546053-06c8-4df6-8e7b-d9eba9f92891"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9a147d65-8eda-423c-8598-f255d8fa7904"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("9a5ae024-ce77-42f4-8b76-b602a5688977"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a2bb2a56-2f4c-4e1a-bfad-13b270529314"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("a67e7220-0581-47ee-ad12-6712d2130e27"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ab4bb637-9c6b-4528-8b20-df90248632f8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("afadb6da-1e5b-4b17-ab6b-aa096e287747"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("afff5fff-7e5d-44be-b600-0acae61e8c46"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b64c35ea-750e-4e24-9270-d96a26e4bac1"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b75df8f3-816a-4f81-a631-58defbe1fed9"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("b8430d0d-45dc-4691-a9ef-51b41865609e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c7062da2-bb46-4870-a11a-9125f4935017"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c72f3d87-b5c4-42f6-b758-0ecd9e00903a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c74b2636-c733-4b5a-9c9a-3af49fae855e"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c84997da-7f0b-43e8-9186-9aa0161d3f96"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c871e15a-46b5-4e35-badd-05d22b369451"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("c9235fc1-deed-48b7-90a7-98bad6bc645c"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("cb92bfb2-105e-4e2d-a3ed-d9a9956887bd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ccf13bae-c912-457c-a9b6-d45d22f1f85a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d0e27f5b-69a4-4da4-bd48-34cb33de5e91"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d1398437-9db7-4a96-9b0b-810f68832538"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("d81d708a-bf1f-488f-89da-7cab2ed48808"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("da899578-fb82-46f4-8e75-3f0d7498dc83"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("dbf9cbf2-0807-4ade-8db4-cc034e480a45"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e0c4e248-f4ea-41ad-8582-fd32a546bff0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e75da4b0-b49e-4ec1-8617-47d96382ca56"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("e9176056-873a-4ee1-b88c-696f804485a3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("ec2dac58-fa5e-4c77-a838-458aea179e38"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f1e8ff25-1c65-494a-8e0f-55091405f709"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f5f36342-43f6-46e9-9a92-6c95e0d46315"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f86c8bfe-00a9-40e8-afbc-6df0f8ec7932"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("f8e06883-9d94-4b84-aee2-8947976e9e33"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fac79587-6a53-4ab3-b256-147c7cacea35"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("fe70d87c-b0d3-481f-bfc6-3ddf274e8fc3"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("feb74df2-020e-493b-b9c0-b041e64eb9c5"));

            migrationBuilder.DeleteData(
                table: "Sectors",
                keyColumn: "Id",
                keyValue: new Guid("f4901614-5e4f-4b47-b72b-7a21585263eb"));

            migrationBuilder.DeleteData(
                table: "WorkModels",
                keyColumn: "Id",
                keyValue: new Guid("4cfa49e2-005a-45eb-a87d-63a35aa4a1b0"));

            migrationBuilder.DeleteData(
                table: "WorkModels",
                keyColumn: "Id",
                keyValue: new Guid("5cfdd002-0e17-4f85-9785-af001251c568"));

            migrationBuilder.DeleteData(
                table: "WorkModels",
                keyColumn: "Id",
                keyValue: new Guid("be2d4821-3c84-4552-b292-6305887b8fed"));

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: new Guid("00b46edd-6fc4-4999-a141-a01d95d82ee3"));

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: new Guid("6116ed65-8da7-4820-9a92-8bd89caf03ab"));

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: new Guid("d68427a8-96bb-4590-bf6f-29abbe47733f"));

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: new Guid("e6d8e023-8061-455a-98c1-ed8ccde1db3f"));

            migrationBuilder.DeleteData(
                table: "WorkTypes",
                keyColumn: "Id",
                keyValue: new Guid("eb124238-70cf-41f6-b5a2-f515c25515f2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"));
        }
    }
}
