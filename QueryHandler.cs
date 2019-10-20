using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VocabularyApp
{
    public class QueryHandler
    {
        public int counter = 0;
        public bool isFailureList;

        TextHandler textHandler = new TextHandler();
        VocabularyManager manager = new VocabularyManager();

        List<Vocabulary> voclist = new List<Vocabulary>();

        //public List<string> StartQuery(string path)
        //{
        //    this.counter = 0;

        //    return GetItems(path, true);
            
        //}

        //public List<string> GetItems(string path, bool isTranslated)
        //{
        //    var fullList = textHandler.ReadList(path);
        //    List<string> itemList = new List<string>();
            
        //    foreach (var item in fullList)
        //    {
        //        var itemArray = item.Split(',');

        //        if (isTranslated == true )
        //        {
        //            itemList.Add(itemArray[1]);
        //        }

        //        else
        //        {
        //            itemList.Add(itemArray[0]);
        //        }
        //    }

        //    return itemList;
        //}

        //Aktuell kann nur eine Sprache abgefragt werden
        //public string RetrieveItem(string path, int count)
        //{
        //    voclist = manager.LoadVocabularyList(path);
        //    return voclist[counter].nameEng;

        //}

        //public bool CheckAnswer(int counter, string path, string user)
        //{
        //    var answerlist = GetItems(path, false);

        //    if (answerlist[counter].ToLower() == userinput.ToLower())
        //    {
        //        List<string> SuccessList = new List<string>();

        //        SuccessList.Add(answerlist[counter]);
        //        textHandler.SaveList(Data.pathSuccessWordsTextFile, SuccessList);

        //        return true;
        //    }
        //    else
        //    {
        //        var fullList = textHandler.ReadList(Data.pathAllWordsTextFile);
        //        var failList = textHandler.ReadList(Data.pathFailureWordsTextFile);
        //        failList.Add(fullList[counter]);
        //        textHandler.SaveList(Data.pathFailureWordsTextFile, failList);

        //        return false;
        //    }
        //}


        
       


        //New
        //Testen
        //Abfrage funktioniert nur von eng nach ger
        public bool CheckAnswer(int counter, string path, string userinput)
        {
            voclist = manager.LoadVocabularyList(path);
            var currentVoc = voclist[counter];

            if (currentVoc.nameGer.ToLower() == userinput.ToLower())
            {
                currentVoc.lastSuccess = DateTime.Now;
                manager.SaveVocabulary(currentVoc, voclist, Data.pathAllWords);
                return true;
            }
            else
            {
                currentVoc.lastFailed = DateTime.Now;
                manager.SaveVocabulary(currentVoc, voclist, Data.pathAllWords);
                return false;
            }
        }

        public string RetrieveItem(string path, int count)
        {
            voclist = manager.LoadVocabularyList(path);
            return voclist[counter].nameEng;

        }

        public string GetCorrectAnswer(int counter, string path)
        {
            voclist = manager.LoadVocabularyList(path);

            return voclist[counter].nameGer;
        }

        public bool CheckIfQueryIsDone(int counter, string path)
        {
            voclist = manager.LoadVocabularyList(path);

            if (counter >= voclist.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
