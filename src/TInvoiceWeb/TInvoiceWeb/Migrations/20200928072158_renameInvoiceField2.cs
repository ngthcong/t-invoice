using Microsoft.EntityFrameworkCore.Migrations;

namespace TInvoiceWeb.Migrations
{
    public partial class renameInvoiceField2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invoicedOffshoreLaborCost",
                table: "Invoices",
                newName: "InvoicedOffshoreLaborCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoicedOffshoreLaborCost",
                table: "Invoices",
                newName: "invoicedOffshoreLaborCost");
        }
    }
}
