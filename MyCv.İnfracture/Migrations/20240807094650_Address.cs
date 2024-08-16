using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCv.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.AlterColumn<short>(
                name: "PhoneNumber",
                table: "Clients",
                type: "smallint",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
