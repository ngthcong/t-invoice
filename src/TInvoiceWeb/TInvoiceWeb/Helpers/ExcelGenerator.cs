using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Helpers
{
    public static class ExcelGenerator
    {
        private static void GenerateWorkbookPartContent(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook();
            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "Sheet1", SheetId = (UInt32Value)1U, Id = "rId1" };
            sheets1.Append(sheet1);
            workbook1.Append(sheets1);
            workbookPart1.Workbook = workbook1;
        }
        private static SheetData GenerateSheetdataForDetails(List<ExcelModel> data)
        {
            SheetData sheetData1 = new SheetData();
            sheetData1.Append(CreateHeaderRowForExcel());

            foreach (ExcelModel testmodel in data)
            {
                Row partsRows = GenerateRowForChildPartDetail(testmodel);
                sheetData1.Append(partsRows);
            }
            return sheetData1;
        }
        private static Row CreateHeaderRowForExcel()
        {
            Row workRow = new Row();
            workRow.Append(CreateCell("#", 2U));
            workRow.Append(CreateCell("Customer Name", 2U));
            workRow.Append(CreateCell("Project name", 2U));
            workRow.Append(CreateCell("Invoice Number", 2U));
            workRow.Append(CreateCell("PO Number", 2U));
            workRow.Append(CreateCell("Invoice Date", 2U));
            workRow.Append(CreateCell("# Invoiced Billable", 2U));
            workRow.Append(CreateCell("Shared Service Type", 2U));
            workRow.Append(CreateCell("#Shared Service Billables", 2U));
            workRow.Append(CreateCell("Share Service Labor Cost", 2U));
            workRow.Append(CreateCell("# of DC Billables", 2U));
            workRow.Append(CreateCell("DC Offshore Labor Cost", 2U));
            workRow.Append(CreateCell("Current Rate", 2U));
            workRow.Append(CreateCell("Invoiced Offshore Labor Cost", 2U));
            workRow.Append(CreateCell("Onsite Cost", 2U));
            workRow.Append(CreateCell("Tax & Equipment", 2U));
            workRow.Append(CreateCell("GST", 2U));
            workRow.Append(CreateCell("Other Cost", 2U));
            workRow.Append(CreateCell("Currency", 2U));
            workRow.Append(CreateCell("Invoiced Amount", 2U));
            workRow.Append(CreateCell("Received Amount", 2U));
            workRow.Append(CreateCell("Received Date", 2U));
            workRow.Append(CreateCell("Bank of Payment", 2U));
            workRow.Append(CreateCell("Description", 2U));
            workRow.Append(CreateCell("Sender", 2U));
            workRow.Append(CreateCell("Status", 2U));
            workRow.Append(CreateCell("Latest Effective day", 2U));
            workRow.Append(CreateCell("Expire Date", 2U));
            workRow.Append(CreateCell("Reminder date (-45d)", 2U));
            return workRow;
        }
        private static Row GenerateRowForChildPartDetail(ExcelModel model)
        {
            Row tRow = new Row();
            tRow.Append(CreateCell(model.InvoiceId.ToString()));
            tRow.Append(CreateCell(model.FullName));
            tRow.Append(CreateCell(model.ProjectName));
            tRow.Append(CreateCell(model.InvoiceNumber));
            tRow.Append(CreateCell(model.PONumber));
            tRow.Append(CreateCell(model.InvoiceDate.ToShortDateString()));
            tRow.Append(CreateCell(model.InvoiceBillable.ToString()));
            tRow.Append(CreateCell(model.SharedServiceType));
            tRow.Append(CreateCell(model.SharedServiceBillables));
            tRow.Append(CreateCell(model.ShareServiceLaborCost));
            tRow.Append(CreateCell(model.OfDCBillables.ToString()));
            tRow.Append(CreateCell(model.DCOffshoreLaborCost.ToString()));
            tRow.Append(CreateCell(model.CurrentRate.ToString()));
            tRow.Append(CreateCell(model.InvoicedOffshoreLaborCost.ToString()));
            tRow.Append(CreateCell(model.OnsiteCost.ToString()));
            tRow.Append(CreateCell(model.TaxAndEquipment));
            tRow.Append(CreateCell(model.GST));
            tRow.Append(CreateCell(model.OtherCost));
            tRow.Append(CreateCell(model.Currency));
            tRow.Append(CreateCell(model.InvoicedAmount));
            tRow.Append(CreateCell(model.ReceivedAmount));
            tRow.Append(CreateCell(model.ReceivedDate.ToShortDateString()));
            tRow.Append(CreateCell(model.BankOfPayment));
            tRow.Append(CreateCell(model.Description));
            tRow.Append(CreateCell(model.Sender));
            tRow.Append(CreateCell(model.Status));
            tRow.Append(CreateCell(model.LatestEffectiveDay));
            tRow.Append(CreateCell(model.ExpireDate.ToShortDateString()));
            tRow.Append(CreateCell(model.ReminderDate));


            return tRow;
        }
        private static Cell CreateCell(string text)
        {
            Cell cell = new Cell();
            cell.StyleIndex = 1U;
            cell.DataType = ResolveCellDataTypeOnValue(text);
            cell.CellValue = new CellValue(text);
            return cell;
        }
        private static Cell CreateCell(string text, uint styleIndex)
        {
            Cell cell = new Cell();
            cell.StyleIndex = styleIndex;
            cell.DataType = ResolveCellDataTypeOnValue(text);
            cell.CellValue = new CellValue(text);
            return cell;
        }
        private static EnumValue<CellValues> ResolveCellDataTypeOnValue(string text)
        {
            int intVal;
            double doubleVal;
            if (int.TryParse(text, out intVal) || double.TryParse(text, out doubleVal))
            {
                return CellValues.Number;
            }
            else
            {
                return CellValues.String;
            }
        }
        public static void CreateExcelFile(List<ExcelModel> data, string path)
        {
            var datetime = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_");
            string webrootPath = Path.Combine("Storage", path);
            if(!File.Exists(webrootPath))
            {
                Directory.CreateDirectory(webrootPath);
            }
            string fileFullname = Path.Combine(webrootPath, "Output.xlsx");

            if (File.Exists(fileFullname))
            {
                fileFullname = Path.Combine(path, "Output_" + datetime + ".xlsx");
            }

            using (SpreadsheetDocument package = SpreadsheetDocument.Create(fileFullname, SpreadsheetDocumentType.Workbook))
            {
                CreatePartsForExcel(package, data);
            }
        }
        private static void GenerateWorksheetPartContent(WorksheetPart worksheetPart1, SheetData sheetData1)
        {
            Worksheet worksheet1 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            SheetDimension sheetDimension1 = new SheetDimension() { Reference = "A1" };



            Fills fills1 = new Fills() { Count = (UInt32Value)2U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            fills1.Append(fill1);
            fills1.Append(fill2);


            Borders borders1 = new Borders() { Count = (UInt32Value)2U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

           
            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);


            SheetViews sheetViews1 = new SheetViews();

            SheetView sheetView1 = new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U };
            Selection selection1 = new Selection() { ActiveCell = "A1", SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A1" } };

            sheetView1.Append(selection1);

            sheetViews1.Append(sheetView1);
            SheetFormatProperties sheetFormatProperties1 = new SheetFormatProperties() { DefaultRowHeight = 15D, DyDescent = 0.25D };

            PageMargins pageMargins1 = new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };
            worksheet1.Append(sheetDimension1);
            worksheet1.Append(sheetViews1);
            worksheet1.Append(fills1);
            worksheet1.Append(borders1);
            worksheet1.Append(sheetFormatProperties1);
            worksheet1.Append(sheetData1);
            worksheet1.Append(pageMargins1);
            worksheetPart1.Worksheet = worksheet1;
        }
       public static void CreatePartsForExcel(SpreadsheetDocument document, List<ExcelModel> data)
        {
            SheetData partSheetData = GenerateSheetdataForDetails(data);

            WorkbookPart workbookPart1 = document.AddWorkbookPart();
            GenerateWorkbookPartContent(workbookPart1);

            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId1");
            GenerateWorksheetPartContent(worksheetPart1, partSheetData);
        }
    }
}
