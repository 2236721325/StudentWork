using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_DLL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResultType",
                table: "CheckRecord",
                newName: "IsDanger");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<string>(
                name: "IDCard",
                table: "CheckRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDCard",
                table: "CheckRecord");

            migrationBuilder.RenameColumn(
                name: "IsDanger",
                table: "CheckRecord",
                newName: "ResultType");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
