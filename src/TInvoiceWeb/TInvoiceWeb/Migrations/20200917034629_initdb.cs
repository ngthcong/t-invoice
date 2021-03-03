using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TInvoiceWeb.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Contact = table.Column<string>(maxLength: 12, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CusId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(maxLength: 12, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "TmaBanks",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(maxLength: 255, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 255, nullable: true),
                    BankName = table.Column<string>(maxLength: 255, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmaBanks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CusId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CusId",
                        column: x => x.CusId,
                        principalTable: "Customers",
                        principalColumn: "CusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONumber = table.Column<string>(maxLength: 255, nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    InvoiceBillable = table.Column<double>(nullable: false),
                    SharedServiceType = table.Column<string>(maxLength: 255, nullable: true),
                    SharedServiceBilldables = table.Column<string>(maxLength: 255, nullable: true),
                    ShareServiceLaborCost = table.Column<string>(maxLength: 255, nullable: true),
                    OfDCBillables = table.Column<double>(nullable: false),
                    DCOffshoreLaborCost = table.Column<double>(nullable: false),
                    OnsiteCost = table.Column<double>(nullable: false),
                    TaxAndEquipment = table.Column<string>(maxLength: 255, nullable: true),
                    GST = table.Column<string>(maxLength: 255, nullable: true),
                    OtherCost = table.Column<string>(maxLength: 255, nullable: true),
                    Currency = table.Column<string>(maxLength: 255, nullable: true),
                    InvoicedAmount = table.Column<string>(maxLength: 255, nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: false),
                    BankOfPayment = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Sender = table.Column<string>(maxLength: 255, nullable: true),
                    LatestEffectiveDay = table.Column<string>(maxLength: 255, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    ReminderDate = table.Column<string>(maxLength: 255, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    TmaBankId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_TmaBanks_TmaBankId",
                        column: x => x.TmaBankId,
                        principalTable: "TmaBanks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<int>(nullable: false),
                    Des = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentAmount = table.Column<double>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DesId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_InvoiceId",
                table: "Descriptions",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmpId",
                table: "Invoices",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TmaBankId",
                table: "Invoices",
                column: "TmaBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CusId",
                table: "Projects",
                column: "CusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TmaBanks");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
