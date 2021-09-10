using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "27619fe1-21b6-4333-b22f-8ff88c0dcba2");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "54dd6c22-90d1-4587-b513-c7bd3cdc543e");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "f09ee986-b8d6-4e90-8439-bc0c35ed3140");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d166ee8-1e3d-4a59-9fe1-1ae9ae31c486", "a6c49650-0801-467b-9d8a-0770b18ec45c", "User", "USER" },
                    { "61359ef9-10fe-4e16-952d-4d253f88f605", "3b1ddb81-af20-4459-8b67-9b94bbb28031", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[,]
                {
                    { "136ee935-ee94-4d5d-9533-1994be6e9302", "folakealabi@gmail.com", "Folake", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alabi", "09045689909" },
                    { "5040e0c9-4232-4167-8e0f-05dcdd1f6fe5", "jamesariyo@gmail.com", "James", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Ariyo", "09078976654" },
                    { "61a37c7c-2644-4e17-a407-7d9c41ff69f7", "kolaqalagbo@gmail.com", "Kolaq", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alagbo", "09045689978" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61359ef9-10fe-4e16-952d-4d253f88f605");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d166ee8-1e3d-4a59-9fe1-1ae9ae31c486");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "136ee935-ee94-4d5d-9533-1994be6e9302");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "5040e0c9-4232-4167-8e0f-05dcdd1f6fe5");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "61a37c7c-2644-4e17-a407-7d9c41ff69f7");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "f09ee986-b8d6-4e90-8439-bc0c35ed3140", "folakealabi@gmail.com", "Folake", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alabi", "09045689909" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "27619fe1-21b6-4333-b22f-8ff88c0dcba2", "jamesariyo@gmail.com", "James", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Ariyo", "09078976654" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "Phone" },
                values: new object[] { "54dd6c22-90d1-4587-b513-c7bd3cdc543e", "kolaqalagbo@gmail.com", "Kolaq", "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg", "Alagbo", "09045689978" });
        }
    }
}
