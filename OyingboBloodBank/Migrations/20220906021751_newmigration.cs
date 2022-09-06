using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyingboBloodBank.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blood Group",
                columns: table => new
                {
                    BloodTypeId = table.Column<int>(name: "Blood Type Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(name: "Blood Type", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CanGiveTo = table.Column<string>(name: "Can Give To", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CanRecieveFrom = table.Column<string>(name: "Can Recieve From", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood Group", x => x.BloodTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    DonorId = table.Column<int>(name: "Donor Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DonationDate = table.Column<DateTime>(name: "Donation Date", type: "date", nullable: true),
                    BloodTypeId = table.Column<int>(name: "Blood Type Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.DonorId);
                    table.ForeignKey(
                        name: "FK_Donor_Blood Group",
                        column: x => x.BloodTypeId,
                        principalTable: "Blood Group",
                        principalColumn: "Blood Type Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    RecipientId = table.Column<int>(name: "Recipient Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BloodComponent = table.Column<string>(name: "Blood Component", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BloodTypeId = table.Column<int>(name: "Blood Type Id", type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(name: "Request Date", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.RecipientId);
                    table.ForeignKey(
                        name: "FK_Recipient_Blood Group",
                        column: x => x.BloodTypeId,
                        principalTable: "Blood Group",
                        principalColumn: "Blood Type Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donor_Blood Type Id",
                table: "Donor",
                column: "Blood Type Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_Blood Type Id",
                table: "Recipient",
                column: "Blood Type Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Blood Group");
        }
    }
}
