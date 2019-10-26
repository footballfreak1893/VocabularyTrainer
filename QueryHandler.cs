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
        public bool isFaillistDone = false;

        TextHandler textHandler = new TextHandler();
        VocabularyManager manager = new VocabularyManager();

        List<Vocabulary> voclist = new List<Vocabulary>();

        public QueryHandler()
        {
            
        }

        //Testen
        //Abfrage funktioniert nur von eng nach ger
        public bool CheckAnswer(int counter, string path, string userinput)
        {
            voclist = manager.LoadVocabularyList(path);
            var currentVoc = voclist[counter];

            if (currentVoc.nameGer.ToLower() == userinput.ToLower())
            {
                currentVoc.lastSuccess = DateTime.Now;
                currentVoc.isupdated = true;
                manager.UpdateVocabulary(currentVoc, voclist, path, counter);
                return true;
            }
            else
            {
                currentVoc.lastFailed = DateTime.Now;
                currentVoc.isupdated = true;
                manager.UpdateVocabulary(currentVoc, voclist, path, counter);
                return false;
            }
        }

        public string RetrieveItem(string path, int count)
        {
            voclist = manager.LoadVocabularyList(path);
            return voclist[count].nameEng;

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

        //public void RetriveList(string path)
        //{
        //    var result = this.CheckAnswer(this.counter, path, form.GetTextInput());

        //    if (result == true)
        //    {
        //        MessageBox.Show("correct answer, word mark as succeed");
        //    }
        //    else
        //    {
        //        MessageBox.Show("incorrect answer, word mark as failed" + Environment.NewLine + "the correct answer is: " + query.GetCorrectAnswer(query.counter, Data.pathAllWords));
        //    }

        //    query.counter += 1;

        //    var isDone = query.CheckIfQueryIsDone(query.counter, Data.pathAllWords);


        //    if (isDone == true)
        //    {
        //        query.counter = 0;
        //        MessageBox.Show("query of list is done");

        //        //Failure
        //        query.isFailureList = true;

        //        //btn_checkResult.Visible = false;
        //        textBox_inputText.Clear();
        //        textBox_result.Clear();
        //        //textBox_result.ReadOnly = false;

        //        //btn_startQuery.Visible = true;
        //        //btn_save.Visible = true;
        //        //btn_importExcel.Visible = true;

        //        manager.GenerateFaillist(Data.pathAllWords);
        //        MessageBox.Show("Faillist is filled");

        //        SetTextResult(query.RetrieveItem(Data.pathFailureWords, 0));
        //    }
        //    else
        //    {
        //        textBox_inputText.Clear();
        //        SetTextResult(query.RetrieveItem(Data.pathAllWords, query.counter));
        //    }
        //}
    }
}
