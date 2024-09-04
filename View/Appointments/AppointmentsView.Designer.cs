namespace XBYNUM_C969_Application_Development
{
    partial class AppointmentsView
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
            this.appointmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AppointmentsAddButton = new System.Windows.Forms.Button();
            this.AppointmentsDeleteButton = new System.Windows.Forms.Button();
            this.AppointmentsUpdateButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentsDataGridView
            // 
            this.appointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDataGridView.Location = new System.Drawing.Point(12, 55);
            this.appointmentsDataGridView.Name = "appointmentsDataGridView";
            this.appointmentsDataGridView.Size = new System.Drawing.Size(776, 315);
            this.appointmentsDataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.AppointmentsAddButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AppointmentsDeleteButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.AppointmentsUpdateButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.goBackButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(288, 376);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 58);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // AppointmentsAddButton
            // 
            this.AppointmentsAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppointmentsAddButton.Location = new System.Drawing.Point(3, 3);
            this.AppointmentsAddButton.Name = "AppointmentsAddButton";
            this.AppointmentsAddButton.Size = new System.Drawing.Size(68, 23);
            this.AppointmentsAddButton.TabIndex = 4;
            this.AppointmentsAddButton.Text = "Add";
            this.AppointmentsAddButton.UseVisualStyleBackColor = true;
            this.AppointmentsAddButton.Click += new System.EventHandler(this.AppointmentsAddButton_Click);
            // 
            // AppointmentsDeleteButton
            // 
            this.AppointmentsDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppointmentsDeleteButton.Location = new System.Drawing.Point(152, 3);
            this.AppointmentsDeleteButton.Name = "AppointmentsDeleteButton";
            this.AppointmentsDeleteButton.Size = new System.Drawing.Size(70, 23);
            this.AppointmentsDeleteButton.TabIndex = 3;
            this.AppointmentsDeleteButton.Text = "Delete";
            this.AppointmentsDeleteButton.UseVisualStyleBackColor = true;
            this.AppointmentsDeleteButton.Click += new System.EventHandler(this.AppointmentsDeleteButton_Click);
            // 
            // AppointmentsUpdateButton
            // 
            this.AppointmentsUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppointmentsUpdateButton.Location = new System.Drawing.Point(77, 3);
            this.AppointmentsUpdateButton.Name = "AppointmentsUpdateButton";
            this.AppointmentsUpdateButton.Size = new System.Drawing.Size(69, 23);
            this.AppointmentsUpdateButton.TabIndex = 2;
            this.AppointmentsUpdateButton.Text = "Update";
            this.AppointmentsUpdateButton.UseVisualStyleBackColor = true;
            this.AppointmentsUpdateButton.Click += new System.EventHandler(this.AppointmentsUpdateButton_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goBackButton.Location = new System.Drawing.Point(77, 33);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(69, 22);
            this.goBackButton.TabIndex = 5;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(638, 30);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(72, 19);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(489, 29);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(143, 20);
            this.textBox.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(716, 30);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(72, 19);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // AppointmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.appointmentsDataGridView);
            this.Name = "AppointmentsView";
            this.Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appointmentsDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AppointmentsAddButton;
        private System.Windows.Forms.Button AppointmentsDeleteButton;
        private System.Windows.Forms.Button AppointmentsUpdateButton;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button clearButton;
    }
}