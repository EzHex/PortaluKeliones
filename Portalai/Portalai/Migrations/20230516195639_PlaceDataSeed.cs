using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portalai.Migrations
{
    public partial class PlaceDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 25.280000000000001, 54.687199999999997, "Vilnius" },
                    { 2, 23.886099999999999, 54.897199999999998, "Kaunas" },
                    { 3, 21.166699999999999, 55.75, "Klaipeda" },
                    { 4, 24.350000000000001, 55.7333, "Panevezys" },
                    { 5, 23.316700000000001, 55.933300000000003, "Siauliai" },
                    { 6, 24.049199999999999, 54.401400000000002, "Alytus" },
                    { 7, 23.350000000000001, 54.547199999999997, "Marijampole" },
                    { 8, 22.333300000000001, 56.316699999999997, "Mazeikiai" },
                    { 9, 24.2806, 55.072200000000002, "Jonava" },
                    { 10, 25.600000000000001, 55.5, "Utena" },
                    { 11, 23.966699999999999, 55.283299999999997, "Kedainiai" },
                    { 12, 22.25, 55.9833, "Telsiai" },
                    { 13, 22.2897, 55.252200000000002, "Taurage" },
                    { 14, 24.75, 55.25, "Ukmerge" },
                    { 15, 26.437999999999999, 55.597999999999999, "Visaginas" },
                    { 16, 21.066700000000001, 55.916699999999999, "Palanga" },
                    { 17, 21.850000000000001, 55.916699999999999, "Plunge" },
                    { 18, 21.2422, 55.890000000000001, "Kretinga" },
                    { 19, 21.4833, 55.350000000000001, "Silute" },
                    { 20, 23.550000000000001, 55.799999999999997, "Radviliskis" },
                    { 21, 23.966699999999999, 54.0167, "Druskininkai" },
                    { 22, 25.583300000000001, 55.966700000000003, "Rokiskis" },
                    { 23, 24.661100000000001, 54.786099999999998, "Elektrenai" },
                    { 24, 22.7667, 55.083300000000001, "Jurbarkas" },
                    { 25, 24.75, 56.200000000000003, "Birzai" },
                    { 26, 23.033300000000001, 54.649999999999999, "Vilkaviskis" },
                    { 27, 23.116700000000002, 55.366700000000002, "Raseiniai" },
                    { 28, 23.941700000000001, 54.633299999999998, "Prienai" },
                    { 29, 23.600000000000001, 56.2333, "Joniskis" },
                    { 30, 25.100000000000001, 55.533299999999997, "Anyksciai" },
                    { 31, 24.572199999999999, 54.211100000000002, "Varena" },
                    { 32, 24.449999999999999, 54.866700000000002, "Kaisiadorys" },
                    { 33, 22.899999999999999, 56.316699999999997, "Naujoji Akmene" },
                    { 34, 22.933299999999999, 55.633299999999998, "Kelme" },
                    { 35, 25.383299999999998, 54.316699999999997, "Salcininkai" },
                    { 36, 24.403600000000001, 56.059399999999997, "Pasvalys" },
                    { 37, 24.966699999999999, 55.833300000000001, "Kupiskis" },
                    { 38, 26.25, 55.7333, "Zarasai" },
                    { 39, 24.933299999999999, 54.633299999999998, "Trakai" },
                    { 40, 25.416699999999999, 55.2333, "Moletai" },
                    { 41, 23.5, 54.75, "Kazlu Ruda" },
                    { 42, 23.050000000000001, 54.950000000000003, "Sakiai" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 43, 21.533300000000001, 56.2667, "Skuodas" },
                    { 44, 26.166699999999999, 55.350000000000001, "Ignalina" },
                    { 45, 22.183299999999999, 55.4833, "Silale" },
                    { 46, 23.866700000000002, 55.966700000000003, "Pakruojis" },
                    { 47, 26.1556, 55.133299999999998, "Svencionys" },
                    { 48, 23.216699999999999, 54.416699999999999, "Kalvarija" },
                    { 49, 23.5167, 54.2333, "Lazdijai" },
                    { 50, 21.933299999999999, 55.716700000000003, "Rietavas" },
                    { 51, 24.020600000000002, 54.602800000000002, "Birstonas" },
                    { 52, 21.005600000000001, 55.3033, "Nida" },
                    { 53, 24.9694, 55.036099999999998, "Sirvintos" },
                    { 54, 21.916699999999999, 55.133299999999998, "Pagegiai" },
                    { 55, 21.403300000000002, 55.712800000000001, "Gargzdai" },
                    { 56, 25.199999999999999, 54.600000000000001, "Aukstieji Paneriai" },
                    { 57, 25.100000000000001, 54.666699999999999, "Grigiskes" },
                    { 58, 22.916699999999999, 55.9833, "Kursenai" },
                    { 59, 23.997, 54.395000000000003, "Likiskiai" },
                    { 60, 23.866700000000002, 54.816699999999997, "Garliava" },
                    { 61, 25.066700000000001, 54.649999999999999, "Lentvaris" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 61);
        }
    }
}
