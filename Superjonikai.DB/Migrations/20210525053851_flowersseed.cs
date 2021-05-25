using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjonikai.DB.Migrations
{
    public partial class flowersseed : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Image_path",
                table: "Flowers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Image_path" },
                values: new object[] { "pink", "https://image.freepik.com/free-photo/pink-tulip-flowers-isolated-white-background-clipping-path_290947-34.jpg" });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image_path",
                value: "https://www.terrafolia.ca/media/catalog/product/cache/1/image/650x/040ec09b1e35df139433887a97daa66f/l/o/long_stem_yellow_roses_sd_l.jpg");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Image_path" },
                values: new object[] { "white", "https://www.funnyhowflowersdothat.co.uk/sites/flowers/files/styles/article_portrait/public/lelie_mooiwatbloemendoen_rouwboeket_4.jpg?itok=T851ZW44" });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image_path",
                value: "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_path",
                table: "Flowers");

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
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "yellow");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "yellow");
        }
    }
}
