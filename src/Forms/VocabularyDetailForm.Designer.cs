namespace VocabularyApp.src.Forms
{
    partial class VocabularyDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Id = new System.Windows.Forms.Label();
            this.lbl_ger = new System.Windows.Forms.Label();
            this.lbl_eng = new System.Windows.Forms.Label();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.tb_ger = new System.Windows.Forms.TextBox();
            this.tb_eng = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_nextItem = new System.Windows.Forms.Button();
            this.tb_counter = new System.Windows.Forms.TextBox();
            this.lbl_counter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Id
            // 
            this.lbl_Id.AutoSize = true;
            this.lbl_Id.Location = new System.Drawing.Point(13, 30);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(21, 13);
            this.lbl_Id.TabIndex = 0;
            this.lbl_Id.Text = "ID:";
            // 
            // lbl_ger
            // 
            this.lbl_ger.AutoSize = true;
            this.lbl_ger.Location = new System.Drawing.Point(13, 85);
            this.lbl_ger.Name = "lbl_ger";
            this.lbl_ger.Size = new System.Drawing.Size(100, 13);
            this.lbl_ger.TabIndex = 1;
            this.lbl_ger.Text = "German Description";
            // 
            // lbl_eng
            // 
            this.lbl_eng.AutoSize = true;
            this.lbl_eng.Location = new System.Drawing.Point(9, 143);
            this.lbl_eng.Name = "lbl_eng";
            this.lbl_eng.Size = new System.Drawing.Size(97, 13);
            this.lbl_eng.TabIndex = 2;
            this.lbl_eng.Text = "English Description";
            // 
            // tb_Id
            // 
            this.tb_Id.Location = new System.Drawing.Point(15, 46);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.ReadOnly = true;
            this.tb_Id.Size = new System.Drawing.Size(100, 20);
            this.tb_Id.TabIndex = 3;
            // 
            // tb_ger
            // 
            this.tb_ger.Location = new System.Drawing.Point(12, 101);
            this.tb_ger.Name = "tb_ger";
            this.tb_ger.Size = new System.Drawing.Size(100, 20);
            this.tb_ger.TabIndex = 4;
            // 
            // tb_eng
            // 
            this.tb_eng.Location = new System.Drawing.Point(12, 159);
            this.tb_eng.Name = "tb_eng";
            this.tb_eng.Size = new System.Drawing.Size(100, 20);
            this.tb_eng.TabIndex = 5;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 236);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(12, 265);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Text = "Clear input";
            this.btn_clear.UseVisualStyleBackColor = true;
            // 
            // btn_nextItem
            // 
            this.btn_nextItem.Location = new System.Drawing.Point(205, 236);
            this.btn_nextItem.Name = "btn_nextItem";
            this.btn_nextItem.Size = new System.Drawing.Size(75, 23);
            this.btn_nextItem.TabIndex = 8;
            this.btn_nextItem.Text = "Next Item";
            this.btn_nextItem.UseVisualStyleBackColor = true;
            this.btn_nextItem.Click += new System.EventHandler(this.Btn_nextItem_Click);
            // 
            // tb_counter
            // 
            this.tb_counter.Location = new System.Drawing.Point(150, 148);
            this.tb_counter.Name = "tb_counter";
            this.tb_counter.Size = new System.Drawing.Size(100, 20);
            this.tb_counter.TabIndex = 10;
            // 
            // lbl_counter
            // 
            this.lbl_counter.AutoSize = true;
            this.lbl_counter.Location = new System.Drawing.Point(151, 132);
            this.lbl_counter.Name = "lbl_counter";
            this.lbl_counter.Size = new System.Drawing.Size(44, 13);
            this.lbl_counter.TabIndex = 9;
            this.lbl_counter.Text = "Counter";
            // 
            // VocabularyDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.tb_counter);
            this.Controls.Add(this.lbl_counter);
            this.Controls.Add(this.btn_nextItem);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_eng);
            this.Controls.Add(this.tb_ger);
            this.Controls.Add(this.tb_Id);
            this.Controls.Add(this.lbl_eng);
            this.Controls.Add(this.lbl_ger);
            this.Controls.Add(this.lbl_Id);
            this.Name = "VocabularyDetailForm";
            this.Text = "VocabularyDetailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Id;
        private System.Windows.Forms.Label lbl_ger;
        private System.Windows.Forms.Label lbl_eng;
        private System.Windows.Forms.TextBox tb_Id;
        private System.Windows.Forms.TextBox tb_ger;
        private System.Windows.Forms.TextBox tb_eng;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_nextItem;
        private System.Windows.Forms.TextBox tb_counter;
        private System.Windows.Forms.Label lbl_counter;
    }
}