namespace XBYNUM_C969_Application_Development
{
    partial class PatientRecordsView
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
            this.patientDataGridView = new System.Windows.Forms.DataGridView();
            this.PatientRecordsUpdateButton = new System.Windows.Forms.Button();
            this.PatientRecordsDeleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PatientRecordsAddButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.patientDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientDataGridView
            // 
            this.patientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientDataGridView.Location = new System.Drawing.Point(12, 82);
            this.patientDataGridView.Name = "patientDataGridView";
            this.patientDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patientDataGridView.Size = new System.Drawing.Size(776, 279);
            this.patientDataGridView.TabIndex = 0;
            // 
            // PatientRecordsUpdateButton
            // 
            this.PatientRecordsUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientRecordsUpdateButton.Location = new System.Drawing.Point(77, 3);
            this.PatientRecordsUpdateButton.Name = "PatientRecordsUpdateButton";
            this.PatientRecordsUpdateButton.Size = new System.Drawing.Size(69, 23);
            this.PatientRecordsUpdateButton.TabIndex = 2;
            this.PatientRecordsUpdateButton.Text = "Update";
            this.PatientRecordsUpdateButton.UseVisualStyleBackColor = true;
            this.PatientRecordsUpdateButton.Click += new System.EventHandler(this.PatientRecordsUpdateButton_Click);
            // 
            // PatientRecordsDeleteButton
            // 
            this.PatientRecordsDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientRecordsDeleteButton.Location = new System.Drawing.Point(152, 3);
            this.PatientRecordsDeleteButton.Name = "PatientRecordsDeleteButton";
            this.PatientRecordsDeleteButton.Size = new System.Drawing.Size(70, 23);
            this.PatientRecordsDeleteButton.TabIndex = 3;
            this.PatientRecordsDeleteButton.Text = "Delete";
            this.PatientRecordsDeleteButton.UseVisualStyleBackColor = true;
            this.PatientRecordsDeleteButton.Click += new System.EventHandler(this.PatientRecordsDeleteButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.PatientRecordsAddButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PatientRecordsDeleteButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.PatientRecordsUpdateButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(288, 376);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 62);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // PatientRecordsAddButton
            // 
            this.PatientRecordsAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientRecordsAddButton.Location = new System.Drawing.Point(3, 3);
            this.PatientRecordsAddButton.Name = "PatientRecordsAddButton";
            this.PatientRecordsAddButton.Size = new System.Drawing.Size(68, 23);
            this.PatientRecordsAddButton.TabIndex = 4;
            this.PatientRecordsAddButton.Text = "Add";
            this.PatientRecordsAddButton.UseVisualStyleBackColor = true;
            this.PatientRecordsAddButton.Click += new System.EventHandler(this.PatientRecordsAddButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(77, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(567, 31);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(143, 20);
            this.textBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(716, 32);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(72, 19);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // PatientRecordsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.patientDataGridView);
            this.Name = "PatientRecordsView";
            this.Text = "Patient Records";
            ((System.ComponentModel.ISupportInitialize)(this.patientDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView patientDataGridView;
        private System.Windows.Forms.Button PatientRecordsUpdateButton;
        private System.Windows.Forms.Button PatientRecordsDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button PatientRecordsAddButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button searchButton;
    }
}