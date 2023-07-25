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
            components = new System.ComponentModel.Container();
            groupBoxData = new GroupBox();
            buttonDo = new Button();
            labelAuthor = new Label();
            textBoxAuthor = new TextBox();
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            labelISBN = new Label();
            textBoxISBN = new TextBox();
            errorProvider = new ErrorProvider(components);
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // groupBoxData
            // 
            groupBoxData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxData.Controls.Add(buttonDo);
            groupBoxData.Controls.Add(labelAuthor);
            groupBoxData.Controls.Add(textBoxAuthor);
            groupBoxData.Controls.Add(labelTitle);
            groupBoxData.Controls.Add(textBoxTitle);
            groupBoxData.Controls.Add(labelISBN);
            groupBoxData.Controls.Add(textBoxISBN);
            groupBoxData.Location = new Point(12, 12);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(360, 142);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Buch";
            // 
            // buttonDo
            // 
            buttonDo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDo.Location = new Point(294, 109);
            buttonDo.Name = "buttonDo";
            buttonDo.Size = new Size(32, 23);
            buttonDo.TabIndex = 6;
            buttonDo.Text = "?";
            buttonDo.UseVisualStyleBackColor = true;
            buttonDo.Click += buttonDo_Click;
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(24, 83);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(40, 15);
            labelAuthor.TabIndex = 5;
            labelAuthor.Text = "Autor:";
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthor.Location = new Point(70, 80);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(256, 23);
            textBoxAuthor.TabIndex = 4;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(32, 54);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(32, 15);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "Title:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTitle.Location = new Point(70, 51);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(256, 23);
            textBoxTitle.TabIndex = 2;
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Location = new Point(29, 25);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(35, 15);
            labelISBN.TabIndex = 1;
            labelISBN.Text = "ISBN:";
            // 
            // textBoxISBN
            // 
            textBoxISBN.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxISBN.Location = new Point(70, 22);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.ReadOnly = true;
            textBoxISBN.Size = new Size(256, 23);
            textBoxISBN.TabIndex = 0;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 166);
            Controls.Add(groupBoxData);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 205);
            Name = "FormData";
            ShowInTaskbar = false;
            Text = "?";
            Load += FormData_Load;
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxData;
        private Label labelISBN;
        private TextBox textBoxISBN;
        private Button buttonDo;
        private Label labelAuthor;
        private TextBox textBoxAuthor;
        private Label labelTitle;
        private TextBox textBoxTitle;
        private ErrorProvider errorProvider;
    }
}