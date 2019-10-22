using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace VocabularyApp
{
   public class VocabularyManager
    {
        ID genID = new ID();

        public void CreateVocabulary(string nameGer, string nameEng, List<Vocabulary> vocabularyList, string path)
        {
            
            Vocabulary vocabulary = new Vocabulary(genID.GenerateID(genID), nameGer, nameEng, DateTime.Now);

           var isDublicate = IsADublicate(vocabulary, vocabularyList);

            if (!isDublicate)
            {
                SaveVocabulary(vocabulary, vocabularyList, path);
            }
            else
            {
                MessageBox.Show("Error: Voc " + vocabulary.nameGer + " already exists!");
            }
        }

        public void SaveVocabulary(Vocabulary vocabulary, List<Vocabulary> vocbabularyList, string path)
        {
            if(!IsADublicate(vocabulary, vocbabularyList))
            {
                vocbabularyList.Add(vocabulary);
            }
            SaveVocabularyList(path, vocbabularyList);
        }

        //Offen
        public void UpdateVocabulary(Vocabulary vocabularyUpdate, List<Vocabulary> vocabularyList, string path, int counter)
        {
                //if(vocabularyPre.id  == vocabularyUpdate.id)
                //{
                    
                vocabularyList.RemoveAt(counter);
                vocabularyList.Insert(counter, vocabularyUpdate);
                SaveVocabularyList(path, vocabularyList);
                //}
            
        }

        //Offen
        public void DeleteVocabulary(Vocabulary vocabulary, List<Vocabulary> vocbabularyList, string path)
        {
            vocbabularyList.Remove(vocabulary);
            SaveVocabularyList(path, vocbabularyList);
        }

        //Save / Read ObjectLists

        public void SaveVocabularyList(string path, List<Vocabulary> vocbabularyList)
        {
            FileStream fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            IFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, vocbabularyList);

            fs.Close();
        }

        public List<Vocabulary> LoadVocabularyList(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            IFormatter bf = new BinaryFormatter();
            var vocabularyList = (List<Vocabulary>)bf.Deserialize(fs);
            fs.Close();

            return vocabularyList;
        }

        //Weitere Überprüfungen einbauen
        public bool IsADublicate( Vocabulary vocabularyInput, List<Vocabulary> vocabularyList)
        {
            foreach (var voc in vocabularyList)
            {
                if (voc.nameEng == vocabularyInput.nameEng || voc.nameGer == vocabularyInput.nameGer)
                {
                    return true;
                }

            }
            return false;
        }

        public void PrintVoclist(string path)
        {
            var vocList = LoadVocabularyList(path);
            MessageBox.Show("Number of Items:" +vocList.Count.ToString());
            string printString = "";

            foreach (var item in vocList)
            {
               MessageBox.Show(printString = printString + item.nameGer +item.lastFailed+ Environment.NewLine);
            }
        }

        public DateTime FormatTimeStamp(DateTime time)
        {
           return time = new DateTime(time.Year, time.Month, time.Day);
        }




    }
}
