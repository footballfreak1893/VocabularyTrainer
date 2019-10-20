using System.Collections.Generic;
using System.IO;
using System.Linq;


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

            var mergedString = originalString + "," + translatedString;
            return mergedString;
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

        //Schreibt von Programm in Gesamtliste
        public void SaveSingleValueToTextFile(string mergedString)
        {
            if (!File.Exists(Data.pathAllWordsTextFile))
            {
                File.WriteAllText(Data.pathAllWordsTextFile, "beispiel, sample");
            }

            var existingValues = ReadList(Data.pathAllWordsTextFile);
            var isDublicate = IsADublicate(mergedString, existingValues);

            if (isDublicate == false)
            {
                existingValues.Add(mergedString);
            }

            SaveList(Data.pathAllWordsTextFile, existingValues);
        }

        //Schreibt von Excel in Gesamtliste
        public void SaveExcelValuesToTextFile(List<string> excelvalues)
        {
            if (!File.Exists(Data.pathAllWordsTextFile))
            {
                File.WriteAllText(Data.pathAllWordsTextFile, "beispiel, sample");

            }

            var existingValues = ReadList(Data.pathAllWordsTextFile);

            foreach (var excelvalue in excelvalues)
            {
                var isDublicate = IsADublicate(excelvalue, existingValues);

                if (isDublicate == false)
                {
                    existingValues.Add(excelvalue);
                }
            }

            SaveList(Data.pathAllWordsTextFile, existingValues);
        }

        public bool IsADublicate(string value, List<string> existingvalues)
        {
            if (existingvalues.Contains(value))
            {
                return true;
            }

            return false;
        }

        public List<string> ReadList(string path)
        {
            var listarray = File.ReadAllLines(path);
            var list = listarray.ToList();
            return list;

        }

        public void SaveList(string path, List<string> list)
        {

            File.WriteAllLines(path, list);
        }

    }





































    
}
