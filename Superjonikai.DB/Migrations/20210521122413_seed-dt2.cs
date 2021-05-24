using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjonikai.DB.Migrations
{
    public partial class seeddt2 : Migration
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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ClientName", "DeliveryDate", "Status" },
                values: new object[] { 5, "TitasGrigaitis", new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "AwaitingPayment" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Token" },
                values: new object[] { 2, "titasgg@gmail.com", "Titas", "Grigaitis", null, null });

            migrationBuilder.InsertData(
                table: "FlowerOrders",
                columns: new[] { "FlowerId", "OrderId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "FlowerOrders",
                columns: new[] { "FlowerId", "OrderId" },
                values: new object[] { 1, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlowerOrders",
                keyColumns: new[] { "FlowerId", "OrderId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "FlowerOrders",
                keyColumns: new[] { "FlowerId", "OrderId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

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
