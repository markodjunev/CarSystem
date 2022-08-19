using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSystem.Data.Migrations
{
    public partial class AddImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CarImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "CarImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_ImageId",
                table: "CarImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Images_ImageId",
                table: "CarImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Images_ImageId",
                table: "CarImages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_ImageId",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "CarImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CarImages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
