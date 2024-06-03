﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zad10.Migrations
{
    /// <inheritdoc />
    public partial class Initializedatabasetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PK_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PK_category);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    PK_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    width = table.Column<double>(type: "float", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    depth = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.PK_product);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PK_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PK_role);
                });

            migrationBuilder.CreateTable(
                name: "Products_Categories",
                columns: table => new
                {
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    FK_category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Categories", x => new { x.FK_product, x.FK_category });
                    table.ForeignKey(
                        name: "FK_Products_Categories_Categories_FK_category",
                        column: x => x.FK_category,
                        principalTable: "Categories",
                        principalColumn: "PK_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PK_account = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    FK_role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PK_account);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_FK_role",
                        column: x => x.FK_role,
                        principalTable: "Roles",
                        principalColumn: "PK_role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    FK_account = table.Column<int>(type: "int", nullable: false),
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => new { x.FK_account, x.FK_product });
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Accounts_FK_account",
                        column: x => x.FK_account,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[,]
                {
                    { 1, "Kategoria 1" },
                    { 2, "Kategoria 2" },
                    { 3, "Kategoria 3" },
                    { 4, "Kategoria 4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[,]
                {
                    { 1, 5.2000000000000002, 3.1000000000000001, "Prod 1", 52.299999999999997, 10.300000000000001 },
                    { 2, 5.2000000000000002, 3.1000000000000001, "Prod 2", 52.299999999999997, 10.300000000000001 },
                    { 3, 5.2000000000000002, 3.1000000000000001, "Prod 3", 52.299999999999997, 10.300000000000001 },
                    { 4, 5.2000000000000002, 3.1000000000000001, "Prod 4", 52.299999999999997, 10.300000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "last_name", "phone", "FK_role" },
                values: new object[,]
                {
                    { 1, "Email1", "First1", "Last1", "123456789", 1 },
                    { 2, "Email2", "First2", "Last2", "987654321", 2 },
                    { 3, "Email3", "First3", "Last3", "654321789", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products_Categories",
                columns: new[] { "FK_category", "FK_product" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 2 },
                    { 3, 3 },
                    { 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_account", "FK_product", "Amount" },
                values: new object[,]
                {
                    { 1, 2, 100 },
                    { 1, 4, 25 },
                    { 2, 3, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts",
                column: "FK_role");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories_FK_category",
                table: "Products_Categories",
                column: "FK_category");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_FK_product",
                table: "Shopping_Carts",
                column: "FK_product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_Categories");

            migrationBuilder.DropTable(
                name: "Shopping_Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
