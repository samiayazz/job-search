using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSearch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SectorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    FullAddress = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WorkTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    YearsOfExperience = table.Column<byte>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Criteria = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkModels_WorkModelId",
                        column: x => x.WorkModelId,
                        principalTable: "WorkModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    SalaryExpection = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m),
                    PeriodOfNotice = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("04066d07-a60e-4625-8091-2644626b861b"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Denizli" },
                    { new Guid("0e731806-4106-4d82-830f-ed769c7d707b"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Adıyaman" },
                    { new Guid("0fd823d6-1d1a-46b0-b889-2807426683b4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çankırı" },
                    { new Guid("1259629c-75e8-4f5f-84a4-1328e08c82da"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Mardin" },
                    { new Guid("12eaca1a-ac46-42b1-a7ba-9b3fac910aba"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kars" },
                    { new Guid("1390b4ab-7d7d-41e1-ac51-fa7c71aea19e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ardahan" },
                    { new Guid("13d65077-65eb-4926-ae94-28141ba60633"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bursa" },
                    { new Guid("15cf425c-7bac-4084-bfad-1158f6b8ad17"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Hatay" },
                    { new Guid("16d38f6d-c657-42d3-a5fc-6d412c1db443"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Karabük" },
                    { new Guid("1ba5a6bf-ca2b-4a28-82ce-4ce6f7820cf1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ağrı" },
                    { new Guid("1bc323a8-4277-433a-8202-a46a54a84f16"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bingöl" },
                    { new Guid("1efb1557-a8f2-4dd3-b43b-bbd6131adfcc"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Van" },
                    { new Guid("208e01fe-6d34-40b6-826c-7b634470a8b7"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Nevşehir" },
                    { new Guid("20c14b59-1d8c-4b39-8821-06170bafbed4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Hakkâri" },
                    { new Guid("2713ee60-ccaa-4168-9c6d-5d88fe3e0469"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çorum" },
                    { new Guid("2ac287fd-bab3-45c1-aed4-3f52ae20d330"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bartın" },
                    { new Guid("2c7d027a-dfd5-4286-849a-fdef46cbc80f"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kütahya" },
                    { new Guid("31c24afc-fe7c-41e1-934a-5c5038345193"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Samsun" },
                    { new Guid("38fd4fe1-ab62-49d3-8416-3f29e4db0a59"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sinop" },
                    { new Guid("3a02e993-35e5-4bcb-abfe-59eac7f0bf5e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırklareli" },
                    { new Guid("3a70fd06-4046-4ef7-93db-f89cdaf26e48"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Elazığ" },
                    { new Guid("3c560543-f746-49bb-b6d5-7c83c47c69e7"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Karaman" },
                    { new Guid("3da00853-84c1-440b-9a59-6947aebf2473"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Muş" },
                    { new Guid("41c0d76b-4bc9-4f24-93b2-3fc777e4fd4a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kastamonu" },
                    { new Guid("4387db05-0d8a-457b-a0cf-d6eeb7338fb9"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Antalya" },
                    { new Guid("457a5f59-9f63-4bdb-b5a2-ae538eb8bf65"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kocaeli" },
                    { new Guid("4adaebbd-b515-4751-ad21-2b1dd0c4b547"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Giresun" },
                    { new Guid("4d5df297-3439-4562-aff0-cbd0ba9cadc2"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "İzmir" },
                    { new Guid("4e20d997-e2a0-4725-bb83-8fb130642659"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tokat" },
                    { new Guid("4fddfeb6-9036-477b-bd4d-bf7e24d71e8a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Şırnak" },
                    { new Guid("50c12697-2cc4-4994-b233-ee7f95493741"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Mersin" },
                    { new Guid("5bd1d662-3dfb-4b33-9e4d-5989c7e8ca56"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ordu" },
                    { new Guid("61bb6f10-0f92-485d-b8b5-36d48456cda5"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Isparta" },
                    { new Guid("62589d4c-89ca-445a-bbd2-7bf5d85763bd"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kilis" },
                    { new Guid("6699be67-872f-4bdb-88c9-846261c8ea0b"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Uşak" },
                    { new Guid("673cf643-6544-4fb3-9252-9588cfa35d74"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Aydın" },
                    { new Guid("6907ebe8-35c3-4328-b6ed-97b09fba370c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bitlis" },
                    { new Guid("6c0b5531-8d03-403a-9f9c-d3e618175e51"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tunceli" },
                    { new Guid("7066d192-0336-42db-8df3-cbc0c6cc1c11"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Malatya" },
                    { new Guid("729d8348-e1d4-42a8-a963-a2e3c80c0c04"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sakarya" },
                    { new Guid("72f50578-4412-4884-b57b-6475aceb1b01"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "İstanbul" },
                    { new Guid("79912c0c-f671-4484-9030-15b3e3c6fc51"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Düzce" },
                    { new Guid("7a484df6-aa59-45da-ad4c-8d8d2fc459ae"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Tekirdağ" },
                    { new Guid("7a6f15d4-e621-450f-aef3-802f0c8b6ceb"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Konya" },
                    { new Guid("83587dc7-c645-4921-8d85-534b6bbe96b0"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Rize" },
                    { new Guid("83c72b95-c215-48af-8bba-983d8458cc51"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Erzincan" },
                    { new Guid("859faa0f-2e26-42fc-91e3-b071509a6c5f"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Niğde" },
                    { new Guid("8866bb68-c8c2-4d5b-9fc4-7a2abea920da"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Şanlıurfa" },
                    { new Guid("896f1c07-8a0f-4dd8-aedd-2a3e4dcea9f5"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Gümüşhane" },
                    { new Guid("943a7cdc-6157-4836-afb6-deceb3f1426f"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Iğdır" },
                    { new Guid("9767de23-afb6-4d84-916e-ce5a85ef51ec"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Osmaniye" },
                    { new Guid("99e323c0-1fde-4fd7-9d21-791d5ed69953"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Ankara" },
                    { new Guid("9f476312-2e11-4818-857b-888fb26372b8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bilecik" },
                    { new Guid("a0b85136-a480-4aeb-a2fc-33a906a3d885"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kahramanmaraş" },
                    { new Guid("a6cb4e0b-3676-4a97-92dd-73d92c2923fe"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Manisa" },
                    { new Guid("aa1bdb1e-2c43-495f-9f58-36fdd391d52c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Batman" },
                    { new Guid("aaaefd47-af7c-4bff-a97a-8c204f5b0b73"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Gaziantep" },
                    { new Guid("ac487de7-0ed5-4d03-ab99-3a35422dfabe"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Çanakkale" },
                    { new Guid("ae05442a-5723-45cc-b9cc-ea69109b1e4e"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Sivas" },
                    { new Guid("af0084ce-c3da-4fa9-9e98-2b765400d9a4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Burdur" },
                    { new Guid("b0b6ec04-ef66-46f6-be1f-9ac9c532b4a6"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bolu" },
                    { new Guid("b188d103-4f67-4801-9e71-e000550a4abf"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kayseri" },
                    { new Guid("b60a9ea4-976d-47c1-95f2-37497c43a645"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Zonguldak" },
                    { new Guid("b69efb5d-5399-4b68-ae77-b543f8864d30"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırıkkale" },
                    { new Guid("b6dd1bfc-5f0c-41c3-9000-1530d1d2d54d"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Artvin" },
                    { new Guid("bb31211b-8b7e-4447-a01a-38d6a3632dc4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Afyonkarahisar" },
                    { new Guid("bd19d9c8-f78b-451f-b6c4-f094fbbf381a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Muğla" },
                    { new Guid("c00ab512-b7ea-494c-973f-ac18d571e75c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Amasya" },
                    { new Guid("c0add994-3c3d-48ca-995d-4b5185e1f8b8"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Yalova" },
                    { new Guid("c73329c5-0a64-4b1d-bb63-34906a9a0110"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Diyarbakır" },
                    { new Guid("c93c59ce-36bc-4c72-b667-f92766978dc1"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Erzurum" },
                    { new Guid("cae9529a-c537-4776-9bdf-6990e5b5836c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Kırşehir" },
                    { new Guid("cebb3723-2118-49fe-acc1-73723d3fc90c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Eskişehir" },
                    { new Guid("d85b01f8-50dd-4d19-a56d-4b0f85466433"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Siirt" },
                    { new Guid("d99ba584-ee71-4b05-90d3-a5b8e5280d46"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Edirne" },
                    { new Guid("da6f029e-4db3-4df8-be86-e52023550fa3"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Aksaray" },
                    { new Guid("e0d0edc6-438a-41c8-bb9b-5e7d56b555e4"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Trabzon" },
                    { new Guid("e0db3a58-3ceb-4165-962d-cf7ec0dccf9a"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Bayburt" },
                    { new Guid("f57e51e0-75f0-4137-b0ff-d134fd99de8c"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Adana" },
                    { new Guid("fb795c40-07b8-47c5-a400-5d1374153bcd"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Balıkesir" },
                    { new Guid("fc19f1c4-ae3b-40a0-9588-a31ef1053132"), new Guid("fbaa76da-0f6b-46c7-930f-586e3bba2cf8"), "Yozgat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CompanyId",
                table: "Addresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreatedById",
                table: "Addresses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorId",
                table: "Companies",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ApplicantId",
                table: "JobApplication",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobId",
                table: "JobApplication",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatedById",
                table: "Jobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DepartmentId",
                table: "Jobs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkModelId",
                table: "Jobs",
                column: "WorkModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkTypeId",
                table: "Jobs",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "WorkModels");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
