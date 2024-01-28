using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sacco.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Loans",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Deposits",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "depositId",
                table: "Deposits",
                newName: "DepositId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Loans",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Deposits",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "DepositId",
                table: "Deposits",
                newName: "depositId");
        }
    }
}
