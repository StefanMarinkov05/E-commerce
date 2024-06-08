using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtFusionStudio.DataAccess.Migrations
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PathD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraCount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisplayTechnology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayTechnology", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RAM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OSName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystemVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OSVersion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystemVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProtectionLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Protection = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectionLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityGB = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageCapacity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OSNameAndVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OSNameId = table.Column<int>(type: "int", nullable: false),
                    OSVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSNameAndVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OSNameAndVersion_OperatingSystemVersion_OSVersionId",
                        column: x => x.OSVersionId,
                        principalTable: "OperatingSystemVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OSNameAndVersion_OperatingSystems_OSNameId",
                        column: x => x.OSNameId,
                        principalTable: "OperatingSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    USBTypeId = table.Column<int>(type: "int", nullable: true),
                    StorageCapacityId = table.Column<int>(type: "int", nullable: true),
                    RAMMemoryId = table.Column<int>(type: "int", nullable: true),
                    DisplayTechnologyId = table.Column<int>(type: "int", nullable: true),
                    CamerasId = table.Column<int>(type: "int", nullable: true),
                    OSNameAndVersionId = table.Column<int>(type: "int", nullable: true),
                    ProtectionLevelId = table.Column<int>(type: "int", nullable: true),
                    CaseMaterialId = table.Column<int>(type: "int", nullable: true),
                    CaseTypeId = table.Column<int>(type: "int", nullable: true),
                    OutputVoltage = table.Column<int>(type: "int", nullable: true),
                    OutputCurrent = table.Column<int>(type: "int", nullable: true),
                    FastChargingSupported = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Camera_CamerasId",
                        column: x => x.CamerasId,
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CaseMaterial_CaseMaterialId",
                        column: x => x.CaseMaterialId,
                        principalTable: "CaseMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CaseType_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_DisplayTechnology_DisplayTechnologyId",
                        column: x => x.DisplayTechnologyId,
                        principalTable: "DisplayTechnology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Memory_RAMMemoryId",
                        column: x => x.RAMMemoryId,
                        principalTable: "Memory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_OSNameAndVersion_OSNameAndVersionId",
                        column: x => x.OSNameAndVersionId,
                        principalTable: "OSNameAndVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProtectionLevel_ProtectionLevelId",
                        column: x => x.ProtectionLevelId,
                        principalTable: "ProtectionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_StorageCapacity_StorageCapacityId",
                        column: x => x.StorageCapacityId,
                        principalTable: "StorageCapacity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_USB_USBTypeId",
                        column: x => x.USBTypeId,
                        principalTable: "USB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupon_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name", "PathD" },
                values: new object[,]
                {
                    { 1, "Iphone", "M17.05 20.28c-.98.95-2.05.8-3.08.35c-1.09-.46-2.09-.48-3.24 0c-1.44.62-2.2.44-3.06-.35C2.79 15.25 3.51 7.59 9.05 7.31c1.35.07 2.29.74 3.08.8c1.18-.24 2.31-.93 3.57-.84c1.51.12 2.65.72 3.4 1.8c-3.12 1.87-2.38 5.98.48 7.13c-.57 1.5-1.31 2.99-2.54 4.09zM12.03 7.25c-.15-2.23 1.66-4.07 3.74-4.25c.29 2.58-2.34 4.5-3.74 4.25" },
                    { 2, "Huawei", "M3.67 6.14S1.82 7.91 1.72 9.78v.35c.08 1.51 1.22 2.4 1.22 2.4c1.83 1.79 6.26 4.04 7.3 4.55c0 0 .06.03.1-.01l.02-.04v-.04C7.52 10.8 3.67 6.14 3.67 6.14M9.65 18.6c-.02-.08-.1-.08-.1-.08l-7.38.26c.8 1.43 2.15 2.53 3.56 2.2c.96-.25 3.16-1.78 3.88-2.3c.06-.05.04-.09.04-.09zm.08-.78C6.49 15.63.21 12.28.21 12.28c-.15.46-.2.9-.21 1.3v.07c0 1.07.4 1.82.4 1.82c.8 1.69 2.34 2.2 2.34 2.2c.7.3 1.4.31 1.4.31c.12.02 4.4 0 5.54 0c.05 0 .08-.05.08-.05v-.06c0-.03-.03-.05-.03-.05M9.06 3.19a3.42 3.42 0 0 0-2.57 3.15v.41c.03.6.16 1.05.16 1.05c.66 2.9 3.86 7.65 4.55 8.65c.05.05.1.03.1.03a.1.1 0 0 0 .06-.1c1.06-10.6-1.11-13.42-1.11-13.42c-.32.02-1.19.23-1.19.23m8.299 2.27s-.49-1.8-2.44-2.28c0 0-.57-.14-1.17-.22c0 0-2.18 2.81-1.12 13.43c.01.07.06.08.06.08c.07.03.1-.03.1-.03c.72-1.03 3.9-5.76 4.55-8.64c0 0 .36-1.4.02-2.34m-2.92 13.07s-.07 0-.09.05c0 0-.01.07.03.1c.7.51 2.85 2 3.88 2.3c0 0 .16.05.43.06h.14c.69-.02 1.9-.37 3-2.26l-7.4-.25zm7.83-8.41c.14-2.06-1.94-3.97-1.94-3.98c0 0-3.85 4.66-6.67 10.8c0 0-.03.08.02.13l.04.01h.06c1.06-.53 5.46-2.77 7.28-4.54c0 0 1.15-.93 1.21-2.42m1.52 2.14s-6.28 3.37-9.52 5.55c0 0-.05.04-.03.11c0 0 .03.06.07.06c1.16 0 5.56 0 5.67-.02c0 0 .57-.02 1.27-.29c0 0 1.56-.5 2.37-2.27c0 0 .73-1.45.17-3.14" },
                    { 3, "Sony", "M8.55 9.888c.921 0 1.658.23 2.221.742c.385.349.6.846.594 1.367a1.908 1.908 0 0 1-.594 1.373c-.527.484-1.348.742-2.22.742c-.873 0-1.68-.258-2.215-.742a1.808 1.808 0 0 1-.603-1.373c0-.518.218-1.015.603-1.367c.5-.454 1.384-.742 2.214-.742m.003 3.67c.461 0 .888-.161 1.188-.458c.3-.3.433-.66.433-1.103c0-.424-.148-.821-.433-1.103c-.294-.29-.733-.454-1.188-.454s-.893.163-1.19.454c-.285.282-.434.679-.434 1.103a1.56 1.56 0 0 0 .434 1.103c.297.294.733.457 1.19.457M3.712 11.59c.16.042.315.094.466.163a1.352 1.352 0 0 1 .379.258c.197.206.309.482.306.767a.964.964 0 0 1-.379.778a2.066 2.066 0 0 1-.709.349a3.723 3.723 0 0 1-1.194.17c-.352 0-.546-.041-.813-.097l-.077-.016a4.72 4.72 0 0 1-.858-.278a.07.07 0 0 0-.042-.012a.084.084 0 0 0-.082.084v.203H.121v-1.478h.524a.756.756 0 0 0 .137.418c.212.26.44.36.657.44c.367.12.752.184 1.136.196c.553 0 .876-.134.946-.163l.009-.004l.006-.002c.062-.023.312-.114.312-.392c0-.274-.234-.334-.387-.373l-.022-.005c-.17-.046-.562-.088-.99-.133l-.152-.016a13.85 13.85 0 0 1-1.197-.175c-.498-.11-.694-.292-.816-.405l-.008-.008a1.02 1.02 0 0 1-.276-.7c0-.496.34-.796.758-.98a3.63 3.63 0 0 1 1.439-.289c.82.003 1.487.27 1.727.394c.097.052.145-.012.145-.06v-.149h.527v1.288h-.472a.906.906 0 0 0-.294-.491a1.289 1.289 0 0 0-.297-.179a3.114 3.114 0 0 0-1.251-.245c-.443 0-.867.085-1.08.215c-.132.082-.2.185-.2.306c0 .173.146.242.22.263c.196.06.632.103.971.137l.204.021c.327.033 1.012.124 1.315.2m18.167-.997v-.479H24v.47h-.476c-.172 0-.242.033-.372.179l-1.427 1.63a.098.098 0 0 0-.019.07v.742a1.106 1.106 0 0 0 .012.103a.15.15 0 0 0 .1.09a.937.937 0 0 0 .13.01h.486v.47H19.86v-.47h.46a.934.934 0 0 0 .13-.01a.163.163 0 0 0 .104-.09a.563.563 0 0 0 .009-.1v-.742c0-.025 0-.025-.033-.064a606.76 606.76 0 0 0-1.412-1.603c-.076-.079-.206-.206-.406-.206h-.458v-.47h2.588v.47h-.312c-.07 0-.118.07-.058.146l.879 1.051c.009.012.015.012.027.003c.012-.009.894-1.045.9-1.054a.091.091 0 0 0-.018-.128a.11.11 0 0 0-.06-.018zm-6.284-.003h.485c.221 0 .26.085.263.291l.028 1.566l-2.582-2.324h-1.845v.47h.412c.297 0 .318.164.318.31v2.213c0 .128.001.295-.182.295h-.506v.467h2.164v-.47h-.528c-.212 0-.22-.097-.224-.303v-1.882l2.973 2.651h.757l-.04-2.996c.004-.218.019-.291.243-.291h.473v-.47h-2.209Z" },
                    { 4, "Samsung", "m19.817 10.28l.046 2.694h-.023l-.78-2.693h-1.283v3.392h.848l-.046-2.785h.023l.836 2.785h1.227v-3.392zm-16.15 0l-.641 3.428h.928l.47-3.118h.023l.459 3.118h.916l-.63-3.427zm5.181 0l-.424 2.614h-.023l-.424-2.613H6.58l-.069 3.427h.86l.023-3.083h.011l.573 3.083h.871l.573-3.083h.023l.023 3.083h.86l-.08-3.427zm-7.266 2.454a.48.48 0 0 1 .011.252c-.023.114-.103.229-.332.229c-.218 0-.344-.126-.344-.31v-.332H0v.264c0 .768.607.997 1.25.997c.618 0 1.134-.218 1.214-.78c.046-.298.012-.492 0-.561c-.16-.722-1.467-.929-1.559-1.33a.492.492 0 0 1 0-.183c.023-.115.104-.23.31-.23c.206 0 .32.127.32.31v.206h.86v-.24c0-.745-.676-.86-1.157-.86c-.608 0-1.112.206-1.204.757a1.04 1.04 0 0 0 .012.458c.137.71 1.364.917 1.536 1.352m11.152 0c.034.08.022.184.011.253c-.023.114-.103.229-.332.229c-.218 0-.344-.126-.344-.31v-.332h-.917v.264c0 .756.596.985 1.238.985c.619 0 1.123-.206 1.203-.779c.046-.298.012-.481 0-.562c-.137-.71-1.433-.928-1.524-1.318a.488.488 0 0 1 0-.183c.023-.115.103-.23.31-.23c.194 0 .32.127.32.31v.206h.848v-.24c0-.745-.665-.86-1.146-.86c-.607 0-1.1.195-1.192.757c-.023.149-.023.286.012.458c.137.71 1.34.905 1.513 1.352m2.888.459c.24 0 .31-.16.332-.252c.012-.035.012-.092.012-.126V10.28h.87v2.464c0 .069 0 .195-.01.23c-.058.641-.562.847-1.193.847c-.63 0-1.134-.206-1.192-.848c0-.034-.011-.16-.011-.229V10.28h.87v2.533c0 .046 0 .091.012.126c0 .091.07.252.31.252m7.152-.034c.252 0 .332-.16.355-.253c.011-.034.011-.091.011-.126v-.493h-.355v-.504H24v.917c0 .069 0 .115-.011.23c-.058.63-.597.847-1.204.847s-1.146-.217-1.203-.848c-.012-.114-.012-.16-.012-.229v-1.444c0-.057.012-.172.012-.23c.08-.641.596-.847 1.203-.847s1.135.206 1.203.848c.012.103.012.229.012.229v.115h-.86v-.195s0-.08-.011-.126c-.012-.08-.08-.252-.344-.252c-.252 0-.32.16-.344.252c-.011.045-.011.103-.011.16v1.57c0 .046 0 .092.011.126c0 .092.092.253.333.253" },
                    { 5, "Nokia", "M16.59 9.348v5.304h.796V9.348Zm-8.497-.09c-1.55 0-2.752 1.127-2.752 2.742c0 1.687 1.202 2.742 2.752 2.742c1.55 0 2.754-1.055 2.751-2.742a2.72 2.72 0 0 0-2.751-2.742M10.05 12c0 1.195-.876 1.987-1.957 1.987c-1.082 0-1.958-.792-1.958-1.987c0-1.174.876-1.987 1.958-1.987c1.08 0 1.957.813 1.957 1.987M0 9.176v5.476h.812v-3.619l4.218 3.79v-1.135zM11.442 12l2.952 2.652h1.184L12.622 12l2.956-2.652h-1.184ZM24 14.652h-.875l-.64-1.175h-2.898l-.64 1.175h-.875l1.06-1.958h2.937l-1.465-2.72l.432-.798Z" },
                    { 6, "Аксесоари", "M13.75 2A2.25 2.25 0 0 1 16 4.25V11h-.25A2.75 2.75 0 0 0 13 13.75v.3a2.5 2.5 0 0 0-2 2.45V18H8.75a.75.75 0 0 0 0 1.5H11v2c0 .171.017.338.05.5h-4.8A2.25 2.25 0 0 1 4 19.75V4.25A2.25 2.25 0 0 1 6.25 2zM14 13.75V15h-.5a1.5 1.5 0 0 0-1.5 1.5v5a1.5 1.5 0 0 0 1.5 1.5h8a1.5 1.5 0 0 0 1.5-1.5v-5a1.5 1.5 0 0 0-1.5-1.5H21v-1.25A1.75 1.75 0 0 0 19.25 12h-3.5A1.75 1.75 0 0 0 14 13.75m1.5 0a.25.25 0 0 1 .25-.25h3.5a.25.25 0 0 1 .25.25V15h-4z" },
                    { 7, "Персонализирани", "M17.5 12a1.5 1.5 0 0 1-1.5-1.5A1.5 1.5 0 0 1 17.5 9a1.5 1.5 0 0 1 1.5 1.5a1.5 1.5 0 0 1-1.5 1.5m-3-4A1.5 1.5 0 0 1 13 6.5A1.5 1.5 0 0 1 14.5 5A1.5 1.5 0 0 1 16 6.5A1.5 1.5 0 0 1 14.5 8m-5 0A1.5 1.5 0 0 1 8 6.5A1.5 1.5 0 0 1 9.5 5A1.5 1.5 0 0 1 11 6.5A1.5 1.5 0 0 1 9.5 8m-3 4A1.5 1.5 0 0 1 5 10.5A1.5 1.5 0 0 1 6.5 9A1.5 1.5 0 0 1 8 10.5A1.5 1.5 0 0 1 6.5 12M12 3a9 9 0 0 0-9 9a9 9 0 0 0 9 9a1.5 1.5 0 0 0 1.5-1.5c0-.39-.15-.74-.39-1c-.23-.27-.38-.62-.38-1a1.5 1.5 0 0 1 1.5-1.5H16a5 5 0 0 0 5-5c0-4.42-4.03-8-9-8" }
                });

            migrationBuilder.InsertData(
                table: "Camera",
                columns: new[] { "Id", "CameraCount" },
                values: new object[,]
                {
                    { 1, (byte)1 },
                    { 2, (byte)2 },
                    { 3, (byte)3 },
                    { 4, (byte)4 },
                    { 5, (byte)5 },
                    { 6, (byte)6 },
                    { 7, (byte)7 }
                });

            migrationBuilder.InsertData(
                table: "CaseMaterial",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Силикон" },
                    { 2, "Дърво" },
                    { 3, "Плат" },
                    { 4, "Силикон" },
                    { 5, "Пластмаса" },
                    { 6, "TPU" },
                    { 7, "Гума" },
                    { 8, "Метал" },
                    { 9, "Поликарбон" }
                });

            migrationBuilder.InsertData(
                table: "CaseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Портфейл" },
                    { 2, "Само гръб" },
                    { 3, "Скелет" },
                    { 4, "Вертикален" },
                    { 5, "С батерия" },
                    { 6, "Ръчен" },
                    { 7, "Удароустойчив" },
                    { 8, "Водоустойчив" },
                    { 9, "Чанта" },
                    { 10, "Кобур" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Phone" },
                    { 2, "Case" },
                    { 3, "Charger" }
                });

            migrationBuilder.InsertData(
                table: "DisplayTechnology",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "LCD" },
                    { 2, "LED" },
                    { 3, "Mini LED" },
                    { 4, "OLED" },
                    { 5, "POLED" },
                    { 6, "AMOLED" },
                    { 7, "Retina" }
                });

            migrationBuilder.InsertData(
                table: "Memory",
                columns: new[] { "Id", "RAM" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 10 },
                    { 10, 12 },
                    { 11, 14 },
                    { 12, 16 },
                    { 13, 18 },
                    { 14, 20 },
                    { 15, 22 },
                    { 16, 24 },
                    { 17, 26 },
                    { 18, 28 }
                });

            migrationBuilder.InsertData(
                table: "OperatingSystemVersion",
                columns: new[] { "Id", "OSVersion" },
                values: new object[,]
                {
                    { 1, 1.0m },
                    { 2, 2.0m },
                    { 3, 3.0m },
                    { 4, 4.0m },
                    { 5, 5.0m },
                    { 6, 5.5m },
                    { 7, 6.0m },
                    { 8, 7.0m },
                    { 9, 8.0m },
                    { 10, 9.0m },
                    { 11, 10.0m },
                    { 12, 11.0m },
                    { 13, 12.0m },
                    { 14, 12.5m },
                    { 15, 13.0m },
                    { 16, 14.0m },
                    { 17, 15.0m },
                    { 18, 16.0m },
                    { 19, 17.0m }
                });

            migrationBuilder.InsertData(
                table: "OperatingSystems",
                columns: new[] { "Id", "OSName" },
                values: new object[,]
                {
                    { 1, "Android" },
                    { 2, "iOS" },
                    { 3, "HarmonyOS" },
                    { 4, "MIUI" },
                    { 5, "One UI" },
                    { 6, "Windows Phone" }
                });

            migrationBuilder.InsertData(
                table: "ProtectionLevel",
                columns: new[] { "Id", "Protection" },
                values: new object[,]
                {
                    { 1, "Екстремно" },
                    { 2, "Здраво" },
                    { 3, "Средно" },
                    { 4, "Слабо" }
                });

            migrationBuilder.InsertData(
                table: "StorageCapacity",
                columns: new[] { "Id", "CapacityGB" },
                values: new object[,]
                {
                    { 1, 8m },
                    { 2, 12m },
                    { 3, 16m },
                    { 4, 24m },
                    { 5, 32m },
                    { 6, 48m },
                    { 7, 64m },
                    { 8, 86m },
                    { 9, 128m },
                    { 10, 196m },
                    { 11, 256m },
                    { 12, 384m },
                    { 13, 420m },
                    { 14, 512m },
                    { 15, 786m },
                    { 16, 1024m }
                });

            migrationBuilder.InsertData(
                table: "USB",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "USB-A" },
                    { 2, "USB-B" },
                    { 3, "USB-C" },
                    { 4, "Mini-USB" },
                    { 5, "Micro-USB" },
                    { 6, "Lightning" }
                });

            migrationBuilder.InsertData(
                table: "OSNameAndVersion",
                columns: new[] { "Id", "OSNameId", "OSVersionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 7 },
                    { 7, 1, 8 },
                    { 8, 1, 9 },
                    { 9, 1, 10 },
                    { 10, 1, 11 },
                    { 11, 1, 12 },
                    { 12, 1, 13 },
                    { 13, 2, 1 },
                    { 14, 2, 2 },
                    { 15, 2, 3 },
                    { 16, 2, 4 },
                    { 17, 2, 5 },
                    { 18, 2, 7 },
                    { 19, 2, 8 },
                    { 20, 2, 9 },
                    { 21, 2, 10 },
                    { 22, 2, 11 },
                    { 23, 2, 12 },
                    { 24, 2, 13 },
                    { 25, 2, 15 },
                    { 26, 2, 16 },
                    { 27, 2, 17 },
                    { 28, 2, 18 },
                    { 29, 2, 19 },
                    { 30, 3, 1 },
                    { 31, 3, 2 },
                    { 32, 3, 3 },
                    { 33, 3, 4 },
                    { 34, 3, 5 },
                    { 35, 4, 1 },
                    { 36, 4, 2 },
                    { 37, 4, 3 },
                    { 38, 4, 4 },
                    { 39, 4, 5 },
                    { 40, 4, 7 },
                    { 41, 4, 8 },
                    { 42, 4, 9 },
                    { 43, 4, 10 },
                    { 44, 4, 11 },
                    { 45, 4, 12 },
                    { 46, 4, 13 },
                    { 47, 4, 14 },
                    { 48, 4, 15 },
                    { 49, 5, 1 },
                    { 50, 5, 2 },
                    { 51, 5, 3 },
                    { 52, 5, 4 },
                    { 53, 5, 5 },
                    { 54, 5, 7 },
                    { 55, 6, 8 },
                    { 56, 6, 9 },
                    { 57, 6, 11 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CurrentPrice", "Description", "Discriminator", "FastChargingSupported", "Name", "OldPrice", "OutputCurrent", "OutputVoltage", "ProductURL", "Quantity", "Score", "TotalVotes" },
                values: new object[,]
                {
                    { 19, 1, 3, 12.99m, "Високоскоростен зарядно за различни устройства.", "Charger", true, "Зареждащ адаптер", 15.99m, 2, 5, "fast_charging_adapter.png", 256, 327, 125 },
                    { 20, 6, 3, 9.99m, "Компактно зарядно с множество USB портове.", "Charger", false, "Универсално USB зарядно", 12.49m, 2, 5, "universal_usb_charger.png", 512, 522, 234 },
                    { 21, 2, 3, 19.99m, "Безжично зареждане за Samsung устройства.", "Charger", true, "Зареждаща подложка Samsung", 24.99m, 1, 9, "samsung_fast_charging_pad.png", 128, 312, 143 },
                    { 22, 1, 3, 24.99m, "Зареждайте своя iPhone безжично с тази стилна подложка.", "Charger", true, "Безжична зареждаща подложка за iPhone", 29.99m, 1, 9, "iphone_wireless_charging_pad.png", 64, 497, 216 },
                    { 23, 3, 3, 15.99m, "Оригинален зарядно за бързо зареждане на вашето устройство Huawei.", "Charger", true, "Зареждащ адаптер за Huawei", 19.99m, 2, 5, "huawei_quick_charge_adapter.png", 256, 372, 159 },
                    { 24, 6, 3, 34.99m, "Зареждайте едновременно няколко устройства с тази зарядна станция.", "Charger", false, "Мултипортово зарядно", 39.99m, 2, 5, "multi_port_charging_station.png", 128, 425, 184 },
                    { 25, 2, 3, 22.99m, "Зареждайте своя Samsung удобно с тази безжична стойка.", "Charger", true, "Безжична зареждаща стойка Samsung", 27.99m, 1, 9, "samsung_wireless_charging_stand.png", 512, 416, 178 },
                    { 26, 1, 3, 14.99m, "Оригинален блок за бързо зареждане на вашето устройство iPhone.", "Charger", true, "Зареждащ блок за iPhone", 18.99m, 2, 5, "iphone_fast_charging_block.png", 256, 456, 197 },
                    { 27, 5, 3, 11.99m, "Зареждайте своя Nokia устройства бързо и сигурно с това USB C зарядно.", "Charger", true, "USB с зарядно за Nokia", 14.99m, 2, 5, "nokia_usb_c_charger.png", 256, 391, 168 },
                    { 28, 1, 3, 34.99m, "зареждане и стабилна връзка с този MagSafe зарядно.", "Charger", true, "MagSafe зареждащо ъстройство за iPhone", 39.99m, 1, 9, "iphone_magsafe_charger.png", 128, 307, 122 },
                    { 29, 6, 3, 24.99m, "Преносим заряден резервоар за вашите устройства с бързо зареждане.", "Charger", true, "Зареждащ Power Bank", 29.99m, 2, 5, "fast_charging_power_bank.png", 512, 337, 135 },
                    { 30, 3, 3, 14.99m, "Зареждане, докато сте в движение с това автомобилно зарядно устройство.", "Charger", true, "Зарядно за кола Huawei Super Charge", 17.99m, 2, 5, "huawei_super_charge_car_charger.png", 256, 356, 149 },
                    { 31, 1, 3, 18.99m, "и лесно зареждане с този магнитен безжичен зарядчик.", "Charger", true, "Магнитен Безжичен Зарядчик за iPhone", 22.99m, 1, 9, "iphone_magnetic_wireless_charger.png", 128, 368, 157 },
                    { 32, 2, 3, 29.99m, "Зареждайте вашите Samsung устройства безжично и на пътя.", "Charger", true, "Безжичен Power Bank за Samsung", 34.99m, 2, 5, "samsung_wireless_power_bank.png", 512, 325, 132 },
                    { 33, 6, 3, 15.99m, "Зареждайте своите устройства бързо и ефективно с това зарядно устройство.", "Charger", true, "USB с зарядно", 19.99m, 2, 5, "quick_charge_usb_c_adapter.png", 256, 348, 141 },
                    { 34, 1, 3, 24.99m, "Зареждайте своя iPhone в колата с това удобно зарядно.", "Charger", true, "MagSafe автомобилно монтирано зарядно за iPhone", 29.99m, 1, 9, "iphone_magsafe_car_mount_charger.png", 128, 388, 169 },
                    { 35, 3, 3, 11.99m, "и ефективно зареждане за вашите Huawei устройства с това стенно зарядно.", "Charger", true, "Huawei Super Charge стенно зарядно", 14.99m, 2, 5, "huawei_super_charge_wall_charger.png", 256, 332, 128 },
                    { 36, 5, 3, 7.99m, "Компактен и бърз кабел за зареждане на вашите Nokia устройства.", "Charger", true, "Зареждащ кабел за Nokia", 9.99m, 2, 5, "nokia_fast_charging_cable.png", 512, 361, 152 },
                    { 37, 1, 3, 24.99m, "Power Delivery зарядно за вашето iPhone с бързо зареждане.", "Charger", true, "iPhone PD зарядно", 29.99m, 2, 5, "iphone_pd_charger.png", 256, 355, 145 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CaseMaterialId", "CaseTypeId", "CategoryId", "CurrentPrice", "Description", "Discriminator", "Name", "OldPrice", "ProductURL", "ProtectionLevelId", "Quantity", "Score", "TotalVotes" },
                values: new object[,]
                {
                    { 38, 3, 6, 5, 2, 19.99m, "Премиум кожен калъф с отделения за карти за Sony Xperia 5, предлагащ защита и функционалност.", "Case", "Кожен калъф с портмоне за Sony Xperia 5", 24.99m, "sony_xperia_5_case.png", 3, 128, 200, 50 },
                    { 39, 4, 2, 3, 2, 16.99m, "Здрав и издръжлив калъф Armor за Samsung Galaxy S20 със стилен дизайн и отлични възможности за абсорбиране на удари.", "Case", "Калъф Armor за Samsung Galaxy S20", 21.99m, "samsung_galaxy_s20_case.png", 3, 256, 190, 45 },
                    { 40, 5, 3, 2, 2, 13.99m, "Хибриден калъф за Nokia 7.2, комбиниращ твърд гръб от PC с гъвкав TPU бампер за двоен защитен слой срещу удари и счупвания.", "Case", "Хибриден калъф за Nokia 7.2", 18.99m, "nokia_7_2_case.png", 2, 64, 160, 42 },
                    { 41, 5, 5, 2, 2, 17.99m, "Уникален калъф с геометричен дизайн за Nokia 9 PureView, предпазващ го от надрасквания и падания.", "Case", "Модерен калъф за Nokia 9 PureView", 22.99m, "nokia_9_pureview_case.png", 3, 256, 160, 55 },
                    { 42, 4, 1, 2, 2, 15.99m, "Удобен и гъвкав калъф за Samsung Galaxy A72, осигуряващ защита от удари и надрасквания.", "Case", "Силиконов калъф за Samsung Galaxy A72", 19.99m, "samsung_galaxy_a72_case.png", 3, 128, 170, 60 },
                    { 43, 3, 8, 2, 2, 16.99m, "Елегантен калъф от естествена кожа за Sony Xperia 10 II, с дискретен лого на бранда.", "Case", "Луксозен калъф за Sony Xperia 10 II", 21.99m, "sony_xperia_10_ii_case.png", 3, 256, 210, 70 },
                    { 44, 4, 1, 3, 2, 21.99m, "Лек и гъвкав калъф за Samsung Galaxy S21, идеален за фитнес и спортни занимания.", "Case", "Спортен калъф за Samsung Galaxy S21", 27.99m, "samsung_galaxy_s21_case.png", 2, 64, 180, 60 },
                    { 45, 2, 7, 3, 2, 20.99m, "Калъф с двойна защита за Huawei Mate 40, предпазващ го от удари и надрасквания.", "Case", "Антишок калъф за Huawei Mate 40", 26.99m, "huawei_mate_40_case.png", 3, 256, 140, 48 },
                    { 46, 1, 1, 1, 2, 19.99m, "Ръчно изработен кожен калъф за iPhone 12 Pro, с вграден магнит за по-сигурно затваряне.", "Case", "Кожен калъф за iPhone 12 Pro", 29.99m, "iphone_12_pro_case.png", 2, 256, 110, 50 },
                    { 47, 5, 8, 10, 2, 11.99m, "Универсален калъф за съхранение на различни аксесоари като слушалки, зарядни и USB кабели.", "Case", "Метален калъф за Nokia 3310", 14.99m, "nokia_3310_case.png", 1, 256, 144, 42 },
                    { 48, 5, 4, 3, 2, 15.99m, "Лек и гъвкав калъф за Nokia 8.3, идеален за спорт и фитнес занимания.", "Case", "Спортен калъф за Nokia 8.3", 19.99m, "nokia_8_3_case.png", 2, 128, 160, 40 },
                    { 49, 1, 6, 1, 2, 18.99m, "Елегантен калъф за iPhone SE, изработен от качествени материали и със стилно лого на Apple.", "Case", "Стилен калъф за iPhone SE", 22.99m, "iphone_se_case.png", 3, 256, 220, 55 },
                    { 50, 6, 1, 2, 2, 21.99m, "Персонализиран калъф с избрана от вас снимка или дизайн, създаден специално за вашия телефон.", "Case", "Персонализиран калъф", 25.99m, "custom_case_02.png", 3, 128, 200, 50 },
                    { 51, 4, 8, 2, 2, 16.99m, "Калъф с грапава повърхност за по-добро захващане на Samsung Galaxy A51, съчетаващ защита и стил.", "Case", "Грапав калъф за Samsung Galaxy A51", 21.99m, "samsung_galaxy_a51_case.png", 2, 64, 240, 60 },
                    { 52, 6, 6, 9, 2, 11.99m, "Компактен калъф за съхранение на различни аксесоари като кабели, USB устройства и зарядни устройства.", "Case", "Компактен калъф за аксесоари", 14.99m, "accessories_case_03.png", 2, 256, 140, 35 },
                    { 53, 3, 7, 8, 2, 20.99m, "Калъф с водоустойчива защита за Sony Xperia 1 II, предпазващ го от вода и влага.", "Case", "Водоустойчив калъф за Sony Xperia 1 II", 26.99m, "sony_xperia_1_ii_case.png", 3, 256, 180, 45 },
                    { 54, 2, 2, 4, 2, 18.99m, "Калъф със странична защита за Huawei Mate 30 Pro, предпазващ го от удари и надрасквания.", "Case", "Страничен калъф за Huawei Mate 30 Pro", 23.99m, "huawei_mate_30_pro_case.png", 2, 256, 220, 55 },
                    { 55, 5, 3, 7, 2, 15.99m, "Калъф с удароустойчиви материали за Nokia 5.4, предпазващ го от счупване при падане.", "Case", "Удароустойчив калъф за Nokia 5.4", 19.99m, "nokia_5_4_case.png", 3, 64, 250, 50 },
                    { 56, 4, 1, 1, 2, 22.99m, "Елегантен калъф за Samsung Galaxy Note 20, изработен от висококачествени материали и със стилен дизайн.", "Case", "Луксозен калъф за Samsung Galaxy Note 20", 28.99m, "samsung_galaxy_note_20_case.png", 3, 128, 260, 65 }
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "DiscountCode", "DiscountPercentage", "EndDate", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 2, "WXYZ123", 49m, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "ASDFQWE", 68m, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "POIUYTR", 12m, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "UIOPGFD", 34m, new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "MNBVCXZ", 77m, new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "IKJUHY", 45m, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "WSXEDC", 61m, new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "RFVTGB", 37m, new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "YHNUJM", 76m, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "UJNMKI", 88m, new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "NHYUJM", 53m, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "BHJUYG", 19m, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "POIUYT", 22m, new DateTime(2027, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "RFVGBH", 88m, new DateTime(2028, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "QAZWSX", 41m, new DateTime(2028, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "EDCVFR", 59m, new DateTime(2028, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "PLKIJU", 73m, new DateTime(2028, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "BVCFRT", 28m, new DateTime(2029, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "IKUJHY", 64m, new DateTime(2029, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "QAZXSW", 37m, new DateTime(2029, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "GBHNYU", 52m, new DateTime(2029, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "RFVGTB", 49m, new DateTime(2029, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, new DateTime(2026, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "LGBTV", 61m, new DateTime(2030, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CamerasId", "CategoryId", "CurrentPrice", "Description", "Discriminator", "DisplayTechnologyId", "Name", "OSNameAndVersionId", "OldPrice", "ProductURL", "Quantity", "RAMMemoryId", "Score", "StorageCapacityId", "TotalVotes", "USBTypeId" },
                values: new object[,]
                {
                    { 1, 1, 5, 1, 2699.99m, "Вече има нещо по-твърдо от легендарната Nokia 3220", "Phone", 4, "Iphone 15 Pro", 29, 2999.99m, "iphone_15_pro.png", 142, 8, 1202, 14, 251, 3 },
                    { 2, 2, 5, 1, 799.99m, "Водещ смартфон от Huawei", "Phone", 4, "Huawei P40 Pro", 18, 899.99m, "huawei_p40_pro.png", 72, 8, 167, 6, 35, 3 },
                    { 3, 3, 4, 1, 999.99m, "Висок клас смартфон, проектиран за мултимедия", "Phone", 3, "Sony Xperia 1 II", 3, 1099.99m, "sony_xperia_1_ii.png", 205, 9, 1842, 12, 420, 3 },
                    { 4, 4, 5, 1, 1199.99m, "Най-висок клас смартфон със завършени функции", "Phone", 5, "Samsung Galaxy S21 Ultra", 18, 1299.99m, "samsung_galaxy_s21_ultra.png", 103, 10, 27, 14, 7, 3 },
                    { 5, 5, 1, 1, 599.99m, "Иновативен смартфон с акцент върху качеството на камерата", "Phone", 4, "Nokia 9 PureView", 3, 699.99m, "nokia_9_pureview.png", 221, 6, 107, 7, 26, 3 },
                    { 6, 1, 5, 1, 1199.99m, "Най-големият и най-мощният iPhone досега", "Phone", 6, "iPhone 14 Pro", 6, 1299.99m, "iphone_14_pro.png", 45, 7, 108, 10, 40, 3 },
                    { 7, 2, 5, 1, 899.99m, "Премиум смартфон с изкуство на режещата технология", "Phone", 5, "Huawei Mate X3", 18, 999.99m, "huawei_mate_x3.png", 147, 7, 317, 9, 88, 3 },
                    { 8, 3, 4, 1, 799.99m, "Компактен, но мощен смартфон за игри и мултимедия", "Phone", 2, "Sony Xperia 5 II", 3, 899.99m, "sony_xperia_5_ii.png", 38, 9, 340, 11, 100, 3 },
                    { 9, 4, 5, 1, 1099.99m, "Флагмански фаблет с функционалност на S Pen", "Phone", 6, "Samsung S24", 18, 1199.99m, "samsung_s24.png", 184, 10, 793, 15, 169, 3 },
                    { 10, 5, 4, 1, 599.99m, "5G-съвместим смартфон с технология PureDisplay", "Phone", 7, "Nokia G42", 3, 699.99m, "nokia_g42.png", 196, 8, 936, 5, 195, 3 },
                    { 11, 1, 2, 1, 349.99m, "Компактен и достъпен модел iPhone", "Phone", 5, "iPhone SE", 6, 399.99m, "iphone_se.png", 189, 11, 242, 2, 69, 3 },
                    { 12, 2, 4, 1, 699.99m, "Предишен флагман с впечатляващи възможности на камерата", "Phone", 1, "Huawei P60", 18, 799.99m, "huawei_p60.png", 35, 8, 119, 4, 35, 3 },
                    { 13, 3, 3, 1, 699.99m, "Стройен смартфон с върхови мултимедийни възможности", "Phone", 3, "Sony Xperia", 3, 799.99m, "sony_xperia.png", 127, 5, 37, 3, 17, 3 },
                    { 14, 4, 3, 1, 449.99m, "Достъпен смартфон с разнообразни възможности на камерата", "Phone", 3, "Samsung Galaxy Z", 18, 499.99m, "samsung_galaxy_z.png", 35, 7, 176, 13, 42, 3 },
                    { 15, 5, 2, 1, 349.99m, "Стилен смартфон с Zeiss Optics", "Phone", 3, "Nokia c210", 3, 399.99m, "nokia_c210.png", 78, 5, 200, 1, 69, 3 },
                    { 16, 1, 2, 1, 549.99m, "Цветен и бюджетен модел iPhone", "Phone", 3, "iPhone XR", 6, 599.99m, "iphone_xr.png", 12, 8, 48, 16, 12, 6 },
                    { 17, 2, 3, 1, 449.99m, "Стилен смартфон с фокус върху селфитата", "Phone", 3, "Huawei nova 7", 18, 499.99m, "huawei_nova_7.png", 201, 7, 299, 8, 73, 3 },
                    { 18, 3, 2, 1, 299.99m, "Достъпен смартфон с висок дисплей", "Phone", 3, "Sony Xperia 10", 3, 349.99m, "sony_xperia_10.png", 145, 4, 182, 2, 48, 3 }
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "DiscountCode", "DiscountPercentage", "EndDate", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 1, "BANGO", 99m, new DateTime(2042, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "MNBVCXZ", 26m, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "QWERTYU", 45m, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "FGHJKLP", 52m, new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "ZXCVBNM", 18m, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "KJHGFDS", 63m, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "LKJHGFDS", 26m, new DateTime(2026, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "QAZWSX", 33m, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "EDCRFV", 55m, new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "TGBYHN", 22m, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "YHNJUM", 71m, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "LOIKUJ", 83m, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "POKJNH", 29m, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "IKMNHJ", 41m, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "YBGTVF", 32m, new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "NJKIMH", 68m, new DateTime(2027, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "THYUJM", 47m, new DateTime(2027, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "OLKIUJ", 75m, new DateTime(2027, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "OKMUNY", 16m, new DateTime(2028, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_ProductId",
                table: "Coupon",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OSNameAndVersion_OSNameId",
                table: "OSNameAndVersion",
                column: "OSNameId");

            migrationBuilder.CreateIndex(
                name: "IX_OSNameAndVersion_OSVersionId",
                table: "OSNameAndVersion",
                column: "OSVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CamerasId",
                table: "Products",
                column: "CamerasId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CaseMaterialId",
                table: "Products",
                column: "CaseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CaseTypeId",
                table: "Products",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DisplayTechnologyId",
                table: "Products",
                column: "DisplayTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OSNameAndVersionId",
                table: "Products",
                column: "OSNameAndVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProtectionLevelId",
                table: "Products",
                column: "ProtectionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RAMMemoryId",
                table: "Products",
                column: "RAMMemoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageCapacityId",
                table: "Products",
                column: "StorageCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_USBTypeId",
                table: "Products",
                column: "USBTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CartId",
                table: "ShoppingCartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "CaseMaterial");

            migrationBuilder.DropTable(
                name: "CaseType");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DisplayTechnology");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "OSNameAndVersion");

            migrationBuilder.DropTable(
                name: "ProtectionLevel");

            migrationBuilder.DropTable(
                name: "StorageCapacity");

            migrationBuilder.DropTable(
                name: "USB");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OperatingSystemVersion");

            migrationBuilder.DropTable(
                name: "OperatingSystems");
        }
    }
}
