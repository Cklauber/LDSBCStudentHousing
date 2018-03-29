using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentHousing.Migrations
{
    public partial class EditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Items",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Items",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "contactName",
                table: "Items",
                newName: "ContactName");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Items",
                nullable: true);

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
                name: "MyProperty",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PeopleSignedUp",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RoomAvailable",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Items",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Items",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Items",
                newName: "contactName");
        }
    }
}
