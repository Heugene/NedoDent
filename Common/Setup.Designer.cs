namespace Common
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSQLCred = new System.Windows.Forms.GroupBox();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.textBoxSQLLogin = new System.Windows.Forms.TextBox();
            this.textBoxSQLPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxAppCred = new System.Windows.Forms.GroupBox();
            this.textBoxAppLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.labelDocWarn = new System.Windows.Forms.Label();
            this.groupBoxSQLCred.SuspendLayout();
            this.groupBoxAppCred.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(804, 118);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вітаємо!\r\nЦе перший запуск додатка. Для початку роботи потрібно зробити деякі нал" +
    "аштування\r\n\r\nПАРОЛЬ ДЛЯ ВХОДУ ЗА ЗАМОВЧУВАННЯМ: \"1111\".\r\nДалі пароль для входу м" +
    "ожна змінити в налаштуваннях додатка.";
            // 
            // groupBoxSQLCred
            // 
            this.groupBoxSQLCred.Controls.Add(this.textBoxServerName);
            this.groupBoxSQLCred.Controls.Add(this.textBoxSQLLogin);
            this.groupBoxSQLCred.Controls.Add(this.textBoxSQLPassword);
            this.groupBoxSQLCred.Controls.Add(this.label5);
            this.groupBoxSQLCred.Controls.Add(this.label4);
            this.groupBoxSQLCred.Controls.Add(this.label3);
            this.groupBoxSQLCred.Location = new System.Drawing.Point(16, 304);
            this.groupBoxSQLCred.Name = "groupBoxSQLCred";
            this.groupBoxSQLCred.Size = new System.Drawing.Size(800, 173);
            this.groupBoxSQLCred.TabIndex = 3;
            this.groupBoxSQLCred.TabStop = false;
            this.groupBoxSQLCred.Text = "Параметри підключення до БД";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxServerName.Location = new System.Drawing.Point(369, 37);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(251, 30);
            this.textBoxServerName.TabIndex = 10;
            // 
            // textBoxSQLLogin
            // 
            this.textBoxSQLLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSQLLogin.Location = new System.Drawing.Point(369, 75);
            this.textBoxSQLLogin.Name = "textBoxSQLLogin";
            this.textBoxSQLLogin.Size = new System.Drawing.Size(251, 30);
            this.textBoxSQLLogin.TabIndex = 9;
            // 
            // textBoxSQLPassword
            // 
            this.textBoxSQLPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSQLPassword.Location = new System.Drawing.Point(369, 114);
            this.textBoxSQLPassword.Name = "textBoxSQLPassword";
            this.textBoxSQLPassword.Size = new System.Drawing.Size(251, 30);
            this.textBoxSQLPassword.TabIndex = 8;
            this.textBoxSQLPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Пароль SQL Автентифікації:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Логін SQL Автентифікації:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ім\'я сервера:";
            // 
            // groupBoxAppCred
            // 
            this.groupBoxAppCred.Controls.Add(this.labelDocWarn);
            this.groupBoxAppCred.Controls.Add(this.textBoxAppLogin);
            this.groupBoxAppCred.Controls.Add(this.label2);
            this.groupBoxAppCred.Location = new System.Drawing.Point(16, 144);
            this.groupBoxAppCred.Name = "groupBoxAppCred";
            this.groupBoxAppCred.Size = new System.Drawing.Size(800, 154);
            this.groupBoxAppCred.TabIndex = 4;
            this.groupBoxAppCred.TabStop = false;
            this.groupBoxAppCred.Text = "Логін для входу в додаток";
            // 
            // textBoxAppLogin
            // 
            this.textBoxAppLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAppLogin.Location = new System.Drawing.Point(369, 42);
            this.textBoxAppLogin.Name = "textBoxAppLogin";
            this.textBoxAppLogin.Size = new System.Drawing.Size(251, 30);
            this.textBoxAppLogin.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Логін:";
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(303, 483);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(258, 49);
            this.buttonSaveConfig.TabIndex = 5;
            this.buttonSaveConfig.Text = "Зберегти і продовжити";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // labelDocWarn
            // 
            this.labelDocWarn.ForeColor = System.Drawing.Color.Red;
            this.labelDocWarn.Location = new System.Drawing.Point(6, 90);
            this.labelDocWarn.Name = "labelDocWarn";
            this.labelDocWarn.Size = new System.Drawing.Size(788, 61);
            this.labelDocWarn.TabIndex = 13;
            this.labelDocWarn.Text = resources.GetString("labelDocWarn.Text");
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 544);
            this.Controls.Add(this.buttonSaveConfig);
            this.Controls.Add(this.groupBoxAppCred);
            this.Controls.Add(this.groupBoxSQLCred);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перша конфігурація";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setup_FormClosed);
            this.Load += new System.EventHandler(this.Setup_Load);
            this.groupBoxSQLCred.ResumeLayout(false);
            this.groupBoxSQLCred.PerformLayout();
            this.groupBoxAppCred.ResumeLayout(false);
            this.groupBoxAppCred.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSQLCred;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.TextBox textBoxSQLLogin;
        private System.Windows.Forms.TextBox textBoxSQLPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxAppCred;
        private System.Windows.Forms.TextBox textBoxAppLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.Label labelDocWarn;
    }
}