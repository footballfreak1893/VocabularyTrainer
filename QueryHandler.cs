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
                manager.UpdateVocabulary(currentVoc, voclist, path);
                return true;
            }
            else
            {
                currentVoc.lastFailed = DateTime.Now;
                currentVoc.isupdated = true;
                manager.UpdateVocabulary(currentVoc, voclist, path);
                return false;
            }
        }

        public string RetrieveItem(string path, int count)
        {
            voclist = manager.LoadVocabularyList(path);
            return voclist[count].nameEng;

        }

        ////Funktioniert, kann eingebaut werden
        public List<Vocabulary> GetRandomItem(string path)
        {
            var vocList = manager.LoadVocabularyList(path);
            List<Vocabulary> randomList = new List<Vocabulary>();
            var random = new Random();
            Vocabulary voc = null;

            while(randomList.Count != vocList.Count ||  randomList.Contains(voc))
            {
                var index = random.Next(vocList.Count);
                voc = vocList[index];

                if (randomList.Contains(voc))
                {
                    continue;
                }

                randomList.Add(voc);

                if (randomList.Count == vocList.Count)
                {
                    break;
                }
            }
            return randomList;
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
