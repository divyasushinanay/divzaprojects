using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class addedacademiesid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Academies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Academies",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Academies",
                columns: new[] { "Id", "ContactNumber", "Email", "Name", "PasswordHash", "Username" },
                values: new object[] { 1, "+919000000000", "admin@academy.com", "Academy Admin", "change_me_hash", "admin@academy" });
        }
    }
}
