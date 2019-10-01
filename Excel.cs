using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;



namespace VocabularyApp
{
    class Excel
    {
        _Application excel = new Application();
        Workbook wb;
        Worksheet ws;
        string path = null;

        public Excel(string path)
        {

        }
        public Excel(string path, int sheet)
        {
                wb = excel.Workbooks.Open(path);
                ws = wb.Worksheets[sheet];
        }

        //Excel an beliebigen ort speichern
        // Klassenstruktur..

        public void Close()
        {
            wb.Close();
        }

        public void Save(string path)
        {
            wb.SaveAs();
        }

        public void CreateFile(string path)
        {
            wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            ws = wb.Worksheets[1];
            wb.SaveAs(path);
            Close();
        }

        //Liest Alle Werte aus Excel und schreibt sie Kommaseperat aus den ersten 2 spalten auf
        public List<string> GetCellValues(int x, int y)
        {
            List<string> cellvalues = new List<string>();
            while (ws.Cells[x,y].Value2 != null)
            {
                cellvalues.Add(MergeCellValues(x, y));
                x++;
            }
            return cellvalues;
        }

        //Fügt zwei zellenwerte zu einem (Komma seperat) zusammen 
        public string MergeCellValues(int x, int y)
        {
            var firstVal = ws.Cells[x, y].Value2;
            var secondVal = ws.Cells[x, y + 1].Value2;

            return firstVal + "," + secondVal;

        }

        //Schreibt Listwerte in Excel
        //!!!Funktioniert noch nicht
        public void WriteListToExcel(List<string> list)
        {
            int x = 1;
            int y = 1;

            while(ws.Cells[x,y].Value2 != null)
            {
                x++;
            }

            foreach (var value in list)
            {
                SetCellValues(x, y, value);
                x++;
            }
            Save(path);
            wb.Close();
        }

        public void WriteValueToExcel(string value)
        {
            int x = 1;
            int y = 1;

            while (ws.Cells[x, y].Value2 != null)
            {
                x++;
            }

            SetCellValues(x, y, value);
            Save(path);
            wb.Close();
        }


        public void SetCellValues(int x, int y, string value)
        {
            ws.Cells[x, y].Value2 = value;
        }

        
    }
}
