using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        QueryHandler query = new QueryHandler();
        VocabularyManager manager = new VocabularyManager();
        TextHandler textHandler = new TextHandler();

        List<Vocabulary> mainList = new List<Vocabulary>();


        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn_translate_Click(object sender, EventArgs e)
        {
            var allWords = manager.LoadVocabularyList(Data.pathAllWords);
            var nameGer = textBox_inputText.Text;
            var nameEng = textBox_result.Text;

            //Objekte
            manager.CreateVocabulary(nameGer, nameEng, allWords, Data.pathAllWords);
            MessageBox.Show("Vocabulary " + textBox_inputText.Text + " Saved");
            textBox_inputText.Clear();
            textBox_result.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Data.pathMainFolder))
            {
                Directory.CreateDirectory(Data.pathMainFolder);

                if (!File.Exists(Data.pathAllWords))
                {
                    mainList.Add(new Vocabulary(001, "standard", "default", DateTime.Now));
                    manager.SaveVocabularyList(Data.pathAllWords, mainList);
                }

            }
            mainList = manager.LoadVocabularyList(Data.pathAllWords);
        }

        //Importiert Excel Values in vokabelliste
        private void Btn_ImportExcel_Click(object sender, EventArgs e)
        {
            textHandler.PrintValuesToTextFile(Data.pathAllWords);
            manager.PrintVoclist(Data.pathAllWords);

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "C://";
            //openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //string filepath = null;
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    filepath = openFileDialog.FileName;
            //}

            //Excel excel = new Excel(filepath, 1);
            //excel.CreateVoc(1, 1);
            //excel.Close();
            //MessageBox.Show("Values from: " + filepath + " are successfully imported!");
        }


        //Dient zur Abfrage, Auslagerung offen
        private void Btn_startQuery_Click(object sender, EventArgs e)
        {
            textBox_result.ReadOnly = true;
            query.counter = 0;
            query.RetrieveItem(Data.pathAllWords, 0);

            btn_checkResult.Visible = true;
            btn_startQuery.Visible = false;
            btn_save.Visible = false;
            btn_importExcel.Visible = false;

            MessageBox.Show("Query of List start");
            SetTextResult(query.RetrieveItem(Data.pathAllWords, 0));
        }

        private void Btn_checkResult_Click(object sender, EventArgs e)
        {
            if (!query.isFailureList)
            {
                QueryMainList(Data.pathAllWords, query, query.isFailureList);
            }

            else
            {
                QueryMainList(Data.pathFailureWords, query, query.isFailureList);
            }

        }

        public void QueryMainList(string path, QueryHandler query, bool isFaillist)
        {
            SetTextResult(query.RetrieveItem(path, query.counter));
            var result = query.CheckAnswer(query.counter, path, textBox_inputText.Text);

            if (result == true)
            {
                MessageBox.Show("correct answer, word mark as succeed");
            }
            else
            {
                MessageBox.Show("incorrect answer, word mark as failed" + Environment.NewLine + "the correct answer is: " + query.GetCorrectAnswer(query.counter, path));
            }

            query.counter += 1;

            if (query.CheckIfQueryIsDone(query.counter, path))
            {
                query.counter = 0;
                MessageBox.Show("query of list is done");

                textBox_inputText.Clear();
                textBox_result.Clear();

                if (isFaillist)
                {
                    MessageBox.Show("query of  fail list is done");

                    btn_checkResult.Visible = false;
                    textBox_result.ReadOnly = false;
                    btn_startQuery.Visible = true;
                    btn_save.Visible = true;
                    btn_importExcel.Visible = true;

                    query.isFailureList = false;
                    manager.DeleteFaillist();
                }

                else
                {

                    var faillist = manager.GenerateFaillist(Data.pathAllWords);
                    if (faillist.Count == 0)
                    {
                        btn_checkResult.Visible = false;
                        textBox_result.ReadOnly = false;
                        btn_startQuery.Visible = true;
                        btn_save.Visible = true;
                        btn_importExcel.Visible = true;

                        query.isFailureList = false;
                        manager.DeleteFaillist();

                        return;
                    }


                    SetTextResult(query.RetrieveItem(Data.pathFailureWords, 0));

                    query.isFailureList = true;
                }

            }
            else
            {
                textBox_inputText.Clear();
                SetTextResult(query.RetrieveItem(path, query.counter));
            }
        }

        public void SetTextResult(string value)
        {
            textBox_result.Text = value;
        }

        public void SetTextInput(string value)
        {
            textBox_inputText.Text = value;
        }

        public string GetTextResult()
        {
            return textBox_result.Text;
        }

        public string GetTextInput()
        {
            return textBox_inputText.Text;
        }

    }
}
