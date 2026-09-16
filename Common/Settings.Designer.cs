namespace Common
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxEnterCred = new System.Windows.Forms.GroupBox();
            this.checkBoxShowPass = new System.Windows.Forms.CheckBox();
            this.buttonChPass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.groupBoxSQLCred = new System.Windows.Forms.GroupBox();
            this.buttonSaveChs = new System.Windows.Forms.Button();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.textBoxSQLLogin = new System.Windows.Forms.TextBox();
            this.textBoxSQLPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxEnterCred.SuspendLayout();
            this.groupBoxSQLCred.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 227);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBoxEnterCred
            // 
            this.groupBoxEnterCred.Controls.Add(this.checkBoxShowPass);
            this.groupBoxEnterCred.Controls.Add(this.buttonChPass);
            this.groupBoxEnterCred.Controls.Add(this.label2);
            this.groupBoxEnterCred.Controls.Add(this.textBoxNewPass);
            this.groupBoxEnterCred.Location = new System.Drawing.Point(16, 253);
            this.groupBoxEnterCred.Name = "groupBoxEnterCred";
            this.groupBoxEnterCred.Size = new System.Drawing.Size(750, 91);
            this.groupBoxEnterCred.TabIndex = 1;
            this.groupBoxEnterCred.TabStop = false;
            this.groupBoxEnterCred.Text = "Зміна пароля для входу в додаток";
            // 
            // checkBoxShowPass
            // 
            this.checkBoxShowPass.AutoSize = true;
            this.checkBoxShowPass.Location = new System.Drawing.Point(417, 36);
            this.checkBoxShowPass.Name = "checkBoxShowPass";
            this.checkBoxShowPass.Size = new System.Drawing.Size(108, 24);
            this.checkBoxShowPass.TabIndex = 8;
            this.checkBoxShowPass.Text = "Показати";
            this.checkBoxShowPass.UseVisualStyleBackColor = true;
            this.checkBoxShowPass.CheckedChanged += new System.EventHandler(this.checkBoxShowPass_CheckedChanged);
            // 
            // buttonChPass
            // 
            this.buttonChPass.Location = new System.Drawing.Point(566, 25);
            this.buttonChPass.Name = "buttonChPass";
            this.buttonChPass.Size = new System.Drawing.Size(178, 49);
            this.buttonChPass.TabIndex = 7;
            this.buttonChPass.Text = "Змінити пароль";
            this.buttonChPass.UseVisualStyleBackColor = true;
            this.buttonChPass.Click += new System.EventHandler(this.buttonChPass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Новий пароль:";
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNewPass.Location = new System.Drawing.Point(142, 32);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.Size = new System.Drawing.Size(269, 30);
            this.textBoxNewPass.TabIndex = 4;
            this.textBoxNewPass.UseSystemPasswordChar = true;
            // 
            // groupBoxSQLCred
            // 
            this.groupBoxSQLCred.Controls.Add(this.buttonSaveChs);
            this.groupBoxSQLCred.Controls.Add(this.textBoxServerName);
            this.groupBoxSQLCred.Controls.Add(this.textBoxSQLLogin);
            this.groupBoxSQLCred.Controls.Add(this.textBoxSQLPass);
            this.groupBoxSQLCred.Controls.Add(this.label5);
            this.groupBoxSQLCred.Controls.Add(this.label4);
            this.groupBoxSQLCred.Controls.Add(this.label3);
            this.groupBoxSQLCred.Location = new System.Drawing.Point(16, 359);
            this.groupBoxSQLCred.Name = "groupBoxSQLCred";
            this.groupBoxSQLCred.Size = new System.Drawing.Size(750, 173);
            this.groupBoxSQLCred.TabIndex = 2;
            this.groupBoxSQLCred.TabStop = false;
            this.groupBoxSQLCred.Text = "Нові параметри підключення до БД";
            // 
            // buttonSaveChs
            // 
            this.buttonSaveChs.Location = new System.Drawing.Point(566, 75);
            this.buttonSaveChs.Name = "buttonSaveChs";
            this.buttonSaveChs.Size = new System.Drawing.Size(178, 49);
            this.buttonSaveChs.TabIndex = 8;
            this.buttonSaveChs.Text = "Зберегти зміни";
            this.buttonSaveChs.UseVisualStyleBackColor = true;
            this.buttonSaveChs.Click += new System.EventHandler(this.buttonSaveChs_Click);
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxServerName.Location = new System.Drawing.Point(252, 46);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(251, 30);
            this.textBoxServerName.TabIndex = 10;
            // 
            // textBoxSQLLogin
            // 
            this.textBoxSQLLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSQLLogin.Location = new System.Drawing.Point(252, 82);
            this.textBoxSQLLogin.Name = "textBoxSQLLogin";
            this.textBoxSQLLogin.Size = new System.Drawing.Size(251, 30);
            this.textBoxSQLLogin.TabIndex = 9;
            // 
            // textBoxSQLPass
            // 
            this.textBoxSQLPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSQLPass.Location = new System.Drawing.Point(252, 118);
            this.textBoxSQLPass.Name = "textBoxSQLPass";
            this.textBoxSQLPass.Size = new System.Drawing.Size(251, 30);
            this.textBoxSQLPass.TabIndex = 8;
            this.textBoxSQLPass.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Пароль SQL Автентифікації";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Логін SQL Автентифікації";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ім\'я сервера";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.groupBoxSQLCred);
            this.Controls.Add(this.groupBoxEnterCred);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Налаштування";
            this.groupBoxEnterCred.ResumeLayout(false);
            this.groupBoxEnterCred.PerformLayout();
            this.groupBoxSQLCred.ResumeLayout(false);
            this.groupBoxSQLCred.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxEnterCred;
        private System.Windows.Forms.CheckBox checkBoxShowPass;
        private System.Windows.Forms.Button buttonChPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.GroupBox groupBoxSQLCred;
        private System.Windows.Forms.Button buttonSaveChs;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.TextBox textBoxSQLLogin;
        private System.Windows.Forms.TextBox textBoxSQLPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}