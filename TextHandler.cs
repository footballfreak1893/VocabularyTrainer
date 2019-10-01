using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;



namespace VocabularyApp
{
    public class TextHandler
    {
        public string BuildLanguageString(string originalString, string translatedString)
        {
            if (translatedString == null || translatedString == "")
            {
                translatedString = originalString;
            }

            var mergedString = originalString + ","+ translatedString;
            return mergedString ;
        }

        //Todo: Übersetzung einbauen
        public string TranslateText(string originalText, string translatedText)
        {
            if (translatedText == null || translatedText == "")
            {
                translatedText = "no translation avaiable";
            }
            return translatedText;

        }

        //Schreibt von Programmin in Gesamtliste
        public void SaveSingleValueToTextFile (string mergedString)
        {
            if (!File.Exists(Data.pathAllWords))
            {
                File.WriteAllText(Data.pathAllWords, "beispiel, sample");
                
            }
            
            var existingValuesStr = File.ReadAllLines(Data.pathAllWords);
            var existingValues = existingValuesStr.ToList();
            var isDublicate = IsADublicate(mergedString, existingValues);

            if (isDublicate == false)
            {
                existingValues.Add(mergedString);
            }

            File.WriteAllLines(Data.pathAllWords, existingValues);
        }

        //Schreibt von Excel in Gesamtliste
        public void SaveExcelValuesToTextFile(List<string> excelvalues)
        {
            if (!File.Exists(Data.pathAllWords))
            {
                File.WriteAllText(Data.pathAllWords, "beispiel, sample");

            }

            var existingValuesStr = File.ReadAllLines(Data.pathAllWords);
            var existingValues = existingValuesStr.ToList();

            foreach (var excelvalue in excelvalues)
            {
                var isDublicate = IsADublicate(excelvalue, existingValues);

                if (isDublicate == false)
                {
                    existingValues.Add(excelvalue);
                }
            }
            
            File.WriteAllLines(Data.pathAllWords, existingValues);
        }

        public bool IsADublicate(string value, List<string> existingvalues)
        {
            if (existingvalues.Contains(value))
            {
                return true;
            }

            return false;
        }


        //Abfragen


        public bool CheckQuery (string queryitem, string userinput)
        {
            //Todo: Übersetzung muss neugemacht werden
           
            if (queryitem == userinput)
            {
                userinput = null;
                return true; 
            }
            else
            {
                return false;
            }
        }

        public List<string> ReadList(string path)
        {
            var listarray = File.ReadAllLines(Data.pathAllWords);
            var list = listarray.ToList();
            return list;

        }

        public void SaveList(string path, List<string> list)
        {

            File.WriteAllLines(path, list);
        }

        //Gibt zu abfragende items zurück
        public List<string> GetQueryList(string path)
        {
             var mergedlist = ReadList(path);
            List<string> querylist = new List<string>();

            foreach (var item in mergedlist)
            {
                var splitedvalues = item.Split(',');
                var queryvalue = splitedvalues[1];
                querylist.Add(queryvalue);
            }
            
            return querylist;
        }

        //Aus form class


       





























        //    StreamWriter file = new StreamWriter(pathCSV);
        //    file.WriteLine(stringbuilder.ToString());
        //    file.Close();
        //}


    }
}
