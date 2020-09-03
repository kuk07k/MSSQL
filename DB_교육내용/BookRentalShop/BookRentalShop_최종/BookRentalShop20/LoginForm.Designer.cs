namespace BookRentalShop20
{
    partial class LoginForm
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
            this.TxtUserID = new System.Windows.Forms.TextBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.TxtPassWord = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // TxtUserID
            // 
            this.TxtUserID.Location = new System.Drawing.Point(160, 75);
            this.TxtUserID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtUserID.MaxLength = 12;
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.Size = new System.Drawing.Size(166, 21);
            this.TxtUserID.TabIndex = 0;
            this.TxtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUserID_KeyPress);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(130, 158);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(80, 30);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // TxtPassWord
            // 
            this.TxtPassWord.Location = new System.Drawing.Point(160, 117);
            this.TxtPassWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtPassWord.MaxLength = 20;
            this.TxtPassWord.Name = "TxtPassWord";
            this.TxtPassWord.PasswordChar = '●';
            this.TxtPassWord.Size = new System.Drawing.Size(166, 21);
            this.TxtPassWord.TabIndex = 1;
            this.TxtPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassWord_KeyPress);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(245, 158);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(80, 30);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 216);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtPassWord);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(18, 48, 18, 16);
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUserID;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TextBox TxtPassWord;
        private System.Windows.Forms.Button BtnCancel;
    }
}