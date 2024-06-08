using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Hotels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "150 Piccadilly, St. James's, London W1J 9BR", "Londyn", "/images/ritz_london.jpg", "The Ritz London", 500m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Place du Casino, 98000 Monte-Carlo", "Monte-Carlo", "/images/de_paris_monte_carlo.jpg", "Hotel de Paris Monte-Carlo", 700m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "112 Rue du Faubourg Saint-Honoré, 75008 Paris", "Paryż", "/images/le_bristol_paris.jpg", "Le Bristol Paris", 800m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Philharmoniker Str. 4, 1010 Wien", "Wiedeń", "/images/sacher_wien.jpg", "Hotel Sacher Wien", 600m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Unter den Linden 77, 10117 Berlin", "Berlin", "/images/adlon_kempinski_berlin.jpg", "Adlon Kempinski Berlin", 550m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Riva degli Schiavoni, 4196, 30122 Venezia", "Wenecja", "/images/danieli_venezia.jpg", "Hotel Danieli", 650m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "31 Avenue George V, 75008 Paris", "Paryż", "/images/george_v_paris.jpg", "Four Seasons Hotel George V", 850m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Via Vittorio Veneto, 125, 00187 Roma", "Rzym", "/images/westin_excelsior_rome.jpg", "The Westin Excelsior", 450m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "Brook St, Mayfair, London W1K 4HR", "Londyn", "/images/claridges_london.jpg", "Claridge's", 500m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "City", "ImageUrl", "Name", "PricePerNight" },
                values: new object[] { "1 Princes St, Edinburgh EH2 2EQ", "Edynburg", "/images/balmoral_edinburgh.jpg", "The Balmoral", 400m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Marszałkowska 1", "Warszawa", "Hotel Warszawa", 300m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Floriańska 2", "Kraków", "Hotel Kraków", 250m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Rynek 3", "Wrocław", "Hotel Wrocław", 220m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Święty Marcin 4", "Poznań", "Hotel Poznań", 200m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Długa 5", "Gdańsk", "Hotel Gdańsk", 240m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Wojska Polskiego 6", "Szczecin", "Hotel Szczecin", 210m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Mariacka 7", "Katowice", "Hotel Katowice", 230m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Krakowskie Przedmieście 8", "Lublin", "Hotel Lublin", 190m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Lipowa 9", "Białystok", "Hotel Białystok", 180m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "City", "Name", "PricePerNight" },
                values: new object[] { "ul. Piotrkowska 10", "Łódź", "Hotel Łódź", 270m });
        }
    }
}
