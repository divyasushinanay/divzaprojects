using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoachId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CoachId",
                table: "Students",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Coaches_CoachId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CoachId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Students");
        }
    }
}
