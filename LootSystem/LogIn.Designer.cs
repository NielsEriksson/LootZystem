namespace LootSystem
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GuildNameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.PasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GUILD NAME: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(392, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "PASSWORD:";
            // 
            // GuildNameTxt
            // 
            this.GuildNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuildNameTxt.Location = new System.Drawing.Point(397, 368);
            this.GuildNameTxt.Name = "GuildNameTxt";
            this.GuildNameTxt.Size = new System.Drawing.Size(135, 31);
            this.GuildNameTxt.TabIndex = 2;
            this.GuildNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GuildNameTxt.TextChanged += new System.EventHandler(this.GuildNameToUpper);
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(397, 497);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(135, 31);
            this.PasswordTxt.TabIndex = 3;
            this.PasswordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // LogInButton
            // 
            this.LogInButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LogInButton.Location = new System.Drawing.Point(586, 497);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(114, 31);
            this.LogInButton.TabIndex = 4;
            this.LogInButton.Text = "LOG IN";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // PasswordCheckBox
            // 
            this.PasswordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PasswordCheckBox.ForeColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.Location = new System.Drawing.Point(376, 498);
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.Size = new System.Drawing.Size(15, 30);
            this.PasswordCheckBox.TabIndex = 5;
            this.PasswordCheckBox.UseVisualStyleBackColor = false;
            this.PasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowHidePassword);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LootZystem.Properties.Resources.lootsies2;
            this.ClientSize = new System.Drawing.Size(1236, 722);
            this.Controls.Add(this.PasswordCheckBox);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.GuildNameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LootZystem - Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GuildNameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.CheckBox PasswordCheckBox;
    }
}