using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentHousing.Migrations
{
    public partial class ListingMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address3",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "PeopleSignedUp",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomAvailable",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleSignedUp",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RoomAvailable",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "Items",
                nullable: true);
        }
    }
}
