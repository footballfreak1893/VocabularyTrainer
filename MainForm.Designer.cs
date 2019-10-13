namespace VocabularyApp
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_inputText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.btn_importExcel = new System.Windows.Forms.Button();
            this.lbl_originalText = new System.Windows.Forms.Label();
            this.lbl_TranslatedText = new System.Windows.Forms.Label();
            this.btn_startQuery = new System.Windows.Forms.Button();
            this.btn_checkResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vocabulary Quick Save";
            // 
            // textBox_inputText
            // 
            this.textBox_inputText.Location = new System.Drawing.Point(28, 95);
            this.textBox_inputText.Name = "textBox_inputText";
            this.textBox_inputText.Size = new System.Drawing.Size(116, 20);
            this.textBox_inputText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vocabulary Quick Save";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(28, 121);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_translate_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(182, 95);
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(116, 20);
            this.textBox_result.TabIndex = 3;
            // 
            // btn_importExcel
            // 
            this.btn_importExcel.Location = new System.Drawing.Point(28, 150);
            this.btn_importExcel.Name = "btn_importExcel";
            this.btn_importExcel.Size = new System.Drawing.Size(102, 23);
            this.btn_importExcel.TabIndex = 5;
            this.btn_importExcel.Text = "Import Excel List";
            this.btn_importExcel.UseVisualStyleBackColor = true;
            this.btn_importExcel.Click += new System.EventHandler(this.Btn_ImportExcel_Click);
            // 
            // lbl_originalText
            // 
            this.lbl_originalText.AutoSize = true;
            this.lbl_originalText.Location = new System.Drawing.Point(25, 79);
            this.lbl_originalText.Name = "lbl_originalText";
            this.lbl_originalText.Size = new System.Drawing.Size(66, 13);
            this.lbl_originalText.TabIndex = 6;
            this.lbl_originalText.Text = "Original Text";
            // 
            // lbl_TranslatedText
            // 
            this.lbl_TranslatedText.AutoSize = true;
            this.lbl_TranslatedText.Location = new System.Drawing.Point(179, 79);
            this.lbl_TranslatedText.Name = "lbl_TranslatedText";
            this.lbl_TranslatedText.Size = new System.Drawing.Size(81, 13);
            this.lbl_TranslatedText.TabIndex = 7;
            this.lbl_TranslatedText.Text = "Translated Text";
            // 
            // btn_startQuery
            // 
            this.btn_startQuery.Location = new System.Drawing.Point(28, 179);
            this.btn_startQuery.Name = "btn_startQuery";
            this.btn_startQuery.Size = new System.Drawing.Size(90, 23);
            this.btn_startQuery.TabIndex = 8;
            this.btn_startQuery.Text = "Start Query";
            this.btn_startQuery.UseVisualStyleBackColor = true;
            this.btn_startQuery.Click += new System.EventHandler(this.Btn_startQuery_Click);
            // 
            // btn_checkResult
            // 
            this.btn_checkResult.Location = new System.Drawing.Point(28, 208);
            this.btn_checkResult.Name = "btn_checkResult";
            this.btn_checkResult.Size = new System.Drawing.Size(90, 21);
            this.btn_checkResult.TabIndex = 9;
            this.btn_checkResult.Text = "Check Result";
            this.btn_checkResult.UseVisualStyleBackColor = true;
            this.btn_checkResult.Visible = false;
            this.btn_checkResult.Click += new System.EventHandler(this.Btn_checkResult_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 297);
            this.Controls.Add(this.btn_checkResult);
            this.Controls.Add(this.btn_startQuery);
            this.Controls.Add(this.lbl_TranslatedText);
            this.Controls.Add(this.lbl_originalText);
            this.Controls.Add(this.btn_importExcel);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.textBox_inputText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_inputText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button btn_importExcel;
        private System.Windows.Forms.Label lbl_originalText;
        private System.Windows.Forms.Label lbl_TranslatedText;
        private System.Windows.Forms.Button btn_startQuery;
        private System.Windows.Forms.Button btn_checkResult;
    }
}

