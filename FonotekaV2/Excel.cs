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
        
        public void CreateNewFile()
        {
            excel.Visible = true;
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = wb.Worksheets[1];
        }

        public void WriteRange(int starti, int starty, int endi, int endy, string[,] writestring)
        {
            ws.Cells[2, 3] = "DVD NO";
            ws.Cells[2, 4] = "CD NO";
            ws.Cells[2, 5] = "№ Оригинала";
            ws.Cells[2, 6] = "№ Золотого фонда";
            ws.Cells[2, 7] = "Рубрика";
            ws.Cells[2, 8] = "Название записи";
            ws.Cells[2, 9] = "Автор музыки";
            ws.Cells[2, 10] = "Автор слов";
            ws.Cells[2, 11] = "Исполнитель";
            ws.Cells[2, 12] = "Сопровождение";
            ws.Cells[2, 13] = "Год";
            ws.Cells[2, 14] = "Жанр";
            ws.Cells[2, 15] = "Звучание";
            ws.Cells[2, 16] = "Тематика";
            ws.Cells[2, 17] = "Отдел";
            ws.Cells[2, 18] = "Вариант";
            ws.Cells[2, 19] = "Аннотация";
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writestring;
        }
    }
}
