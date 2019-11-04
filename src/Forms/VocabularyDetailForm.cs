using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabularyApp.src.Forms
{
    public partial class VocabularyDetailForm : Form
    {
        VocabularyManager manager = new VocabularyManager();
        int counter = 0;
       
        public VocabularyDetailForm()
        {
            InitializeComponent();
            this.counter = 0;
            SetComponents(counter);
            
        }

        public void SetComponents(int counter)
        {
            if (!CheckIfItemsCompleted())
            {

                var list = manager.LoadVocabularyList(Data.pathAllWords);

                tb_Id.Text = list[counter].id.ToString();
                tb_eng.Text = list[counter].nameEng;
                tb_ger.Text = list[counter].nameGer;
                tb_counter.Text = counter.ToString();
                this.counter++;
            }
        }

        private void Btn_nextItem_Click(object sender, EventArgs e)
        {
            SetComponents(counter);
        }

        public bool CheckIfItemsCompleted()
        {
            var list = manager.LoadVocabularyList(Data.pathAllWords);
            if (counter >= list.Count )
            {
                btn_nextItem.Visible = false;
                MessageBox.Show("Items done");
                return true;
            }

            return false;
        }

        //Back function 
        //Clear function
        //Update function
    }
}
