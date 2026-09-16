namespace Supervisor
{
    partial class Supervisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supervisor));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проДодатокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оглядToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лікаріToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.послугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїПослугToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїПацієнтівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категоріїСкладностіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartYearDoctors = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.chartYearIncomeDoctor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDoctors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.buttonShow2Chart = new System.Windows.Forms.Button();
            this.buttonShow1Chart = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearDoctors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearIncomeDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Honeydew;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonReload});
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip.Size = new System.Drawing.Size(928, 33);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReload.Image")));
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(34, 28);
            this.toolStripButtonReload.Text = "Оновити статистику";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.системаToolStripMenuItem,
            this.оглядToolStripMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(928, 33);
            this.menuStrip.TabIndex = 2;
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
            this.лікаріToolStripMenuItem,
            this.послугиToolStripMenuItem,
            this.категоріїПослугToolStripMenuItem,
            this.категоріїПацієнтівToolStripMenuItem,
            this.категоріїСкладностіToolStripMenuItem});
            this.оглядToolStripMenuItem.Name = "оглядToolStripMenuItem";
            this.оглядToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.оглядToolStripMenuItem.Text = "Огляд";
            // 
            // лікаріToolStripMenuItem
            // 
            this.лікаріToolStripMenuItem.Name = "лікаріToolStripMenuItem";
            this.лікаріToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.лікаріToolStripMenuItem.Text = "Лікарі";
            this.лікаріToolStripMenuItem.Click += new System.EventHandler(this.лікаріToolStripMenuItem_Click);
            // 
            // послугиToolStripMenuItem
            // 
            this.послугиToolStripMenuItem.Name = "послугиToolStripMenuItem";
            this.послугиToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.послугиToolStripMenuItem.Text = "Послуги";
            this.послугиToolStripMenuItem.Click += new System.EventHandler(this.послугиToolStripMenuItem_Click);
            // 
            // категоріїПослугToolStripMenuItem
            // 
            this.категоріїПослугToolStripMenuItem.Name = "категоріїПослугToolStripMenuItem";
            this.категоріїПослугToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.категоріїПослугToolStripMenuItem.Text = "Категорії послуг";
            this.категоріїПослугToolStripMenuItem.Click += new System.EventHandler(this.категоріїПослугToolStripMenuItem_Click);
            // 
            // категоріїПацієнтівToolStripMenuItem
            // 
            this.категоріїПацієнтівToolStripMenuItem.Name = "категоріїПацієнтівToolStripMenuItem";
            this.категоріїПацієнтівToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.категоріїПацієнтівToolStripMenuItem.Text = "Категорії пацієнтів";
            this.категоріїПацієнтівToolStripMenuItem.Click += new System.EventHandler(this.категоріїПацієнтівToolStripMenuItem_Click);
            // 
            // категоріїСкладностіToolStripMenuItem
            // 
            this.категоріїСкладностіToolStripMenuItem.Name = "категоріїСкладностіToolStripMenuItem";
            this.категоріїСкладностіToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.категоріїСкладностіToolStripMenuItem.Text = "Категорії складності";
            this.категоріїСкладностіToolStripMenuItem.Click += new System.EventHandler(this.категоріїСкладностіToolStripMenuItem_Click);
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            this.довідкаToolStripMenuItem.Click += new System.EventHandler(this.довідкаToolStripMenuItem_Click);
            // 
            // chartYearDoctors
            // 
            this.chartYearDoctors.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.chartYearDoctors.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartYearDoctors.Legends.Add(legend1);
            this.chartYearDoctors.Location = new System.Drawing.Point(287, 86);
            this.chartYearDoctors.Name = "chartYearDoctors";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chartYearDoctors.Series.Add(series1);
            this.chartYearDoctors.Size = new System.Drawing.Size(641, 325);
            this.chartYearDoctors.TabIndex = 4;
            this.chartYearDoctors.Text = "chart1";
            title1.Name = "Title";
            title1.Text = "Співвідношення річного обсягу наданих послуг лікарями клініки у гривневому еквіва" +
    "ленті";
            this.chartYearDoctors.Titles.Add(title1);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Оберіть рік";
            // 
            // chartYearIncomeDoctor
            // 
            this.chartYearIncomeDoctor.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.chartYearIncomeDoctor.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartYearIncomeDoctor.Legends.Add(legend2);
            this.chartYearIncomeDoctor.Location = new System.Drawing.Point(287, 408);
            this.chartYearIncomeDoctor.Name = "chartYearIncomeDoctor";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartYearIncomeDoctor.Series.Add(series2);
            this.chartYearIncomeDoctor.Size = new System.Drawing.Size(641, 303);
            this.chartYearIncomeDoctor.TabIndex = 7;
            this.chartYearIncomeDoctor.Text = "chart2";
            title2.Name = "Title";
            title2.Text = "Сума наданих послуг обраним лікарем за кожний місяць вибраного року";
            this.chartYearIncomeDoctor.Titles.Add(title2);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Оберіть рік";
            // 
            // comboBoxDoctors
            // 
            this.comboBoxDoctors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctors.FormattingEnabled = true;
            this.comboBoxDoctors.Location = new System.Drawing.Point(29, 555);
            this.comboBoxDoctors.Name = "comboBoxDoctors";
            this.comboBoxDoctors.Size = new System.Drawing.Size(249, 28);
            this.comboBoxDoctors.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Оберіть лікаря";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(158, 194);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(158, 484);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown2.TabIndex = 13;
            // 
            // buttonShow2Chart
            // 
            this.buttonShow2Chart.Location = new System.Drawing.Point(166, 605);
            this.buttonShow2Chart.Name = "buttonShow2Chart";
            this.buttonShow2Chart.Size = new System.Drawing.Size(110, 40);
            this.buttonShow2Chart.TabIndex = 14;
            this.buttonShow2Chart.Text = "Показати";
            this.buttonShow2Chart.UseVisualStyleBackColor = true;
            this.buttonShow2Chart.Click += new System.EventHandler(this.buttonShow2Chart_Click);
            // 
            // buttonShow1Chart
            // 
            this.buttonShow1Chart.Location = new System.Drawing.Point(166, 253);
            this.buttonShow1Chart.Name = "buttonShow1Chart";
            this.buttonShow1Chart.Size = new System.Drawing.Size(110, 40);
            this.buttonShow1Chart.TabIndex = 15;
            this.buttonShow1Chart.Text = "Показати";
            this.buttonShow1Chart.UseVisualStyleBackColor = true;
            this.buttonShow1Chart.Click += new System.EventHandler(this.buttonShow1Chart_Click);
            // 
            // Supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 744);
            this.Controls.Add(this.buttonShow1Chart);
            this.Controls.Add(this.buttonShow2Chart);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBoxDoctors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartYearIncomeDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartYearDoctors);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 800);
            this.Name = "Supervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NedoDent Керівник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Supervisor_FormClosing);
            this.Load += new System.EventHandler(this.Supervisor_Load);
            this.Shown += new System.EventHandler(this.Supervisor_Shown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearDoctors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearIncomeDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проДодатокToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оглядToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лікаріToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem послугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категоріїПослугToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категоріїПацієнтівToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYearDoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYearIncomeDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button buttonShow2Chart;
        private System.Windows.Forms.Button buttonShow1Chart;
        private System.Windows.Forms.ToolStripMenuItem категоріїСкладностіToolStripMenuItem;
    }
}

