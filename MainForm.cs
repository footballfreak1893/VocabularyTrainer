using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        TextHandler textHandler = new TextHandler();
        public bool checkResultIsClicked = false;
        int counterQuery = 0;
        bool isFailureList = false;

       
       
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
            //hide buttons for insert new vocabulary
            btn_importExcel.Visible = false;
            btn_translate.Visible = false;

            btn_checkResult.Visible = true;
            counterQuery = AskItem(counterQuery, Data.pathAllWords);
            btn_startQuery.Visible = false;
        }

        private void Btn_checkResult_Click(object sender, EventArgs e)
        {//Hier weiter
            
                var querylist = textHandler.GetQueryList(Data.pathAllWords, 1);
                counterQuery = GetAnswer(querylist, counterQuery, Data.pathAllWords);
                counterQuery++;
                CheckIfQueryIsDone(querylist, counterQuery, Data.pathAllWords);
            
        }

        //Korrekt
        public int AskItem(int counterQuery, string path)
        {
            
            var querylist = textHandler.GetQueryList(path, 1);
            string item = querylist[counterQuery];
            textBox_result.Text = item;
            return counterQuery;
        }

        public int GetAnswer(List<string> querylist, int counterQuery, string path)
        {
            List<string> failueItems = new List<string>();
            List<string> successItems = new List<string>();

            var userresponse = textBox_inputText.Text;
            var result = textHandler.CheckQuery(userresponse, counterQuery, path);

            if (result == false)
            {
                MessageBox.Show("incorrect answer, word added to failure-list");
                failueItems.Add(querylist[counterQuery]);
            }
            else
            {
                MessageBox.Show("correct answer, word added to success-list");
                successItems.Add(querylist[counterQuery]);
            }
            textHandler.SaveList(Data.pathFailureWords, failueItems);
            textHandler.SaveList(Data.pathSuccessWords, successItems);

            textBox_inputText.Clear();
            textBox_result.Clear();

            return counterQuery;

        }

        public void CheckIfQueryIsDone(List<String> querylist, int counterQuery, string path)
        {
            counterQuery = counterQuery++;

            if (counterQuery >= querylist.Count)
            {
                MessageBox.Show("query is done !!!");
                 counterQuery = 0;
                btn_checkResult.Visible = false;
                btn_startQuery.Visible = true;
                MessageBox.Show(counterQuery.ToString());
                //Hier kommt Faillist ins spiel
                //Evtl. eigene Methode
                

               

                //show buttons for insert new vocabulary
                btn_importExcel.Visible = true;
                btn_translate.Visible = true;
            }
            else
            {

                counterQuery = AskItem(counterQuery, path);
            }
        }

        

        
    }
}
