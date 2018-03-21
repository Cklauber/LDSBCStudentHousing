using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentHousing.Migrations
{
    public partial class ViewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amendities",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Bathroom",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bedroom",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DownPayment",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Kitchen",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Rent",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "RentIncludeUtil",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SqrFeet",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Utilities",
                table: "Items",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Zip",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "contactName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phoneNumber",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Address3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Amendities",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Bathroom",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Bedroom",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DownPayment",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Kitchen",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RentIncludeUtil",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SqrFeet",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Utilities",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "contactName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Items");
        }
    }
}
