using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VocabularyApp
{
    [Serializable]
    public class Vocabulary
    {
        public int id;
        public string nameGer;
        public string nameEng;
        //Todo: Weitere Sprachen
        public DateTime createDate;
        public DateTime lastFailed;
        public DateTime lastSuccess;
        public DateTime defaultTime = new DateTime(2000, 01, 01);
        public bool isupdated = false;


        public Vocabulary(int id, string nameGer, string nameEng, DateTime createdate)
        {
            this.nameGer = nameGer;
            this.nameEng = nameEng;
            this.createDate = createdate;
            this.id = id;
            this.lastFailed = defaultTime;
            this.lastSuccess = defaultTime;
        }

        public string GetName(bool eng)
        {
            if (!eng)
            {
                return this.nameGer;
            }
            else
            {
                return this.nameEng;
            }
        }

        public DateTime SetDefaultTime(DateTime time)
        {
            time = defaultTime;
            return time;
        }


    }

    [Serializable]
    public class ID
    {
        public ID()
        {
            GenerateID();
        }

        public int number;

        public void SaveIDList(string path, List<ID> idList)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            IFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, idList);

            fs.Close();
        }

        public List<ID> LoadIDList(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            IFormatter bf = new BinaryFormatter();
            var idList = (List<ID>)bf.Deserialize(fs);
            fs.Close();

            return idList;
        }

        public void GenerateID()
        {
            if (!File.Exists(Data.pathAllWordsID))
            {
                List<ID> idList = new List<ID>();
                this.number = 00001;
                idList.Add(this);
                SaveIDList(Data.pathAllWordsID, idList);
            }
            else
            {
                List<ID> idList = new List<ID>();
                idList = LoadIDList(Data.pathAllWordsID);

                var lastId = idList.Last();
                var lastIdNumber = lastId.number;

                this.number = lastIdNumber+1;

                idList.Add(this);
                SaveIDList(Data.pathAllWordsID, idList);
            }
        }

        public int GetId()
        {
            return this.number;
        }
    }


}
