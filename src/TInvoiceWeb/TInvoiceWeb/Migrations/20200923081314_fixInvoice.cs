using Microsoft.EntityFrameworkCore.Migrations;

namespace TInvoiceWeb.Migrations
{
    public partial class fixInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentRate",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ReceivedAmount",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Invoices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "invoicedOffshoreLaborCost",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentRate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ReceivedAmount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "invoicedOffshoreLaborCost",
                table: "Invoices");
        }
    }
}
