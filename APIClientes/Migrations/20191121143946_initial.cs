using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIClientes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 21, 11, 39, 46, 576, DateTimeKind.Local).AddTicks(3213))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
