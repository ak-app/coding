namespace LibraryManagement.Forms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxData = new GroupBox();
            buttonCreate = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            dataGridViewData = new DataGridView();
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // groupBoxData
            // 
            groupBoxData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxData.Controls.Add(buttonCreate);
            groupBoxData.Controls.Add(buttonUpdate);
            groupBoxData.Controls.Add(buttonDelete);
            groupBoxData.Controls.Add(dataGridViewData);
            groupBoxData.Location = new Point(12, 12);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(560, 337);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "Bücher";
            // 
            // buttonCreate
            // 
            buttonCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCreate.Image = Properties.FormResource.Add;
            buttonCreate.Location = new Point(446, 308);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(32, 23);
            buttonCreate.TabIndex = 3;
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonAddOrUpdate_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUpdate.Enabled = false;
            buttonUpdate.Image = Properties.FormResource.Edit;
            buttonUpdate.Location = new Point(484, 308);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(32, 23);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonAddOrUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDelete.Enabled = false;
            buttonDelete.Image = Properties.FormResource.Remove;
            buttonDelete.Location = new Point(522, 308);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(32, 23);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "-";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // dataGridViewData
            // 
            dataGridViewData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Location = new Point(6, 22);
            dataGridViewData.MultiSelect = false;
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.ReadOnly = true;
            dataGridViewData.RowTemplate.Height = 25;
            dataGridViewData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewData.Size = new Size(548, 280);
            dataGridViewData.TabIndex = 0;
            dataGridViewData.SelectionChanged += dataGridViewData_SelectionChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(groupBoxData);
            MinimumSize = new Size(400, 200);
            Name = "FormMain";
            Text = "Bücherei";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            groupBoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxData;
        private Button buttonCreate;
        private Button buttonUpdate;
        private Button buttonDelete;
        private DataGridView dataGridViewData;
    }
}