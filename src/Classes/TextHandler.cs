using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace VocabularyApp
{
    public class TextHandler
    {
        VocabularyManager manager = new VocabularyManager();

        public string BuildVocString(Vocabulary vocabulary)
        {
            string mergedString = vocabulary.id + ", " + vocabulary.nameGer + ", " + vocabulary.nameEng + ", " + vocabulary.lastFailed + ", " + vocabulary.lastSuccess;
                      
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

        //Todo: Einbauen
        public void PrintValuesToTextFile(string path)
        {
            if (File.Exists(Data.pathAllWordsTextFile))
            {
                File.Delete(Data.pathAllWordsTextFile);
            }

            var vocList = manager.LoadVocabularyList(path);

          
            StreamWriter writer = new StreamWriter(Data.pathAllWordsTextFile);
            foreach (var item in vocList)
            {
                writer.WriteLine(BuildVocString(item));
            }

            writer.Close();
        }

        public void PrintVoclist(string path)
        {
            var vocList = manager.LoadVocabularyList(path);
            MessageBox.Show("Number of Items:" + vocList.Count.ToString());
            string printString = "";

            foreach (var item in vocList)
            {
                MessageBox.Show(printString = printString + item.nameGer + item.lastFailed + Environment.NewLine);
            }
        }

        public void PrintVoclist(List<Vocabulary> vocList)
        {
            MessageBox.Show("Number of Items:" + vocList.Count.ToString());
            string printString = "";

            foreach (var item in vocList)
            {
                MessageBox.Show(printString = printString + item.nameGer + item.lastFailed + Environment.NewLine);
            }
        }

        //--> Veraltet


        //Offen
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
