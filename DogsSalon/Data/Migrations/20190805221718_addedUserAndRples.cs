using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogsSalon.Data.Migrations
{
    public partial class addedUserAndRples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "creationDate",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "creationDate",
                table: "AspNetRoles");
        }
    }
}
