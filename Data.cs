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
        public static string pathMainFolder = @"Data";
        public static string pathAllWords = @"Data/AllWordsList.txt";
        public static string pathOutputExcel = @"Data/ExcelList.xlsx";
        public static string pathFailureWords = @"Data/FailureWordsList.txt";
        public static string pathSuccessWords = @"Data/SuccessWordsList.txt";

        public static void CreateOrLoadMainData()
        {
            if (!Directory.Exists(pathMainFolder))
            {
                Directory.CreateDirectory(pathMainFolder);

                if (!File.Exists(pathAllWords))
                {
                    File.WriteAllText(Data.pathAllWords, "beispiel, sample");
                }

                if (!File.Exists(pathFailureWords))
                {
                    File.WriteAllText(Data.pathFailureWords, "beispielFail, sampleFail");
                }

                if (!File.Exists(pathSuccessWords))
                {
                    File.WriteAllText(Data.pathSuccessWords, "beispielSuccess, sampleSuccess");
                }
            }
        }
    }
}
