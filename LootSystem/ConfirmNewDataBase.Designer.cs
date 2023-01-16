namespace LootSystem
{
    partial class ConfirmNewDataBase
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
            this.CreateGuildBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GuildNameTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateGuildBtn
            // 
            this.CreateGuildBtn.Location = new System.Drawing.Point(108, 116);
            this.CreateGuildBtn.Name = "CreateGuildBtn";
            this.CreateGuildBtn.Size = new System.Drawing.Size(106, 25);
            this.CreateGuildBtn.TabIndex = 0;
            this.CreateGuildBtn.Text = "Create Guild";
            this.CreateGuildBtn.UseVisualStyleBackColor = true;
            this.CreateGuildBtn.Click += new System.EventHandler(this.CreateGuildBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "  This Guild Database doesnt exist yet.\r\n           Do you wish to create it?";
            // 
            // GuildNameTxt
            // 
            this.GuildNameTxt.AutoSize = true;
            this.GuildNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuildNameTxt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GuildNameTxt.Location = new System.Drawing.Point(121, 25);
            this.GuildNameTxt.Name = "GuildNameTxt";
            this.GuildNameTxt.Size = new System.Drawing.Size(82, 24);
            this.GuildNameTxt.TabIndex = 2;
            this.GuildNameTxt.Text = "------------";
            // 
            // ConfirmNewDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(326, 175);
            this.Controls.Add(this.GuildNameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateGuildBtn);
            this.Name = "ConfirmNewDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfirmNewDataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateGuildBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GuildNameTxt;
    }
}