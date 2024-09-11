using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_users_ManagerId",
                table: "Complains");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Complains",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_users_ManagerId",
                table: "Complains",
                column: "ManagerId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_users_ManagerId",
                table: "Complains");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Complains",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_users_ManagerId",
                table: "Complains",
                column: "ManagerId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
