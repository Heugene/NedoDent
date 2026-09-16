namespace Registrator
{
    partial class Registrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrator));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проДодатокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оглядToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прийомиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пацієнтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лікаріToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAppointments = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPatients = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDoctors = new System.Windows.Forms.ToolStripButton();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelToolAppointments = new System.Windows.Forms.Panel();
            this.buttonCancelApp = new System.Windows.Forms.Button();
            this.buttonNewApp = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNewPat = new System.Windows.Forms.Button();
            this.buttonEditPat = new System.Windows.Forms.Button();
            this.panelToolPatients = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panelToolAppointments.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelToolPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.системаToolStripMenuItem,
            this.оглядToolStripMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(928, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.налаштуванняToolStripMenuItem,
            this.проДодатокToolStripMenuItem,
            this.toolStripSeparator1,
            this.вихідToolStripMenuItem});
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.системаToolStripMenuItem.Text = "Система";
            // 
            // налаштуванняToolStripMenuItem
            // 
            this.налаштуванняToolStripMenuItem.Name = "налаштуванняToolStripMenuItem";
            this.налаштуванняToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.налаштуванняToolStripMenuItem.Text = "Налаштування...";
            this.налаштуванняToolStripMenuItem.Click += new System.EventHandler(this.налаштуванняToolStripMenuItem_Click);
            // 
            // проДодатокToolStripMenuItem
            // 
            this.проДодатокToolStripMenuItem.Name = "проДодатокToolStripMenuItem";
            this.проДодатокToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.проДодатокToolStripMenuItem.Text = "Про додаток...";
            this.проДодатокToolStripMenuItem.Click += new System.EventHandler(this.проДодатокToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // оглядToolStripMenuItem
            // 
            this.оглядToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прийомиToolStripMenuItem,
            this.пацієнтиToolStripMenuItem,
            this.лікаріToolStripMenuItem});
            this.оглядToolStripMenuItem.Name = "оглядToolStripMenuItem";
            this.оглядToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.оглядToolStripMenuItem.Text = "Огляд";
            // 
            // прийомиToolStripMenuItem
            // 
            this.прийомиToolStripMenuItem.Name = "прийомиToolStripMenuItem";
            this.прийомиToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.прийомиToolStripMenuItem.Text = "Прийоми";
            this.прийомиToolStripMenuItem.Click += new System.EventHandler(this.прийомиToolStripMenuItem_Click);
            // 
            // пацієнтиToolStripMenuItem
            // 
            this.пацієнтиToolStripMenuItem.Name = "пацієнтиToolStripMenuItem";
            this.пацієнтиToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.пацієнтиToolStripMenuItem.Text = "Пацієнти";
            this.пацієнтиToolStripMenuItem.Click += new System.EventHandler(this.пацієнтиToolStripMenuItem_Click);
            // 
            // лікаріToolStripMenuItem
            // 
            this.лікаріToolStripMenuItem.Name = "лікаріToolStripMenuItem";
            this.лікаріToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.лікаріToolStripMenuItem.Text = "Лікарі";
            this.лікаріToolStripMenuItem.Click += new System.EventHandler(this.лікаріToolStripMenuItem_Click);
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            this.довідкаToolStripMenuItem.Click += new System.EventHandler(this.довідкаToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAppointments,
            this.toolStripButtonPatients,
            this.toolStripButtonDoctors});
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip.Size = new System.Drawing.Size(928, 34);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAppointments
            // 
            this.toolStripButtonAppointments.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAppointments.Image")));
            this.toolStripButtonAppointments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAppointments.Name = "toolStripButtonAppointments";
            this.toolStripButtonAppointments.Size = new System.Drawing.Size(118, 29);
            this.toolStripButtonAppointments.Text = "Прийоми";
            this.toolStripButtonAppointments.ToolTipText = "Перегляд призначених прийомів";
            this.toolStripButtonAppointments.Click += new System.EventHandler(this.toolStripButtonAppointments_Click);
            // 
            // toolStripButtonPatients
            // 
            this.toolStripButtonPatients.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPatients.Image")));
            this.toolStripButtonPatients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPatients.Name = "toolStripButtonPatients";
            this.toolStripButtonPatients.Size = new System.Drawing.Size(112, 29);
            this.toolStripButtonPatients.Text = "Пацієнти";
            this.toolStripButtonPatients.ToolTipText = "Перегляд таблиці пацієнтів";
            this.toolStripButtonPatients.Click += new System.EventHandler(this.toolStripButtonPatients_Click);
            // 
            // toolStripButtonDoctors
            // 
            this.toolStripButtonDoctors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDoctors.Image")));
            this.toolStripButtonDoctors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDoctors.Name = "toolStripButtonDoctors";
            this.toolStripButtonDoctors.Size = new System.Drawing.Size(89, 29);
            this.toolStripButtonDoctors.Text = "Лікарі";
            this.toolStripButtonDoctors.ToolTipText = "Перегляд таблиці лікарів";
            this.toolStripButtonDoctors.Click += new System.EventHandler(this.toolStripButtonDoctors_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(25, 96);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(155, 37);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "HEADER";
            this.labelHeader.Visible = false;
            // 
            // panelToolAppointments
            // 
            this.panelToolAppointments.Controls.Add(this.buttonCancelApp);
            this.panelToolAppointments.Controls.Add(this.buttonNewApp);
            this.panelToolAppointments.Location = new System.Drawing.Point(225, 83);
            this.panelToolAppointments.Name = "panelToolAppointments";
            this.panelToolAppointments.Size = new System.Drawing.Size(382, 60);
            this.panelToolAppointments.TabIndex = 3;
            this.panelToolAppointments.Visible = false;
            // 
            // buttonCancelApp
            // 
            this.buttonCancelApp.BackColor = System.Drawing.Color.LightCoral;
            this.buttonCancelApp.Enabled = false;
            this.buttonCancelApp.Location = new System.Drawing.Point(197, 8);
            this.buttonCancelApp.Name = "buttonCancelApp";
            this.buttonCancelApp.Size = new System.Drawing.Size(170, 42);
            this.buttonCancelApp.TabIndex = 2;
            this.buttonCancelApp.Text = "Скасувати прийом";
            this.buttonCancelApp.UseVisualStyleBackColor = false;
            this.buttonCancelApp.Click += new System.EventHandler(this.buttonCancelApp_Click);
            // 
            // buttonNewApp
            // 
            this.buttonNewApp.Location = new System.Drawing.Point(15, 8);
            this.buttonNewApp.Name = "buttonNewApp";
            this.buttonNewApp.Size = new System.Drawing.Size(160, 42);
            this.buttonNewApp.TabIndex = 0;
            this.buttonNewApp.Text = "Новий прийом";
            this.buttonNewApp.UseVisualStyleBackColor = true;
            this.buttonNewApp.Click += new System.EventHandler(this.buttonNewApp_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Controls.Add(this.label1);
            this.panelSearch.Location = new System.Drawing.Point(627, 83);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(284, 60);
            this.panelSearch.TabIndex = 4;
            this.panelSearch.Visible = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(87, 8);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(182, 30);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пошук:";
            // 
            // buttonNewPat
            // 
            this.buttonNewPat.Location = new System.Drawing.Point(15, 8);
            this.buttonNewPat.Name = "buttonNewPat";
            this.buttonNewPat.Size = new System.Drawing.Size(160, 42);
            this.buttonNewPat.TabIndex = 0;
            this.buttonNewPat.Text = "Новий пацієнт";
            this.buttonNewPat.UseVisualStyleBackColor = true;
            this.buttonNewPat.Click += new System.EventHandler(this.buttonNewPat_Click);
            // 
            // buttonEditPat
            // 
            this.buttonEditPat.Enabled = false;
            this.buttonEditPat.Location = new System.Drawing.Point(198, 8);
            this.buttonEditPat.Name = "buttonEditPat";
            this.buttonEditPat.Size = new System.Drawing.Size(170, 42);
            this.buttonEditPat.TabIndex = 1;
            this.buttonEditPat.Text = "Редагувати...";
            this.buttonEditPat.UseVisualStyleBackColor = true;
            this.buttonEditPat.Click += new System.EventHandler(this.buttonEditPat_Click);
            // 
            // panelToolPatients
            // 
            this.panelToolPatients.Controls.Add(this.buttonEditPat);
            this.panelToolPatients.Controls.Add(this.buttonNewPat);
            this.panelToolPatients.Location = new System.Drawing.Point(225, 83);
            this.panelToolPatients.Name = "panelToolPatients";
            this.panelToolPatients.Size = new System.Drawing.Size(382, 60);
            this.panelToolPatients.TabIndex = 4;
            this.panelToolPatients.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 149);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(904, 583);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // Registrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 744);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelToolPatients);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelToolAppointments);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(950, 800);
            this.Name = "Registrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NedoDent Реєстратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registrator_FormClosing);
            this.Load += new System.EventHandler(this.Registrator_Load);
            this.Shown += new System.EventHandler(this.Registrator_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelToolAppointments.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelToolPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проДодатокToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оглядToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прийомиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пацієнтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лікаріToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonAppointments;
        private System.Windows.Forms.ToolStripButton toolStripButtonPatients;
        private System.Windows.Forms.ToolStripButton toolStripButtonDoctors;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelToolAppointments;
        private System.Windows.Forms.Button buttonNewApp;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNewPat;
        private System.Windows.Forms.Button buttonEditPat;
        private System.Windows.Forms.Panel panelToolPatients;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCancelApp;
    }
}

