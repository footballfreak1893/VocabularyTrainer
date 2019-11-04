using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Linq;
using VocabularyApp.src.Forms;

namespace VocabularyApp
{
    public partial class MainForm : Form
    {
        QueryHandler query = new QueryHandler();
        VocabularyManager manager;
        TextHandler textHandler = new TextHandler();

        List<Vocabulary> mainList = new List<Vocabulary>();


        public MainForm()
        {
            InitializeComponent();
        }

        //Load Event
        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new VocabularyManager();
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
            GenerateTable();
        }



        //Button events
        private void Btn_save_Click(object sender, EventArgs e)
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

        private void Btn_test_Click(object sender, EventArgs e)
        {
            //GenerateTable();
            //manager.ClearList(Data.pathAllWords);
            //textHandler.PrintValuesToTextFile(Data.pathAllWords);
            //textHandler.PrintVoclist(Data.pathRandomWords);

            FillComboBox();

            //Hier weiter
            var vocList = manager.LoadVocabularyList(Data.pathAllWords);
            VocabularyDetailForm detailForm = new VocabularyDetailForm();
            detailForm.Show();


        }



        //Todo: Excel
        private void Btn_ImportExcel_Click(object sender, EventArgs e)
        {
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



        //Form Methods
        public void QueryMainList(string path, QueryHandler query, bool isFaillist)
        {
            SetTextResult(query.RetrieveItem(path, query.counter));
            var result = query.CheckAnswer(query.counter, path, textBox_inputText.Text);
            GenerateTable();
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

        public void GenerateTable()
        {
            var voclist = manager.LoadVocabularyList(Data.pathAllWords);
            dataGrid_allVocs.DataSource = voclist;

            DataTable table = new DataTable("allVocs");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("German", typeof(string));
            table.Columns.Add("English", typeof(string));
            table.Columns.Add("Last failed", typeof(DateTime));
            table.Columns.Add("Last success", typeof(DateTime));

            foreach (var item in voclist)
            {
                table.Rows.Add(item.id, item.nameGer, item.nameEng, item.lastFailed, item.lastSuccess);
            }
            dataGrid_allVocs.DataSource = table;
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

        public void FillComboBox()
        {
            var vocList = manager.LoadVocabularyList(Data.pathAllWords);

            foreach (var item in vocList)
            {
                comboBox1.Items.Add(item.id);
            }
        }

        public void GetComboItem()
        {
            var itemString = comboBox1.SelectedItem.ToString();
            //Convert to int

            int comboId = Convert.ToInt32(itemString);
            var vocList = manager.LoadVocabularyList(Data.pathAllWords);

            //LinQ elemente müssen immer in eine Liste Konvertriert werden
            var vocElement = vocList.Where(x => x.id == comboId).ToList();
            var voc = vocElement[0];


            MessageBox.Show(voc.nameGer);

            //Siehe Update
            //Update Methode ausbauen 
            //z.B Alle Attribute in neuem Form anzeigen und upadten :) Kleine UI übung
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComboItem();
        }
    }
}
