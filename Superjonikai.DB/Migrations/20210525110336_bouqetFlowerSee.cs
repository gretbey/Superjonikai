using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjonikai.DB.Migrations
{
    public partial class bouqetFlowerSee : Migration
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
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "Paster pink, white", "https://i.pinimg.com/564x/45/5f/82/455f828caa233226cee118db368c1150.jpg", "Peony please", 48.0 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "Purple, pink", "https://i.pinimg.com/564x/39/1a/e2/391ae2faa2451615d0edbaa5a6a99eb6.jpg", "Ramos de flores", 43.0 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "White, brown", "https://i.pinimg.com/564x/b1/f6/ab/b1f6abaa27472a78c4a460fa16a5ce1a.jpg", "Dried cotton", 38.0 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "Pastel orange, yellow", "https://i.pinimg.com/564x/47/a2/98/47a298931d888efe24b220770ba9f793.jpg", "Early spring", 40.0 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "Light brown, baby pink", "https://i.pinimg.com/564x/96/6d/81/966d81ea338beeb0db1da246d6e80194.jpg", "Earthy palette", 42.0 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Image_path", "Price" },
                values: new object[] { "pink, white", "https://i.pinimg.com/564x/a7/b8/5f/a7b85f63378f0d3fa6c6e5b8c7aad8c5.jpg", 1.8 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image_path", "Price" },
                values: new object[] { "https://i.pinimg.com/564x/1d/c6/09/1dc609deb67c38a9befd92b2096b522d.jpg", 2.0 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image_path",
                value: "https://i.pinimg.com/564x/94/33/cd/9433cdf12d481789805feae9c411aecb.jpg");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 4.5);

            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "Id", "Color", "Image_path", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "pink", "https://i.pinimg.com/564x/68/e4/a6/68e4a652bcc02790770af653291f0b60.jpg", "Peony", 3.5 },
                    { 6, "multi", "https://i.pinimg.com/564x/14/c2/63/14c263f41a10ec9ac59bb6a025a38169.jpg", "Foxglove", 7.7999999999999998 },
                    { 7, "multi", "https://i.pinimg.com/564x/1f/85/3c/1f853cec192d3146e460279aebada93d.jpg", "Russels", 10.199999999999999 },
                    { 8, "purple", "https://i.pinimg.com/564x/49/80/99/498099543e6263cab8f0122002e4acf2.jpg", "Levander", 5.5999999999999996 },
                    { 9, "multi", "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg", "Bunny tails", 1.2 },
                    { 10, "white", "https://i.pinimg.com/564x/08/53/f8/0853f8c46e7d7e0e868aab63346ddec9.jpg", "Camomile", 1.5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 10);

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
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "yellow", null, "Simply gorgeous bouquet", 60.299999999999997 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "yellow", null, "Summer flowers bouquet", 40.299999999999997 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "yellow", null, "Mixed flowers", 16.399999999999999 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "yellow", null, "Roses box", 12.0 });

            migrationBuilder.UpdateData(
                table: "Bouquets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Image_path", "Name", "Price" },
                values: new object[] { "yellow", null, "Bright flower bouquet", 10.0 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Image_path", "Price" },
                values: new object[] { "pink", "https://image.freepik.com/free-photo/pink-tulip-flowers-isolated-white-background-clipping-path_290947-34.jpg", 0.69999999999999996 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image_path", "Price" },
                values: new object[] { "https://www.terrafolia.ca/media/catalog/product/cache/1/image/650x/040ec09b1e35df139433887a97daa66f/l/o/long_stem_yellow_roses_sd_l.jpg", 4.0 });

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image_path",
                value: "https://www.funnyhowflowersdothat.co.uk/sites/flowers/files/styles/article_portrait/public/lelie_mooiwatbloemendoen_rouwboeket_4.jpg?itok=T851ZW44");

            migrationBuilder.UpdateData(
                table: "Flowers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 7.5);
        }
    }
}
