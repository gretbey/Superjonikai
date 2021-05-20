using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjonikai.DB.Migrations
{
    public partial class seeddata : Migration
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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientName", "Status" },
                values: new object[] { "Tom Jenkins", "Completed" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientName", "DeliveryDate", "Status" },
                values: new object[,]
                {
                    { 2, "Lalaila Smith", new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paid" },
                    { 3, "Thomas Miller", new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing" },
                    { 4, "John Brown", new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientName", "Status" },
                values: new object[] { "Kasparas", "Processing" });
        }
    }
}
