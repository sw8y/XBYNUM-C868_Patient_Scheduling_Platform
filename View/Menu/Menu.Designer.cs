namespace XBYNUM_C969_Application_Development
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.customerGoButton = new System.Windows.Forms.Button();
            this.reportGoButton = new System.Windows.Forms.Button();
            this.calendarGoButton = new System.Windows.Forms.Button();
            this.appointmentGoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select An Option From Below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(563, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Run Reports";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "View Calendar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Patients (add, update, and delete)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(492, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Appointments (add, update, and delete)";
            // 
            // customerGoButton
            // 
            this.customerGoButton.Location = new System.Drawing.Point(124, 179);
            this.customerGoButton.Name = "customerGoButton";
            this.customerGoButton.Size = new System.Drawing.Size(75, 23);
            this.customerGoButton.TabIndex = 5;
            this.customerGoButton.Text = "Go";
            this.customerGoButton.UseVisualStyleBackColor = true;
            this.customerGoButton.Click += new System.EventHandler(this.customerGoButton_Click);
            // 
            // reportGoButton
            // 
            this.reportGoButton.Location = new System.Drawing.Point(566, 294);
            this.reportGoButton.Name = "reportGoButton";
            this.reportGoButton.Size = new System.Drawing.Size(75, 23);
            this.reportGoButton.TabIndex = 7;
            this.reportGoButton.Text = "Go";
            this.reportGoButton.UseVisualStyleBackColor = true;
            this.reportGoButton.Click += new System.EventHandler(this.reportGoButton_Click);
            // 
            // calendarGoButton
            // 
            this.calendarGoButton.Location = new System.Drawing.Point(124, 294);
            this.calendarGoButton.Name = "calendarGoButton";
            this.calendarGoButton.Size = new System.Drawing.Size(75, 23);
            this.calendarGoButton.TabIndex = 8;
            this.calendarGoButton.Text = "Go";
            this.calendarGoButton.UseVisualStyleBackColor = true;
            this.calendarGoButton.Click += new System.EventHandler(this.calendarGoButton_Click);
            // 
            // appointmentGoButton
            // 
            this.appointmentGoButton.Location = new System.Drawing.Point(566, 179);
            this.appointmentGoButton.Name = "appointmentGoButton";
            this.appointmentGoButton.Size = new System.Drawing.Size(75, 23);
            this.appointmentGoButton.TabIndex = 9;
            this.appointmentGoButton.Text = "Go";
            this.appointmentGoButton.UseVisualStyleBackColor = true;
            this.appointmentGoButton.Click += new System.EventHandler(this.appointmentGoButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appointmentGoButton);
            this.Controls.Add(this.calendarGoButton);
            this.Controls.Add(this.reportGoButton);
            this.Controls.Add(this.customerGoButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button customerGoButton;
        private System.Windows.Forms.Button reportGoButton;
        private System.Windows.Forms.Button calendarGoButton;
        private System.Windows.Forms.Button appointmentGoButton;
    }
}