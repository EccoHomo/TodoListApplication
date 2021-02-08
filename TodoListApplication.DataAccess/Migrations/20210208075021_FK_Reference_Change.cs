using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApplication.DataAccess
{
    public partial class FK_Reference_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoCategories_CategoryId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_CategoryId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "TodoCategoryId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoCategoryId",
                table: "TodoItems",
                column: "TodoCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoCategories_TodoCategoryId",
                table: "TodoItems",
                column: "TodoCategoryId",
                principalTable: "TodoCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoCategories_TodoCategoryId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoCategoryId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TodoCategoryId",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_CategoryId",
                table: "TodoItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoCategories_CategoryId",
                table: "TodoItems",
                column: "CategoryId",
                principalTable: "TodoCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
