namespace LibraryManagement.Forms
{
    partial class FormData
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.buttonDo = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelISBN = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.buttonDo);
            this.groupBoxBook.Controls.Add(this.labelAuthor);
            this.groupBoxBook.Controls.Add(this.textBoxAuthor);
            this.groupBoxBook.Controls.Add(this.labelTitle);
            this.groupBoxBook.Controls.Add(this.textBoxTitle);
            this.groupBoxBook.Controls.Add(this.labelISBN);
            this.groupBoxBook.Controls.Add(this.textBoxISBN);
            this.groupBoxBook.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(288, 147);
            this.groupBoxBook.TabIndex = 0;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Buch";
            // 
            // buttonDo
            // 
            this.buttonDo.Location = new System.Drawing.Point(208, 110);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(69, 23);
            this.buttonDo.TabIndex = 6;
            this.buttonDo.Text = "?";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(6, 80);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(65, 23);
            this.labelAuthor.TabIndex = 5;
            this.labelAuthor.Text = "Autor:";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(77, 81);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(200, 23);
            this.textBoxAuthor.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(6, 51);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(65, 23);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title:";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(77, 52);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 23);
            this.textBoxTitle.TabIndex = 2;
            // 
            // labelISBN
            // 
            this.labelISBN.Location = new System.Drawing.Point(6, 22);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(65, 23);
            this.labelISBN.TabIndex = 1;
            this.labelISBN.Text = "ISBN:";
            this.labelISBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(77, 23);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(200, 23);
            this.textBoxISBN.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 171);
            this.Controls.Add(this.groupBoxBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormData";
            this.Text = "?";
            this.Load += new System.EventHandler(this.FormData_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxBook;
        private Label labelAuthor;
        private TextBox textBoxAuthor;
        private Label labelTitle;
        private TextBox textBoxTitle;
        private Label labelISBN;
        private TextBox textBoxISBN;
        private Button buttonDo;
        private ErrorProvider errorProvider;
    }
}