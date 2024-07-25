namespace XBYNUM_C969_Application_Development
{
    partial class LoginPageView
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
            this.LoginPageTitle = new System.Windows.Forms.Label();
            this.loginPageUsernameTextBox = new System.Windows.Forms.TextBox();
            this.loginPagePasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginPageUsernameLabel = new System.Windows.Forms.Label();
            this.loginPagePasswordLabel = new System.Windows.Forms.Label();
            this.loginPageSubmitButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginPageTitle
            // 
            this.LoginPageTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPageTitle.Location = new System.Drawing.Point(303, 80);
            this.LoginPageTitle.Name = "LoginPageTitle";
            this.LoginPageTitle.Size = new System.Drawing.Size(234, 19);
            this.LoginPageTitle.TabIndex = 0;
            this.LoginPageTitle.Text = "Scheduling Software";
            this.LoginPageTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginPageUsernameTextBox
            // 
            this.loginPageUsernameTextBox.Location = new System.Drawing.Point(363, 196);
            this.loginPageUsernameTextBox.Name = "loginPageUsernameTextBox";
            this.loginPageUsernameTextBox.Size = new System.Drawing.Size(174, 20);
            this.loginPageUsernameTextBox.TabIndex = 1;
            this.loginPageUsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginPagePasswordTextBox
            // 
            this.loginPagePasswordTextBox.Location = new System.Drawing.Point(363, 234);
            this.loginPagePasswordTextBox.Name = "loginPagePasswordTextBox";
            this.loginPagePasswordTextBox.PasswordChar = '*';
            this.loginPagePasswordTextBox.Size = new System.Drawing.Size(174, 20);
            this.loginPagePasswordTextBox.TabIndex = 2;
            this.loginPagePasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginPageUsernameLabel
            // 
            this.loginPageUsernameLabel.AutoSize = true;
            this.loginPageUsernameLabel.Location = new System.Drawing.Point(303, 199);
            this.loginPageUsernameLabel.Name = "loginPageUsernameLabel";
            this.loginPageUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.loginPageUsernameLabel.TabIndex = 3;
            this.loginPageUsernameLabel.Text = "Username:";
            // 
            // loginPagePasswordLabel
            // 
            this.loginPagePasswordLabel.AutoSize = true;
            this.loginPagePasswordLabel.Location = new System.Drawing.Point(305, 237);
            this.loginPagePasswordLabel.Name = "loginPagePasswordLabel";
            this.loginPagePasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.loginPagePasswordLabel.TabIndex = 4;
            this.loginPagePasswordLabel.Text = "Password:";
            // 
            // loginPageSubmitButton
            // 
            this.loginPageSubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPageSubmitButton.Location = new System.Drawing.Point(383, 297);
            this.loginPageSubmitButton.Name = "loginPageSubmitButton";
            this.loginPageSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.loginPageSubmitButton.TabIndex = 5;
            this.loginPageSubmitButton.Text = "Submit";
            this.loginPageSubmitButton.UseVisualStyleBackColor = true;
            this.loginPageSubmitButton.Click += new System.EventHandler(this.loginPageSubmitButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(284, 159);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(76, 13);
            this.locationLabel.TabIndex = 8;
            this.locationLabel.Text = "Your Location:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Enabled = false;
            this.locationTextBox.Location = new System.Drawing.Point(363, 156);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(174, 20);
            this.locationTextBox.TabIndex = 7;
            this.locationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(840, 459);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.loginPageSubmitButton);
            this.Controls.Add(this.loginPagePasswordLabel);
            this.Controls.Add(this.loginPageUsernameLabel);
            this.Controls.Add(this.loginPagePasswordTextBox);
            this.Controls.Add(this.loginPageUsernameTextBox);
            this.Controls.Add(this.LoginPageTitle);
            this.Name = "LoginPageView";
            this.Text = "Schedule It!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginPageTitle;
        private System.Windows.Forms.TextBox loginPageUsernameTextBox;
        private System.Windows.Forms.TextBox loginPagePasswordTextBox;
        private System.Windows.Forms.Label loginPageUsernameLabel;
        private System.Windows.Forms.Label loginPagePasswordLabel;
        private System.Windows.Forms.Button loginPageSubmitButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
    }
}

