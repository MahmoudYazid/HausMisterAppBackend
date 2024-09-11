using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Contracts_contractId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "contractId",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Contracts_contractId",
                table: "users",
                column: "contractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Contracts_contractId",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "contractId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Contracts_contractId",
                table: "users",
                column: "contractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
