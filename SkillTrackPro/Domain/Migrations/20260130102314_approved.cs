using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class approved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Coaches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "Id", "ContactNumber", "Email", "Name", "PasswordHash", "Username" },
                values: new object[] { new Guid("1554084f-075b-4737-8d33-9796c05d8e43"), null, "academy@mail.com", "Main Academy", "$2a$11$lYA7RHChhDwFn1.Ogp6EFO/fYOWT.alOIysFI9IP8tqIJ8mWaQg.y", "academyadmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "Id",
                keyValue: new Guid("1554084f-075b-4737-8d33-9796c05d8e43"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Coaches");

            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "Id", "ContactNumber", "Email", "Name", "PasswordHash", "Username" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), null, "academy@mail.com", null, "$2a$11$YzWrawmUOvoUjAP2gYGywu13/UoTAwciLqWhIQGKd.rxkMwfcDqWe", "academyadmin" });
        }
    }
}
