namespace XBYNUM_C969_Application_Development.View.Calendar
{
    partial class DisplayEvents
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
            this.label1 = new System.Windows.Forms.Label();
            this.YourTimeZoneTextBox = new System.Windows.Forms.TextBox();
            this.daylightSavingsTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentsDataGridView
            // 
            this.appointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDataGridView.Location = new System.Drawing.Point(25, 38);
            this.appointmentsDataGridView.Name = "appointmentsDataGridView";
            this.appointmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsDataGridView.Size = new System.Drawing.Size(753, 297);
            this.appointmentsDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meeting Times Are Automatically Displayed In Your Time Zone:";
            // 
            // YourTimeZoneTextBox
            // 
            this.YourTimeZoneTextBox.Enabled = false;
            this.YourTimeZoneTextBox.Location = new System.Drawing.Point(360, 383);
            this.YourTimeZoneTextBox.Name = "YourTimeZoneTextBox";
            this.YourTimeZoneTextBox.Size = new System.Drawing.Size(221, 20);
            this.YourTimeZoneTextBox.TabIndex = 2;
            // 
            // daylightSavingsTimeTextBox
            // 
            this.daylightSavingsTimeTextBox.Enabled = false;
            this.daylightSavingsTimeTextBox.Location = new System.Drawing.Point(360, 418);
            this.daylightSavingsTimeTextBox.Name = "daylightSavingsTimeTextBox";
            this.daylightSavingsTimeTextBox.Size = new System.Drawing.Size(221, 20);
            this.daylightSavingsTimeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Is Daylight Savings Time?";
            // 
            // DisplayEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.daylightSavingsTimeTextBox);
            this.Controls.Add(this.YourTimeZoneTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appointmentsDataGridView);
            this.Name = "DisplayEvents";
            this.Text = "DisplayEvents";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appointmentsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YourTimeZoneTextBox;
        private System.Windows.Forms.TextBox daylightSavingsTimeTextBox;
        private System.Windows.Forms.Label label2;
    }
}