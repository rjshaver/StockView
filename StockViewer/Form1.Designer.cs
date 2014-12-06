namespace StockViewer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxSymbol = new System.Windows.Forms.ComboBox();
            this.aLLSTOCKLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksDataSet = new StockViewer.StocksDataSet();
            this.labelSymbol = new System.Windows.Forms.Label();
            this.aLLSTOCKLISTTableAdapter = new StockViewer.StocksDataSetTableAdapters.ALLSTOCKLISTTableAdapter();
            this.labelSector = new System.Windows.Forms.Label();
            this.textBoxSector = new System.Windows.Forms.TextBox();
            this.labelIndustry = new System.Windows.Forms.Label();
            this.textBoxIndustry = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleMovingAveragesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EightDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FortyDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoHundredDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSimpleMovingAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStockViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelIPO = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelExchange = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aLLSTOCKDATABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLLSTOCKDATATableAdapter = new StockViewer.StocksDataSetTableAdapters.ALLSTOCKDATATableAdapter();
            this.statusStripStockView = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusStockView = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.aLLSTOCKLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLLSTOCKDATABindingSource)).BeginInit();
            this.statusStripStockView.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSymbol
            // 
            this.comboBoxSymbol.DataSource = this.aLLSTOCKLISTBindingSource;
            this.comboBoxSymbol.DisplayMember = "SYMBOL";
            this.comboBoxSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSymbol.FormattingEnabled = true;
            this.comboBoxSymbol.Location = new System.Drawing.Point(79, 27);
            this.comboBoxSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSymbol.Name = "comboBoxSymbol";
            this.comboBoxSymbol.Size = new System.Drawing.Size(112, 24);
            this.comboBoxSymbol.TabIndex = 0;
            this.comboBoxSymbol.SelectedIndexChanged += new System.EventHandler(this.comboBoxSymbol_SelectedIndexChanged);
            // 
            // aLLSTOCKLISTBindingSource
            // 
            this.aLLSTOCKLISTBindingSource.DataMember = "ALLSTOCKLIST";
            this.aLLSTOCKLISTBindingSource.DataSource = this.stocksDataSet;
            // 
            // stocksDataSet
            // 
            this.stocksDataSet.DataSetName = "StocksDataSet";
            this.stocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelSymbol
            // 
            this.labelSymbol.AutoSize = true;
            this.labelSymbol.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSymbol.Location = new System.Drawing.Point(13, 31);
            this.labelSymbol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSymbol.Name = "labelSymbol";
            this.labelSymbol.Size = new System.Drawing.Size(58, 17);
            this.labelSymbol.TabIndex = 1;
            this.labelSymbol.Text = "Symbol:";
            // 
            // aLLSTOCKLISTTableAdapter
            // 
            this.aLLSTOCKLISTTableAdapter.ClearBeforeFill = true;
            // 
            // labelSector
            // 
            this.labelSector.AutoSize = true;
            this.labelSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSector.Location = new System.Drawing.Point(213, 31);
            this.labelSector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSector.Name = "labelSector";
            this.labelSector.Size = new System.Drawing.Size(60, 17);
            this.labelSector.TabIndex = 2;
            this.labelSector.Text = "Sector:";
            // 
            // textBoxSector
            // 
            this.textBoxSector.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aLLSTOCKLISTBindingSource, "SECTOR", true));
            this.textBoxSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSector.Location = new System.Drawing.Point(281, 28);
            this.textBoxSector.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSector.Name = "textBoxSector";
            this.textBoxSector.Size = new System.Drawing.Size(295, 23);
            this.textBoxSector.TabIndex = 3;
            // 
            // labelIndustry
            // 
            this.labelIndustry.AutoSize = true;
            this.labelIndustry.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndustry.Location = new System.Drawing.Point(603, 32);
            this.labelIndustry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIndustry.Name = "labelIndustry";
            this.labelIndustry.Size = new System.Drawing.Size(66, 17);
            this.labelIndustry.TabIndex = 4;
            this.labelIndustry.Text = "Industry:";
            // 
            // textBoxIndustry
            // 
            this.textBoxIndustry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aLLSTOCKLISTBindingSource, "INDUSTRY", true));
            this.textBoxIndustry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIndustry.Location = new System.Drawing.Point(677, 28);
            this.textBoxIndustry.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIndustry.Name = "textBoxIndustry";
            this.textBoxIndustry.Size = new System.Drawing.Size(333, 23);
            this.textBoxIndustry.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.indicatorsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1346, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // indicatorsToolStripMenuItem
            // 
            this.indicatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleMovingAveragesToolStripMenuItem});
            this.indicatorsToolStripMenuItem.Name = "indicatorsToolStripMenuItem";
            this.indicatorsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.indicatorsToolStripMenuItem.Text = "Indicators";
            this.indicatorsToolStripMenuItem.Click += new System.EventHandler(this.indicatorsToolStripMenuItem_Click);
            // 
            // simpleMovingAveragesToolStripMenuItem
            // 
            this.simpleMovingAveragesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EightDayToolStripMenuItem,
            this.FortyDayToolStripMenuItem,
            this.TwoHundredDayToolStripMenuItem,
            this.addNewSimpleMovingAverageToolStripMenuItem});
            this.simpleMovingAveragesToolStripMenuItem.Name = "simpleMovingAveragesToolStripMenuItem";
            this.simpleMovingAveragesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.simpleMovingAveragesToolStripMenuItem.Text = "Simple Moving Averages";
            // 
            // EightDayToolStripMenuItem
            // 
            this.EightDayToolStripMenuItem.Name = "EightDayToolStripMenuItem";
            this.EightDayToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.EightDayToolStripMenuItem.Text = "8 day";
            this.EightDayToolStripMenuItem.Click += new System.EventHandler(this.EightDayToolStripMenuItem_Click);
            // 
            // FortyDayToolStripMenuItem
            // 
            this.FortyDayToolStripMenuItem.Name = "FortyDayToolStripMenuItem";
            this.FortyDayToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.FortyDayToolStripMenuItem.Text = "40 day";
            this.FortyDayToolStripMenuItem.Click += new System.EventHandler(this.FortydayToolStripMenuItem_Click);
            // 
            // TwoHundredDayToolStripMenuItem
            // 
            this.TwoHundredDayToolStripMenuItem.Name = "TwoHundredDayToolStripMenuItem";
            this.TwoHundredDayToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.TwoHundredDayToolStripMenuItem.Text = "200 day";
            this.TwoHundredDayToolStripMenuItem.Click += new System.EventHandler(this.TwoHundreddayToolStripMenuItem_Click);
            // 
            // addNewSimpleMovingAverageToolStripMenuItem
            // 
            this.addNewSimpleMovingAverageToolStripMenuItem.Name = "addNewSimpleMovingAverageToolStripMenuItem";
            this.addNewSimpleMovingAverageToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addNewSimpleMovingAverageToolStripMenuItem.Text = "Add New";
            this.addNewSimpleMovingAverageToolStripMenuItem.Click += new System.EventHandler(this.addNewSimpleMovingAverageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutStockViewerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutStockViewerToolStripMenuItem
            // 
            this.aboutStockViewerToolStripMenuItem.Name = "aboutStockViewerToolStripMenuItem";
            this.aboutStockViewerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aboutStockViewerToolStripMenuItem.Text = "About Stock Viewer";
            // 
            // labelIPO
            // 
            this.labelIPO.AutoSize = true;
            this.labelIPO.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPO.Location = new System.Drawing.Point(1017, 31);
            this.labelIPO.Name = "labelIPO";
            this.labelIPO.Size = new System.Drawing.Size(38, 17);
            this.labelIPO.TabIndex = 8;
            this.labelIPO.Text = "IPO:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aLLSTOCKLISTBindingSource, "IPOYEAR", true));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1056, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 23);
            this.textBox1.TabIndex = 9;
            // 
            // labelExchange
            // 
            this.labelExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelExchange.AutoSize = true;
            this.labelExchange.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExchange.Location = new System.Drawing.Point(1140, 31);
            this.labelExchange.Name = "labelExchange";
            this.labelExchange.Size = new System.Drawing.Size(71, 17);
            this.labelExchange.TabIndex = 10;
            this.labelExchange.Text = "Exchange:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aLLSTOCKLISTBindingSource, "EXCHANGE", true));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(1212, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 23);
            this.textBox2.TabIndex = 11;
            // 
            // chartStock
            // 
            this.chartStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartStock.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.AlignWithChartArea = "ChartAreaVolume";
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.Format = "C";
            chartArea1.AxisY.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisY.MaximumAutoSize = 35F;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartAreaPrice";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 70F;
            chartArea1.Position.Width = 90F;
            chartArea1.Position.X = 3F;
            chartArea2.AlignWithChartArea = "ChartAreaPrice";
            chartArea2.AxisY.LabelStyle.Format = "E2";
            chartArea2.Name = "ChartAreaVolume";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 30F;
            chartArea2.Position.Width = 90F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 63F;
            this.chartStock.ChartAreas.Add(chartArea1);
            this.chartStock.ChartAreas.Add(chartArea2);
            this.chartStock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chartStock.DataSource = this.aLLSTOCKDATABindingSource;
            this.chartStock.Location = new System.Drawing.Point(1, 52);
            this.chartStock.Margin = new System.Windows.Forms.Padding(0);
            this.chartStock.Name = "chartStock";
            series1.ChartArea = "ChartAreaPrice";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.Name = "SeriesPrice";
            series1.XValueMember = "DATE";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "HIGH, LOW, OPEN, CLOSE";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartAreaVolume";
            series2.Name = "SeriesVolume";
            series2.XValueMember = "DATE";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "VOLUME";
            this.chartStock.Series.Add(series1);
            this.chartStock.Series.Add(series2);
            this.chartStock.Size = new System.Drawing.Size(1346, 602);
            this.chartStock.TabIndex = 12;
            this.chartStock.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chartStock_AxisViewChanged);
            this.chartStock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartStock_MouseDown);
            this.chartStock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartStock_MouseMove);
            // 
            // aLLSTOCKDATABindingSource
            // 
            this.aLLSTOCKDATABindingSource.DataMember = "ALLSTOCKDATA";
            this.aLLSTOCKDATABindingSource.DataSource = this.stocksDataSet;
            // 
            // aLLSTOCKDATATableAdapter
            // 
            this.aLLSTOCKDATATableAdapter.ClearBeforeFill = true;
            // 
            // statusStripStockView
            // 
            this.statusStripStockView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusStockView});
            this.statusStripStockView.Location = new System.Drawing.Point(0, 657);
            this.statusStripStockView.Name = "statusStripStockView";
            this.statusStripStockView.Size = new System.Drawing.Size(1346, 22);
            this.statusStripStockView.TabIndex = 13;
            this.statusStripStockView.Text = "Ready";
            // 
            // toolStripStatusStockView
            // 
            this.toolStripStatusStockView.Name = "toolStripStatusStockView";
            this.toolStripStatusStockView.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusStockView.Text = "toolStrip Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 679);
            this.Controls.Add(this.statusStripStockView);
            this.Controls.Add(this.chartStock);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelExchange);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelIPO);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBoxIndustry);
            this.Controls.Add(this.labelIndustry);
            this.Controls.Add(this.textBoxSector);
            this.Controls.Add(this.labelSector);
            this.Controls.Add(this.labelSymbol);
            this.Controls.Add(this.comboBoxSymbol);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aLLSTOCKLISTBindingSource, "NAME", true));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Stock Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aLLSTOCKLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLLSTOCKDATABindingSource)).EndInit();
            this.statusStripStockView.ResumeLayout(false);
            this.statusStripStockView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSymbol;
        private System.Windows.Forms.Label labelSymbol;
        private StocksDataSet stocksDataSet;
        private System.Windows.Forms.BindingSource aLLSTOCKLISTBindingSource;
        private StocksDataSetTableAdapters.ALLSTOCKLISTTableAdapter aLLSTOCKLISTTableAdapter;
        private System.Windows.Forms.Label labelSector;
        private System.Windows.Forms.TextBox textBoxSector;
        private System.Windows.Forms.Label labelIndustry;
        private System.Windows.Forms.TextBox textBoxIndustry;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indicatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutStockViewerToolStripMenuItem;
        private System.Windows.Forms.Label labelIPO;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelExchange;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingSource aLLSTOCKDATABindingSource;
        private StocksDataSetTableAdapters.ALLSTOCKDATATableAdapter aLLSTOCKDATATableAdapter;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private System.Windows.Forms.ToolStripMenuItem simpleMovingAveragesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EightDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSimpleMovingAverageToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripStockView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusStockView;
        private System.Windows.Forms.ToolStripMenuItem FortyDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TwoHundredDayToolStripMenuItem;
    }
}

