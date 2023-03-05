using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    CATEGORYID = table.Column<int>(name: "CATEGORY_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYNAME = table.Column<string>(name: "CATEGORY_NAME", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "MEMBER",
                columns: table => new
                {
                    MEMBERID = table.Column<int>(name: "MEMBER_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMPANYNAME = table.Column<string>(name: "COMPANY_NAME", type: "nvarchar(max)", nullable: true),
                    CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEMBER", x => x.MEMBERID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ORDERID = table.Column<int>(name: "ORDER_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEMBERID = table.Column<int>(name: "MEMBER_ID", type: "int", nullable: false),
                    ORDERDATE = table.Column<DateTime>(name: "ORDER_DATE", type: "datetime2", nullable: false),
                    REQUIREDDATE = table.Column<DateTime>(name: "REQUIRED_DATE", type: "datetime2", nullable: false),
                    SHIPPEDDATE = table.Column<DateTime>(name: "SHIPPED_DATE", type: "datetime2", nullable: false),
                    FRIEGHT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ORDERID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAIL",
                columns: table => new
                {
                    ORDERID = table.Column<int>(name: "ORDER_ID", type: "int", nullable: false),
                    PRODUCTID = table.Column<int>(name: "PRODUCT_ID", type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    DISCOUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAIL", x => new { x.ORDERID, x.PRODUCTID });
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PRODUCTID = table.Column<int>(name: "PRODUCT_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORYID = table.Column<int>(name: "CATEGORY_ID", type: "int", nullable: false),
                    PRODUCTNAME = table.Column<string>(name: "PRODUCT_NAME", type: "nvarchar(max)", nullable: false),
                    WEIGHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UNITPRICE = table.Column<decimal>(name: "UNIT_PRICE", type: "decimal(18,2)", nullable: false),
                    UNITSINSTOCK = table.Column<int>(name: "UNITS_IN_STOCK", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PRODUCTID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "MEMBER");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "ORDER_DETAIL");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
