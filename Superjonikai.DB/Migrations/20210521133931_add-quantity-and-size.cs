using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjonikai.DB.Migrations
{
    public partial class addquantityandsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Orders",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FlowerOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "BouquetOrders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BouquetOrders",
                keyColumns: new[] { "BouquetId", "OrderId" },
                keyValues: new object[] { 2, 1 },
                column: "Size",
                value: "medium");

            migrationBuilder.UpdateData(
                table: "FlowerOrders",
                keyColumns: new[] { "FlowerId", "OrderId" },
                keyValues: new object[] { 2, 1 },
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "FlowerOrders",
                keyColumns: new[] { "FlowerId", "OrderId" },
                keyValues: new object[] { 1, 5 },
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FlowerOrders",
                keyColumns: new[] { "FlowerId", "OrderId" },
                keyValues: new object[] { 2, 5 },
                column: "Quantity",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FlowerOrders");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BouquetOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Orders",
                type: "timestamp(6)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6)",
                oldRowVersion: true,
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }
    }
}
