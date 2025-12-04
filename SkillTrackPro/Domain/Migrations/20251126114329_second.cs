using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Coaches_CoachId",
                table: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceReviews_CoachId",
                table: "PerformanceReviews");

            migrationBuilder.AddColumn<Guid>(
                name: "CoachId1",
                table: "PerformanceReviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Coaches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_CoachId1",
                table: "PerformanceReviews",
                column: "CoachId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Coaches_CoachId1",
                table: "PerformanceReviews",
                column: "CoachId1",
                principalTable: "Coaches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Coaches_CoachId1",
                table: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceReviews_CoachId1",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "CoachId1",
                table: "PerformanceReviews");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Coaches",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_CoachId",
                table: "PerformanceReviews",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Coaches_CoachId",
                table: "PerformanceReviews",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
