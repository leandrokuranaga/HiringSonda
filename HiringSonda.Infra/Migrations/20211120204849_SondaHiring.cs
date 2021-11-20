using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiringSonda.Infra.Migrations
{
    public partial class SondaHiring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "AddressUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IDUser",
                table: "AddressUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
