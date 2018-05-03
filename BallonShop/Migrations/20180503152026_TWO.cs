using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BallonShop.Migrations
{
    public partial class TWO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategoryViewModel_SubCategoryViewModelId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubCategoryViewModelId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubCategoryViewModelId1",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryViewModelId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryViewModelId",
                table: "Product",
                column: "SubCategoryViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategoryViewModel_SubCategoryViewModelId",
                table: "Product",
                column: "SubCategoryViewModelId",
                principalTable: "SubCategoryViewModel",
                principalColumn: "SubCategoryViewModelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategoryViewModel_SubCategoryViewModelId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubCategoryViewModelId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubCategoryViewModelId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryViewModelId1",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryViewModelId1",
                table: "Product",
                column: "SubCategoryViewModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategoryViewModel_SubCategoryViewModelId1",
                table: "Product",
                column: "SubCategoryViewModelId1",
                principalTable: "SubCategoryViewModel",
                principalColumn: "SubCategoryViewModelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
