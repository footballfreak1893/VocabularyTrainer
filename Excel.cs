using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;



namespace VocabularyApp
{
    class Excel
    {
        VocabularyManager manager = new VocabularyManager();

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
        public void CreateVoc(int x, int y)
        {
            var vocList = manager.LoadVocabularyList(Data.pathAllWords);

            while (ws.Cells[x,y].Value2 != null)
            {
                var nameGer = ws.Cells[x, y].Value2;
                var nameEng = ws.Cells[x, y + 1].Value2;

                manager.CreateVocabulary(nameGer, nameEng, vocList, Data.pathAllWords);
                x++;
            }
        }

        //Fügt zwei zellenwerte zu einem (Komma seperat) zusammen 
        //public string MergeCellValues(int x, int y)
        //{
        //    var nameGer = ws.Cells[x, y].Value2;
        //    var nameEng = ws.Cells[x, y + 1].Value2;

        //    return nameGer + "," + nameEng;

        //}

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
