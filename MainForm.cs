using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        
        public bool checkResultIsClicked = false;

       QueryHandler query = new QueryHandler();
       VocabularyManager manager = new VocabularyManager();
        TextHandler textHandler = new TextHandler();

        List<Vocabulary> mainList = new List<Vocabulary>();
        List<Vocabulary> failList = new List<Vocabulary>();


        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn_translate_Click(object sender, EventArgs e)
        {
            var allWords = manager.LoadVocabularyList(Data.pathAllWords);
            var nameGer = textBox_inputText.Text;
            var nameEng = textBox_result.Text;

            //var translatedText = textHandler.TranslateText(nameGer, textBox_result.Text);
            //var languagestring = textHandler.BuildLanguageString(nameGer, translatedText);
            ////Text wird in Liste geschrieben
            //textHandler.SaveSingleValueToTextFile(languagestring);
            //MessageBox.Show("Vocabulary " + nameGer + " Saved");
            //textBox_inputText.Clear();
            //textBox_result.Clear();

            //Objekte
            manager.CreateVocabulary(nameGer, nameEng, allWords, Data.pathAllWords);
            MessageBox.Show("Vocabulary " + textBox_inputText.Text + " Saved");

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

            //if (!File.Exists(Data.pathFailureWords))
            //{
            //    mainList.Add(new Vocabulary(001, "standardFail", "defaultFail", DateTime.Now));
            //    manager.SaveVocabularyList(Data.pathFailureWords, failList);
            //}
        }

        //Importiert Excel Values in vokabelliste
        private void Btn_ImportExcel_Click(object sender, EventArgs e)
        {
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
            //var excelvalues = excel.GetCellValues(1, 1);
            //textHandler.SaveExcelValuesToTextFile(excelvalues);
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
                var result = query.CheckAnswer(query.counter, Data.pathAllWords, textBox_inputText.Text);

                if (result == true)
                {
                    MessageBox.Show("correct answer, word mark as succeed");
                }
                else
                {
                    MessageBox.Show("incorrect answer, word mark as failed" + Environment.NewLine + "the correct answer is: " + query.GetCorrectAnswer(query.counter, Data.pathAllWords));
                }

                query.counter += 1;

                var isDone = query.CheckIfQueryIsDone(query.counter, Data.pathAllWords);


                if (isDone == true)
                {
                    query.counter = 0;
                    MessageBox.Show("query of list is done");

                    //Failure
                    query.isFailureList = true;

                    //btn_checkResult.Visible = false;
                    textBox_inputText.Clear();
                    textBox_result.Clear();
                    //textBox_result.ReadOnly = false;

                    //btn_startQuery.Visible = true;
                    //btn_save.Visible = true;
                    //btn_importExcel.Visible = true;

                    manager.GenerateFaillist(Data.pathAllWords);
                    MessageBox.Show("Faillist is filled");

                    SetTextResult(query.RetrieveItem(Data.pathFailureWords, 0));
                }
                else
                {
                    textBox_inputText.Clear();
                    SetTextResult(query.RetrieveItem(Data.pathAllWords, query.counter));
                }

            }

            else if (query.isFailureList && !query.isFaillistDone)
            {
             

                var result = query.CheckAnswer(query.counter, Data.pathFailureWords, textBox_inputText.Text);

                if (result == true)
                {
                    MessageBox.Show("correct answer, word mark as succeed");
                }
                else
                {
                    MessageBox.Show("incorrect answer!" + Environment.NewLine + "the correct answer is: " + query.GetCorrectAnswer(query.counter, Data.pathFailureWords));
                }

                query.counter += 1;

                var isDone = query.CheckIfQueryIsDone(query.counter, Data.pathFailureWords);

                if (isDone)
                {
                    query.counter = 0;
                    query.isFailureList = false;
                    query.isFaillistDone = true;

                    MessageBox.Show("query of faillure items is done");
                    btn_checkResult.Visible = false;
                    textBox_inputText.Clear();
                    textBox_result.Clear();
                    textBox_result.ReadOnly = false;

                    btn_startQuery.Visible = true;
                    btn_save.Visible = true;
                    btn_importExcel.Visible = true;
                }
                else
                {
                    textBox_inputText.Clear();
                    SetTextResult(query.RetrieveItem(Data.pathFailureWords, query.counter));
                }

            }

            //else
            //{
            //    btn_checkResult.Visible = false;
            //    textBox_inputText.Clear();
            //    textBox_result.Clear();
            //    textBox_result.ReadOnly = false;

            //    btn_startQuery.Visible = true;
            //    btn_save.Visible = true;
            //    btn_importExcel.Visible = true;
            //}
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
