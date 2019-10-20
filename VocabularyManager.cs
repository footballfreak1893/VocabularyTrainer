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

        public void CreateVocabulary(string nameGer, string nameEng, List<Vocabulary> vocbabularyList, string path)
        {
            Vocabulary vocabulary = new Vocabulary(genID.GenerateID(genID), nameGer, nameEng, DateTime.Now);
            SaveVocabulary(vocabulary, vocbabularyList, path);
        }

        public void SaveVocabulary(Vocabulary vocabulary, List<Vocabulary> vocbabularyList, string path)
        {
            vocbabularyList.Add(vocabulary);
            SaveVocabularyList(path, vocbabularyList);
        }

        //Offen
        public void UpdateVocabulary(Vocabulary vocabulary, List<Vocabulary> vocbabularyList, string path)
        {
            SaveVocabularyList(path, vocbabularyList);
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
                if (voc.nameEng == vocabularyInput.nameEng && voc.nameEng == vocabularyInput.nameEng)
                {
                    return true;
                }

            }
            return false;
        }




    }
}
