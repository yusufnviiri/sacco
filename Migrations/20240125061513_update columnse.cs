using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sacco.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumnse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Members_memberId",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "memberId",
                table: "Deposits",
                newName: "Depositor");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_memberId",
                table: "Deposits",
                newName: "IX_Deposits_Depositor");

            migrationBuilder.AddColumn<int>(
                name: "DepositId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Members_Depositor",
                table: "Deposits",
                column: "Depositor",
                principalTable: "Members",
                principalColumn: "memberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Members_Depositor",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "DepositId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Depositor",
                table: "Deposits",
                newName: "memberId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_Depositor",
                table: "Deposits",
                newName: "IX_Deposits_memberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Members_memberId",
                table: "Deposits",
                column: "memberId",
                principalTable: "Members",
                principalColumn: "memberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
