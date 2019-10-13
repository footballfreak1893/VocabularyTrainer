using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        TextHandler textHandler = new TextHandler();
        public bool checkResultIsClicked = false;

       QueryHandler query = new QueryHandler();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Btn_translate_Click(object sender, EventArgs e)
        {
            var inputtext = textBox_inputText.Text;
            var translatedText = textHandler.TranslateText(inputtext, textBox_result.Text);
            var languagestring = textHandler.BuildLanguageString(inputtext, translatedText);

            //Text wird in Liste geschrieben
            textHandler.SaveSingleValueToTextFile(languagestring);
            MessageBox.Show("Vocabulary " + inputtext + " Saved");
            textBox_inputText.Clear();
            textBox_result.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.CreateOrLoadMainData();
        }

        //Importiert Excel Values in vokabelliste
        private void Btn_ImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C://";
            openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            string filepath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
            }

            Excel excel = new Excel(filepath, 1);
            var excelvalues = excel.GetCellValues(1, 1);
            textHandler.SaveExcelValuesToTextFile(excelvalues);
            excel.Close();
            MessageBox.Show("Values from: " + filepath + " are successfully imported!");
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
             var result = query.CheckAnswer(query.counter, Data.pathAllWords, textBox_inputText.Text);

            if (result == true)
            {
                MessageBox.Show("correct answer, word added to success-list");
            }
            else
            {
                MessageBox.Show("incorrect answer, word added to failure-list"+Environment.NewLine+ "the correct answer is: " + query.GetCorrectAnswer(query.counter, Data.pathAllWords));
            }

              query.counter += 1;

            var isDone = query.CheckIfQueryIsDone(query.counter, Data.pathAllWords);

            if (isDone == true)
            {
                query.counter = 0;
                MessageBox.Show("query of list is done");

                btn_checkResult.Visible = false;
                textBox_inputText.Clear();
                textBox_result.Clear();
                textBox_result.ReadOnly = false;
            }
            else
            {
                textBox_inputText.Clear();
                SetTextResult(query.RetrieveItem(Data.pathAllWords, query.counter));
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
