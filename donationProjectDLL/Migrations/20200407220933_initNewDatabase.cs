using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace donationProjectDLL.Migrations
{
    public partial class initNewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    cityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "itemCategory",
                columns: table => new
                {
                    itemCategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategory", x => x.itemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "itemDonation",
                columns: table => new
                {
                    itemDonationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    donationDate = table.Column<DateTime>(nullable: false),
                    donationId = table.Column<int>(nullable: false),
                    receiverId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    ammount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemDonation", x => x.itemDonationId);
                });

            migrationBuilder.CreateTable(
                name: "moneyDonation",
                columns: table => new
                {
                    moneyDonationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    donationDate = table.Column<DateTime>(nullable: false),
                    donationId = table.Column<int>(nullable: false),
                    receiverId = table.Column<int>(nullable: false),
                    ammount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneyDonation", x => x.moneyDonationId);
                });

            migrationBuilder.CreateTable(
                name: "userType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    typeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cityArea",
                columns: table => new
                {
                    areaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cityId = table.Column<int>(nullable: true),
                    areaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityArea", x => x.areaId);
                    table.ForeignKey(
                        name: "FK_cityArea_city_cityId",
                        column: x => x.cityId,
                        principalTable: "city",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "itemDetails",
                columns: table => new
                {
                    itemDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemCategoryId = table.Column<int>(nullable: true),
                    ownerId = table.Column<int>(nullable: false),
                    itemName = table.Column<string>(nullable: true),
                    itemDescription = table.Column<string>(nullable: true),
                    ammount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemDetails", x => x.itemDetailId);
                    table.ForeignKey(
                        name: "FK_itemDetails_itemCategory_itemCategoryId",
                        column: x => x.itemCategoryId,
                        principalTable: "itemCategory",
                        principalColumn: "itemCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organizationData",
                columns: table => new
                {
                    organizationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    licenseNumber = table.Column<string>(nullable: true),
                    userGuid = table.Column<Guid>(nullable: false),
                    organizationName = table.Column<string>(nullable: true),
                    aboutOrganization = table.Column<string>(nullable: true),
                    organizationAddress = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    areaId1 = table.Column<int>(nullable: true),
                    cityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationData", x => x.organizationId);
                    table.ForeignKey(
                        name: "FK_organizationData_cityArea_areaId1",
                        column: x => x.areaId1,
                        principalTable: "cityArea",
                        principalColumn: "areaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userRecord",
                columns: table => new
                {
                    userRecordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userGuid = table.Column<Guid>(nullable: false),
                    userFirstName = table.Column<string>(nullable: true),
                    userLastName = table.Column<string>(nullable: true),
                    userCNIC = table.Column<string>(nullable: true),
                    familyNumber = table.Column<string>(nullable: true),
                    userAddress = table.Column<string>(nullable: true),
                    userAddressPerCNIC = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    cityId = table.Column<int>(nullable: false),
                    areaId1 = table.Column<int>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    UserTypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRecord", x => x.userRecordId);
                    table.ForeignKey(
                        name: "FK_userRecord_userType_UserTypeid",
                        column: x => x.UserTypeid,
                        principalTable: "userType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userRecord_cityArea_areaId1",
                        column: x => x.areaId1,
                        principalTable: "cityArea",
                        principalColumn: "areaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cnicPicRecord",
                columns: table => new
                {
                    cnicPicRecordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userRecordId = table.Column<int>(nullable: false),
                    userGuid = table.Column<Guid>(nullable: false),
                    cnicFrontPicPath = table.Column<string>(nullable: true),
                    cnicBackPicPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnicPicRecord", x => x.cnicPicRecordId);
                    table.ForeignKey(
                        name: "FK_cnicPicRecord_userRecord_userRecordId",
                        column: x => x.userRecordId,
                        principalTable: "userRecord",
                        principalColumn: "userRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "familyMembersRecords",
                columns: table => new
                {
                    familyMembersRecordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userRecordId = table.Column<int>(nullable: false),
                    numberOfFamilyMembers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familyMembersRecords", x => x.familyMembersRecordId);
                    table.ForeignKey(
                        name: "FK_familyMembersRecords_userRecord_userRecordId",
                        column: x => x.userRecordId,
                        principalTable: "userRecord",
                        principalColumn: "userRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "screenNameRecord",
                columns: table => new
                {
                    screenNameRecordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userGuid = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    userRecordId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_screenNameRecord", x => x.screenNameRecordId);
                    table.ForeignKey(
                        name: "FK_screenNameRecord_userRecord_userRecordId",
                        column: x => x.userRecordId,
                        principalTable: "userRecord",
                        principalColumn: "userRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cityArea_cityId",
                table: "cityArea",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_cnicPicRecord_userRecordId",
                table: "cnicPicRecord",
                column: "userRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_familyMembersRecords_userRecordId",
                table: "familyMembersRecords",
                column: "userRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_itemCategoryId",
                table: "itemDetails",
                column: "itemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationData_areaId1",
                table: "organizationData",
                column: "areaId1");

            migrationBuilder.CreateIndex(
                name: "IX_screenNameRecord_userRecordId",
                table: "screenNameRecord",
                column: "userRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRecord_UserTypeid",
                table: "userRecord",
                column: "UserTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_userRecord_areaId1",
                table: "userRecord",
                column: "areaId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cnicPicRecord");

            migrationBuilder.DropTable(
                name: "familyMembersRecords");

            migrationBuilder.DropTable(
                name: "itemDetails");

            migrationBuilder.DropTable(
                name: "itemDonation");

            migrationBuilder.DropTable(
                name: "moneyDonation");

            migrationBuilder.DropTable(
                name: "organizationData");

            migrationBuilder.DropTable(
                name: "screenNameRecord");

            migrationBuilder.DropTable(
                name: "itemCategory");

            migrationBuilder.DropTable(
                name: "userRecord");

            migrationBuilder.DropTable(
                name: "userType");

            migrationBuilder.DropTable(
                name: "cityArea");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
