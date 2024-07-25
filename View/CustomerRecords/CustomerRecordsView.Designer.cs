namespace XBYNUM_C969_Application_Development
{
    partial class CustomerRecordsView
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
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomerRecordsUpdateButton = new System.Windows.Forms.Button();
            this.CustomerRecordsDeleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerRecordsAddButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(12, 82);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView.Size = new System.Drawing.Size(776, 279);
            this.customerDataGridView.TabIndex = 0;
            // 
            // CustomerRecordsUpdateButton
            // 
            this.CustomerRecordsUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerRecordsUpdateButton.Location = new System.Drawing.Point(77, 3);
            this.CustomerRecordsUpdateButton.Name = "CustomerRecordsUpdateButton";
            this.CustomerRecordsUpdateButton.Size = new System.Drawing.Size(69, 23);
            this.CustomerRecordsUpdateButton.TabIndex = 2;
            this.CustomerRecordsUpdateButton.Text = "Update";
            this.CustomerRecordsUpdateButton.UseVisualStyleBackColor = true;
            this.CustomerRecordsUpdateButton.Click += new System.EventHandler(this.CustomerRecordsUpdateButton_Click);
            // 
            // CustomerRecordsDeleteButton
            // 
            this.CustomerRecordsDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerRecordsDeleteButton.Location = new System.Drawing.Point(152, 3);
            this.CustomerRecordsDeleteButton.Name = "CustomerRecordsDeleteButton";
            this.CustomerRecordsDeleteButton.Size = new System.Drawing.Size(70, 23);
            this.CustomerRecordsDeleteButton.TabIndex = 3;
            this.CustomerRecordsDeleteButton.Text = "Delete";
            this.CustomerRecordsDeleteButton.UseVisualStyleBackColor = true;
            this.CustomerRecordsDeleteButton.Click += new System.EventHandler(this.CustomerRecordsDeleteButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.CustomerRecordsAddButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CustomerRecordsDeleteButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CustomerRecordsUpdateButton, 1, 0);
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
            // CustomerRecordsAddButton
            // 
            this.CustomerRecordsAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerRecordsAddButton.Location = new System.Drawing.Point(3, 3);
            this.CustomerRecordsAddButton.Name = "CustomerRecordsAddButton";
            this.CustomerRecordsAddButton.Size = new System.Drawing.Size(68, 23);
            this.CustomerRecordsAddButton.TabIndex = 4;
            this.CustomerRecordsAddButton.Text = "Add";
            this.CustomerRecordsAddButton.UseVisualStyleBackColor = true;
            this.CustomerRecordsAddButton.Click += new System.EventHandler(this.CustomerRecordsAddButton_Click);
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
            // CustomerRecordsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.customerDataGridView);
            this.Name = "CustomerRecordsView";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.Button CustomerRecordsUpdateButton;
        private System.Windows.Forms.Button CustomerRecordsDeleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CustomerRecordsAddButton;
        private System.Windows.Forms.Button button1;
    }
}