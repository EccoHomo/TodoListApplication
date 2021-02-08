using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApplication.DataAccess
{
    public partial class Model_Size_Reduce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOverdue",
                table: "TodoItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TodoItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOverdue",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
