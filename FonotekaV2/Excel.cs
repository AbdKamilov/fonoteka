using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace FonotekaV2
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel()
        {

        }
        
        public void CreateNewFile(int DataSize)
        {
            excel.Visible = true;
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = wb.Worksheets[1];
            ws.Columns[1].ColumnWidth = 6;
            ws.Columns[2].ColumnWidth = 5;
            ws.Columns[3].ColumnWidth = 6;
            ws.Columns[4].ColumnWidth = 16;
            ws.Columns[5].ColumnWidth = 14;
            ws.Columns[6].ColumnWidth = 12;
            ws.Columns[7].ColumnWidth = 13;
            ws.Columns[8].ColumnWidth = 15;
            ws.Columns[9].ColumnWidth = 7;
            ws.Columns[10].ColumnWidth = 9;
            ws.Columns[11].ColumnWidth = 12;
            ws.Columns[12].ColumnWidth = 8;

            ws.Columns.VerticalAlignment = XlVAlign.xlVAlignTop;
            ws.Columns.WrapText = true;
            //ws.Columns.Style.Font.Size = 12;
            //ws.Columns.BorderAround(XlLineStyle.xlDouble, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic);
            //ws.Range.Borders.LineStyle = XlLineStyle.xlContinuous;
            //ws.Range.Borders.Weight = XlBorderWeight.xlThin;


            for (int i = 1; i <= 12; i++) // this will aply it form col 1 to 10
            {
                ws.Cells[2, i].Font.Bold = true;
                ws.Cells[2, i].Borders.LineStyle = XlLineStyle.xlContinuous;
                ws.Cells[2, i].Borders.Weight = XlBorderWeight.xlThin;
            }
        }

        public void WriteRange(int starti, int starty, int endi, int endy, string[,] writestring)
        {
            ws.Cells[2, 1] = "DVD NO";
            ws.Cells[2, 2] = "CD NO";
            ws.Cells[2, 3] = "№ Золотого фонда";
            ws.Cells[2, 4] = "Название записи";
            ws.Cells[2, 5] = "Автор музыки";
            ws.Cells[2, 6] = "Автор слов";
            ws.Cells[2, 7] = "Исполнитель";
            ws.Cells[2, 8] = "Сопровождение";
            ws.Cells[2, 9] = "Год";
            ws.Cells[2, 10] = "Звучание";
            ws.Cells[2, 11] = "Отдел";
            ws.Cells[2, 12] = "Вариант";
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writestring;
            range.Borders.LineStyle = XlLineStyle.xlContinuous;
            range.Borders.Weight = XlBorderWeight.xlThin;
        }
    }
}
