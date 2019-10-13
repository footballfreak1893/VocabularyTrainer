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

        public List<string> StartQuery(string path)
        {
            this.counter = 0;

            return GetItems(path, true);
            
        }

        public List<string> GetItems(string path, bool isTranslated)
        {
            var fullList = textHandler.ReadList(path);
            List<string> itemList = new List<string>();
            
            foreach (var item in fullList)
            {
                var itemArray = item.Split(',');

                if (isTranslated == true )
                {
                    itemList.Add(itemArray[1]);
                }

                else
                {
                    itemList.Add(itemArray[0]);
                }
            }

            return itemList;
        }

        public string RetrieveItem(string path, int count)
        {
            var translatedList = GetItems(path, true);

            var item = translatedList[count];

            return item;
        }

        public bool CheckAnswer(int counter, string path, string user)
        {
            var answerlist = GetItems(path, false);

            if (answerlist[counter].ToLower() == user.ToLower())
            {
                List<string> SuccessList = new List<string>();

                SuccessList.Add(answerlist[counter]);
                textHandler.SaveList(Data.pathSuccessWords, SuccessList);

                return true;
            }
            else
            {
                var fullList = textHandler.ReadList(Data.pathAllWords);
                var failList = textHandler.ReadList(Data.pathFailureWords);
                failList.Add(fullList[counter]);
                textHandler.SaveList(Data.pathFailureWords, failList);

                return false;
            }
        }

        public string GetCorrectAnswer(int counter, string path)
        {
            var answerList = GetItems(Data.pathAllWords, false);

            return answerList[counter];
        }

        public bool CheckIfQueryIsDone(int counter, string path)
        {
            var queryList = GetItems(path, true);
            
            if( counter >= queryList.Count)
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
