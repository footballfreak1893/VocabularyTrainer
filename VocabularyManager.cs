using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsADublicate(vocabulary, vocbabularyList))
            {
                vocbabularyList.Add(vocabulary);
            }
            SaveVocabularyList(path, vocbabularyList);
        }

        
       

        public void UpdateVocabulary(Vocabulary vocabularyUpdate, List<Vocabulary> vocabularyList, string path)
        {
            var voc = vocabularyList.FirstOrDefault(v => v.id == vocabularyUpdate.id);
            if (voc != null)
            {
                voc = vocabularyUpdate;
            }
            SaveVocabularyList(path, vocabularyList);
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
        //Zahlen nicht zulassen
        public bool IsADublicate(Vocabulary vocabularyInput, List<Vocabulary> vocabularyList)
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

     

        public List<Vocabulary> GenerateFaillist(string path)
        {
            var vocList = LoadVocabularyList(path);
            List<Vocabulary> failList = new List<Vocabulary>();

            var now = DateTime.Now;

            foreach (var item in vocList)
            {
                var timeDifference = (now - item.lastFailed).TotalMinutes;

                if (timeDifference <= 5)
                {
                    failList.Add(item);
                }
            }
            SaveVocabularyList(Data.pathFailureWords, failList);
            return failList;
        }

        public void DeleteFaillist()
        {
            File.Delete(Data.pathFailureWords);
        }

        public void SetDefaultDates(string path, int counter)
        {
            var voclist = LoadVocabularyList(path);
            var currentVoc = voclist[counter];
            currentVoc.lastFailed = currentVoc.defaultTime;
            UpdateVocabulary(currentVoc, voclist, path);

        }



        //Nützliche funktionen 
        
        public void ClearList(string path)
        {
            var vocList = LoadVocabularyList(path);
            vocList.Clear();
            vocList.Add(new Vocabulary(0001, "standard", "default", DateTime.Now));

            SaveVocabularyList(path, vocList);
        }

        //Funktioniert, kann eingebaut werden
        public Vocabulary SearchingVocs(string path, int id)
        {
            var vocList = LoadVocabularyList(path);

            var voc = vocList.Where(x => x.id == id);

            var currentVoc = voc.ToList();

            if (currentVoc.Count == 1)
            {
                return currentVoc[0];
            }

            else
            {
                MessageBox.Show("Voc not found");
                return null;
            }


        }
    }
}
