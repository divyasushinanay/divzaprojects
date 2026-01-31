using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class idupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "Id", "ContactNumber", "Email", "Name", "PasswordHash", "Username" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), null, "academy@mail.com", null, "$2a$11$YzWrawmUOvoUjAP2gYGywu13/UoTAwciLqWhIQGKd.rxkMwfcDqWe", "academyadmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
