using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MerchantFeeAutomation
{
    internal class ExcelOperations
    {
        public ExcelOperations()
        {
        }
        public void createExcelFile(string fileName, string workSheet)
        {
            string filePath = fileName;

            if (!File.Exists(filePath))
            {
                using var wbook = new XLWorkbook();

                var ws = wbook.Worksheets.Add(workSheet);

                wbook.SaveAs(filePath);
            }
            else
            {

            }
        }
        public List<Tuple<string, string, string>> ExcelToTupleMarket(string fileName, string workSheet)
        {
            List<Tuple<string, string, string>> tupleMarket = new List<Tuple<string, string, string>>();
            using var wbook = new XLWorkbook(fileName);
            var ws = wbook.Worksheet(workSheet);
            var rows = ws.RangeUsed().RowsUsed();
            int rowCount = 0;
            foreach (var row in rows)
            {
                if(rowCount != 0)                
                    tupleMarket.Add(new Tuple<string, string, string>(row.Cell(1).Value.ToString(), row.Cell(2).Value.ToString(), row.Cell(3).Value.ToString()));
                rowCount++;
            }
            return tupleMarket;

        }
        public List<Tuple<string, string, string>> ExcelToTupleQty(string fileName, string workSheet)
        {
            List<Tuple<string, string, string>> tupleMarket = new List<Tuple<string, string, string>>();
            using var wbook = new XLWorkbook(fileName);
            var ws = wbook.Worksheet(workSheet);
            var rows = ws.RangeUsed().RowsUsed();
            int rowCount = 0;
            foreach (var row in rows)
            {
                if (rowCount != 0)
                    tupleMarket.Add(new Tuple<string, string, string>(row.Cell(4).Value.ToString(), row.Cell(2).Value.ToString(), row.Cell(3).Value.ToString()));
                rowCount++;
            }
            return tupleMarket;

        }
        public void insertDataInExcel(string fileName, string workSheet, DataTable DT, ProgressBar progressBar, Label label)
        {
            fileName = fileName + "_" + workSheet + "_"  + DateTime.Now.ToString("dd-MMM-yyyy HHmmss") + ".xlsx";
            createExcelFile(fileName, workSheet);
            
            using var wbook = new XLWorkbook(fileName);
            var ws = wbook.Worksheet(workSheet);
            var ws1 = wbook.Worksheets.Add("xyz7891");
            wbook.SaveAs(fileName);
            ws.Delete();
            wbook.SaveAs(fileName);
            ws = wbook.Worksheets.Add(workSheet);
            wbook.SaveAs(fileName);
            ws1.Delete();
            wbook.SaveAs(fileName);
            int rownum = 1;
            ws.Cell("A1").Value = "Market";
            ws.Cell("B1").Value = "Store";
            ws.Cell("C1").Value = "TechID";
            ws.Cell("D1").Value = "ItemNum";
            ws.Cell("E1").Value = "Item Description";
            ws.Cell("F1").Value = "Quantity (Packs)";
            ws.Cell("G1").Value = "Cost (Total)";
            ws.Cell("H1").Value = "Quantity (Units)";
            ws.Cell("I1").Value = "Cost (Per Unit)";
            ws.Cell("J1").Value = "OrderDate";
            ws.Cell("K1").Value = "OrderStatus";
            ws.Cell("L1").Value = "ReferenceNumber";
            ws.Cell("M1").Value = "OrderNo";
            ws.Cell("N1").Value = "Vendor Idoo";
            ws.Cell("O1").Value = "Date";
            ws.Cell("P1").Value = "Day";
            ws.Cell("Q1").Value = "Status";
            ws.Cell("R1").Value = "Tracking";

            foreach (DataRow row in DT.Rows)
            {
                rownum++;
                ws.Cell("A" + rownum.ToString()).Value = row["Market"].ToString(); 
                string[] address = row["deliveryAddress"].ToString().Split(",");
                ws.Cell("B" + rownum.ToString()).Value = address[0];
                ws.Cell("C" + rownum.ToString()).Value = row["referenceNumber"].ToString().Substring(5);
                ws.Cell("D" + rownum.ToString()).Value = row["product"].ToString();
                ws.Cell("E" + rownum.ToString()).Value = row["description"].ToString();
                ws.Cell("F" + rownum.ToString()).Value = row["quantity"].ToString();
                ws.Cell("G" + rownum.ToString()).Value = row["totalPrice"].ToString().Replace("USD", "").Trim();
                ws.Cell("H" + rownum.ToString()).Value = row["totalDevices"].ToString();
                ws.Cell("I" + rownum.ToString()).Value = row["unitPricePerDevice"].ToString();
                ws.Cell("J" + rownum.ToString()).Value = row["orderDate"].ToString();
                ws.Cell("K" + rownum.ToString()).Value = row["orderStatus"].ToString();
                ws.Cell("L" + rownum.ToString()).Value = row["referenceNumber"].ToString();
                ws.Cell("M" + rownum.ToString()).Value = row["orderNo"].ToString();
                ws.Cell("N" + rownum.ToString()).Value = row["vendor"].ToString();
                string[] status = row["status"].ToString().Split(" ");
                ws.Cell("Q" + rownum.ToString()).Value = status[0];
                int colNum = 0;
                if(status.Length >=2)
                    for(int i=1; i< status.Length; i++)
                    {
                        if (!(string.IsNullOrEmpty(status[i]) || status[i] == " "))
                        {
                            ws.Cell(rownum, 18 + colNum).Value = status[i];
                            colNum++;
                        }
                    }

                label.Text = "Writing record " + rownum + " in Excel file..";
                progressBar.Value = ((rownum-1) * 100) / DT.Rows.Count;
            }
            wbook.SaveAs(fileName);
            progressBar.Value = 100;
            label.Text = "Excel file " + fileName + " is ready..";
        }

    }
}