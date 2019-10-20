using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VocabularyApp
{
    public static class Data
    {
        //paths for text/excel files
        public static string pathMainFolder = @"Data";
        //public static string pathAllWordsTextFile = @"Data/AllWordsList.txt";
        public static string pathOutputExcel = @"Data/ExcelList.xlsx";
        //public static string pathFailureWordsTextFile = @"Data/FailureWordsList.txt";
        //public static string pathSuccessWordsTextFile = @"Data/SuccessWordsList.txt";
        public static string pathAllWords = @"Data/AllWordsList";
        public static string pathAllWordsID = @"Data/AllWordsIDList";
        public static string pathFailureWords = @"Data/FailureWordsList";
        public static string pathSuccessWords = @"Data/SuccessWordsList";


        //Old Text
        public static string pathFailureWordsTextFile = @"Data/FailureWordsList.txt";
        public static string pathSuccessWordsTextFile = @"Data/SuccessWordsList.txt";
        public static string pathAllWordsTextFile = @"Data/AllWordsList.txt";





        public static void CreateOrLoadMainData()
        {
            if (!Directory.Exists(pathMainFolder))
            {

                Directory.CreateDirectory(pathMainFolder);
            }


            
            if (!File.Exists(pathAllWords))
            {
                File.Create(pathAllWords);
            }


            if (!File.Exists(pathFailureWords))
            {
                File.Create(pathFailureWords);

            }

            if (!File.Exists(pathSuccessWords))
            {
                File.Create(pathSuccessWords);
            }

            //if (!File.Exists(pathAllWordsID))
            //{
            //    File.Create(pathAllWordsID);
            //}

        }


    }
}
