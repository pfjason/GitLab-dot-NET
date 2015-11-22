namespace GitLab
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.LogoList1 = new System.Windows.Forms.ImageList(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.uriTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.defaultLocationTextBox = new System.Windows.Forms.TextBox();
            this.defaultLocationButton = new System.Windows.Forms.Button();
            this.httpCheckBox = new System.Windows.Forms.CheckBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogoList1
            // 
            this.LogoList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LogoList1.ImageStream")));
            this.LogoList1.TransparentColor = System.Drawing.Color.Transparent;
            this.LogoList1.Images.SetKeyName(0, "gitlab-logo-16x16.ico");
            this.LogoList1.Images.SetKeyName(1, "gitlab-logo-32x32.ico");
            this.LogoList1.Images.SetKeyName(2, "gitlab-logo-16x16.bmp");
            this.LogoList1.Images.SetKeyName(3, "gitlab-logo-32x32.bmp");
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(388, 111);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(307, 111);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // uriTextBox
            // 
            this.uriTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriTextBox.Location = new System.Drawing.Point(82, 33);
            this.uriTextBox.Name = "uriTextBox";
            this.uriTextBox.Size = new System.Drawing.Size(381, 20);
            this.uriTextBox.TabIndex = 2;
            this.uriTextBox.Text = "https://gitlab.mydomain.local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "GitLab URI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "API Token:";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiKeyTextBox.Location = new System.Drawing.Point(82, 58);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.Size = new System.Drawing.Size(381, 20);
            this.apiKeyTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Default Project Location: ";
            // 
            // defaultLocationTextBox
            // 
            this.defaultLocationTextBox.Location = new System.Drawing.Point(145, 84);
            this.defaultLocationTextBox.Name = "defaultLocationTextBox";
            this.defaultLocationTextBox.ReadOnly = true;
            this.defaultLocationTextBox.Size = new System.Drawing.Size(282, 20);
            this.defaultLocationTextBox.TabIndex = 7;
            // 
            // defaultLocationButton
            // 
            this.defaultLocationButton.Location = new System.Drawing.Point(433, 84);
            this.defaultLocationButton.Name = "defaultLocationButton";
            this.defaultLocationButton.Size = new System.Drawing.Size(30, 20);
            this.defaultLocationButton.TabIndex = 4;
            this.defaultLocationButton.Text = "...";
            this.defaultLocationButton.UseVisualStyleBackColor = true;
            this.defaultLocationButton.Click += new System.EventHandler(this.defaultLocationButton_Click);
            // 
            // httpCheckBox
            // 
            this.httpCheckBox.AutoSize = true;
            this.httpCheckBox.Location = new System.Drawing.Point(15, 115);
            this.httpCheckBox.Name = "httpCheckBox";
            this.httpCheckBox.Size = new System.Drawing.Size(151, 17);
            this.httpCheckBox.TabIndex = 5;
            this.httpCheckBox.Text = "Use HTTP instead of SSH";
            this.httpCheckBox.UseVisualStyleBackColor = true;
            // 
            // nameComboBox
            // 
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(56, 6);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(407, 21);
            this.nameComboBox.TabIndex = 1;
            this.nameComboBox.SelectedIndexChanged += new System.EventHandler(this.nameComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name:";
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(475, 146);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.httpCheckBox);
            this.Controls.Add(this.defaultLocationButton);
            this.Controls.Add(this.defaultLocationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apiKeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uriTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Text = "Configure GitLab Connections";
            this.Load += new System.EventHandler(this.ConfigureGitLabForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ImageList LogoList1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox uriTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apiKeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox defaultLocationTextBox;
        private System.Windows.Forms.Button defaultLocationButton;
        private System.Windows.Forms.CheckBox httpCheckBox;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.Label label4;

    }
}