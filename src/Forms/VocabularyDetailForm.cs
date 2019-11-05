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
            SetComponents();

            btn_preItem.Visible = false;
            
        }

        public void SetComponents()
        {
            

            if (!CheckIfItemsCompleted())
            {

                var list = manager.LoadVocabularyList(Data.pathAllWords);

                
                tb_Id.Text = list[this.counter].id.ToString();
                tb_eng.Text = list[this.counter].nameEng;
                tb_ger.Text = list[this.counter].nameGer;
                tb_counter.Text = this.counter.ToString();
                
            }
        }

        private void Btn_nextItem_Click(object sender, EventArgs e)
        {
            this.counter++;
            SetComponents();
            if (this.counter >0)
            {
                btn_preItem.Visible = true;
            }
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

        private void Btn_preItem_Click(object sender, EventArgs e)
        {
            this.counter--;
            SetComponents();

            if (this.counter == 0)
            {
                btn_preItem.Visible = false;
            }
        }

       

        //Back function 
        //Clear function
        //Update function
    }
}
