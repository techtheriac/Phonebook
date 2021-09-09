using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "7083b04d-0808-4f75-ba71-e2d61a98bb40", "folakealabi@gmail.com", "Folake", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alabi", "09045689909" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "a0767586-aaa7-4045-bef3-3a20c94c56dc", "jamesariyo@gmail.com", "James", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Ariyo", "09078976654" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "0d477abb-d999-4911-8efb-ddde949685e6", "kolaqalagbo@gmail.com", "Kolaq", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alagbo", "09045689978" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "0d477abb-d999-4911-8efb-ddde949685e6");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "7083b04d-0808-4f75-ba71-e2d61a98bb40");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "a0767586-aaa7-4045-bef3-3a20c94c56dc");
        }
    }
}
