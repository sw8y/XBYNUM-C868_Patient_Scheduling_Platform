namespace XBYNUM_C969_Application_Development
{
    partial class UserControlDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dayCountLabel = new System.Windows.Forms.Label();
            this.eventTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dayCountLabel
            // 
            this.dayCountLabel.AutoSize = true;
            this.dayCountLabel.Location = new System.Drawing.Point(4, 4);
            this.dayCountLabel.Name = "dayCountLabel";
            this.dayCountLabel.Size = new System.Drawing.Size(19, 13);
            this.dayCountLabel.TabIndex = 0;
            this.dayCountLabel.Text = "00";
            // 
            // eventTitle
            // 
            this.eventTitle.Location = new System.Drawing.Point(3, 47);
            this.eventTitle.Name = "eventTitle";
            this.eventTitle.Size = new System.Drawing.Size(129, 23);
            this.eventTitle.TabIndex = 1;
            this.eventTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.eventTitle);
            this.Controls.Add(this.dayCountLabel);
            this.Name = "UserControlDay";
            this.Size = new System.Drawing.Size(135, 82);
            this.Click += new System.EventHandler(this.UserControlDay_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dayCountLabel;
        private System.Windows.Forms.Label eventTitle;
    }
}
