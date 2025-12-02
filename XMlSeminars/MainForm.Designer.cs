namespace XMlSeminars
{
    partial class MainForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            _criteriaControl1 = new CriteriaControl();
            _criteriaControl2 = new CriteriaControl();
            _criteriaControl3 = new CriteriaControl();
            _criteriaControl4 = new CriteriaControl();
            _criteriaControl5 = new CriteriaControl();
            _resultView = new ListView();
            _topicColumn = new ColumnHeader();
            _descriptionColumn = new ColumnHeader();
            _cathedraColumn = new ColumnHeader();
            _facultyColumn = new ColumnHeader();
            _dateColumn = new ColumnHeader();
            _headerColumn = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            loadXMLToolStripMenuItem = new ToolStripMenuItem();
            generateRandomXMLToolStripMenuItem = new ToolStripMenuItem();
            typeToolStripMenuItem = new ToolStripMenuItem();
            _SAXToolStripMenuItem = new ToolStripMenuItem();
            _XMLLINQToolStripMenuItem = new ToolStripMenuItem();
            _DOMToolStripMenuItem = new ToolStripMenuItem();
            analyzeToolStripMenuItem = new ToolStripMenuItem();
            executeToolStripMenuItem = new ToolStripMenuItem();
            transformToHTMToolStripMenuItem = new ToolStripMenuItem();
            executeToolStripMenuItem1 = new ToolStripMenuItem();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            _saveHtmlFileDialog = new SaveFileDialog();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(_criteriaControl1, 0, 0);
            tableLayoutPanel1.Controls.Add(_criteriaControl2, 0, 1);
            tableLayoutPanel1.Controls.Add(_criteriaControl3, 0, 2);
            tableLayoutPanel1.Controls.Add(_criteriaControl4, 0, 3);
            tableLayoutPanel1.Controls.Add(_criteriaControl5, 0, 4);
            tableLayoutPanel1.Controls.Add(_resultView, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(1116, 520);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // _criteriaControl1
            // 
            _criteriaControl1.AutoSize = true;
            _criteriaControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _criteriaControl1.Dock = DockStyle.Fill;
            _criteriaControl1.Location = new Point(3, 2);
            _criteriaControl1.Margin = new Padding(3, 2, 3, 2);
            _criteriaControl1.MinimumSize = new Size(175, 30);
            _criteriaControl1.Name = "_criteriaControl1";
            _criteriaControl1.Parser = null;
            _criteriaControl1.Size = new Size(1110, 30);
            _criteriaControl1.TabIndex = 2;
            // 
            // _criteriaControl2
            // 
            _criteriaControl2.AutoSize = true;
            _criteriaControl2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _criteriaControl2.Dock = DockStyle.Fill;
            _criteriaControl2.Location = new Point(3, 36);
            _criteriaControl2.Margin = new Padding(3, 2, 3, 2);
            _criteriaControl2.MinimumSize = new Size(175, 30);
            _criteriaControl2.Name = "_criteriaControl2";
            _criteriaControl2.Parser = null;
            _criteriaControl2.Size = new Size(1110, 30);
            _criteriaControl2.TabIndex = 2;
            // 
            // _criteriaControl3
            // 
            _criteriaControl3.AutoSize = true;
            _criteriaControl3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _criteriaControl3.Dock = DockStyle.Fill;
            _criteriaControl3.Location = new Point(3, 70);
            _criteriaControl3.Margin = new Padding(3, 2, 3, 2);
            _criteriaControl3.MinimumSize = new Size(175, 30);
            _criteriaControl3.Name = "_criteriaControl3";
            _criteriaControl3.Parser = null;
            _criteriaControl3.Size = new Size(1110, 30);
            _criteriaControl3.TabIndex = 2;
            // 
            // _criteriaControl4
            // 
            _criteriaControl4.AutoSize = true;
            _criteriaControl4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _criteriaControl4.Dock = DockStyle.Fill;
            _criteriaControl4.Location = new Point(3, 104);
            _criteriaControl4.Margin = new Padding(3, 2, 3, 2);
            _criteriaControl4.MinimumSize = new Size(175, 30);
            _criteriaControl4.Name = "_criteriaControl4";
            _criteriaControl4.Parser = null;
            _criteriaControl4.Size = new Size(1110, 30);
            _criteriaControl4.TabIndex = 2;
            // 
            // _criteriaControl5
            // 
            _criteriaControl5.AutoSize = true;
            _criteriaControl5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _criteriaControl5.Dock = DockStyle.Fill;
            _criteriaControl5.Location = new Point(3, 138);
            _criteriaControl5.Margin = new Padding(3, 2, 3, 2);
            _criteriaControl5.MinimumSize = new Size(175, 30);
            _criteriaControl5.Name = "_criteriaControl5";
            _criteriaControl5.Parser = null;
            _criteriaControl5.Size = new Size(1110, 30);
            _criteriaControl5.TabIndex = 2;
            // 
            // _resultView
            // 
            _resultView.Columns.AddRange(new ColumnHeader[] { _topicColumn, _descriptionColumn, _cathedraColumn, _facultyColumn, _dateColumn, _headerColumn });
            _resultView.Dock = DockStyle.Fill;
            _resultView.FullRowSelect = true;
            _resultView.LabelWrap = false;
            _resultView.Location = new Point(3, 172);
            _resultView.Margin = new Padding(3, 2, 3, 2);
            _resultView.MultiSelect = false;
            _resultView.Name = "_resultView";
            _resultView.Size = new Size(1110, 346);
            _resultView.TabIndex = 4;
            _resultView.UseCompatibleStateImageBehavior = false;
            _resultView.View = View.Details;
            // 
            // _topicColumn
            // 
            _topicColumn.Text = "Topic";
            // 
            // _descriptionColumn
            // 
            _descriptionColumn.Text = "Description";
            // 
            // _cathedraColumn
            // 
            _cathedraColumn.Text = "Cathedra";
            // 
            // _facultyColumn
            // 
            _facultyColumn.Text = "Faculty";
            // 
            // _dateColumn
            // 
            _dateColumn.Text = "Date";
            // 
            // _headerColumn
            // 
            _headerColumn.Text = "Header";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { xMLToolStripMenuItem, analyzeToolStripMenuItem, transformToHTMToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1116, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // xMLToolStripMenuItem
            // 
            xMLToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadXMLToolStripMenuItem, generateRandomXMLToolStripMenuItem, typeToolStripMenuItem });
            xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            xMLToolStripMenuItem.Size = new Size(43, 20);
            xMLToolStripMenuItem.Text = "XML";
            // 
            // loadXMLToolStripMenuItem
            // 
            loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
            loadXMLToolStripMenuItem.Size = new Size(193, 22);
            loadXMLToolStripMenuItem.Text = "Load XML";
            loadXMLToolStripMenuItem.Click += OnLoadXml;
            // 
            // generateRandomXMLToolStripMenuItem
            // 
            generateRandomXMLToolStripMenuItem.Name = "generateRandomXMLToolStripMenuItem";
            generateRandomXMLToolStripMenuItem.Size = new Size(193, 22);
            generateRandomXMLToolStripMenuItem.Text = "Generate random XML";
            generateRandomXMLToolStripMenuItem.Click += OnGenerateRandom;
            // 
            // typeToolStripMenuItem
            // 
            typeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _SAXToolStripMenuItem, _XMLLINQToolStripMenuItem, _DOMToolStripMenuItem });
            typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            typeToolStripMenuItem.Size = new Size(193, 22);
            typeToolStripMenuItem.Text = "Type";
            // 
            // _SAXToolStripMenuItem
            // 
            _SAXToolStripMenuItem.Name = "_SAXToolStripMenuItem";
            _SAXToolStripMenuItem.Size = new Size(128, 22);
            _SAXToolStripMenuItem.Text = "SAX";
            _SAXToolStripMenuItem.Click += OnSAXType;
            // 
            // _XMLLINQToolStripMenuItem
            // 
            _XMLLINQToolStripMenuItem.Name = "_XMLLINQToolStripMenuItem";
            _XMLLINQToolStripMenuItem.Size = new Size(128, 22);
            _XMLLINQToolStripMenuItem.Text = "XML LINQ";
            _XMLLINQToolStripMenuItem.Click += OnLINQType;
            // 
            // _DOMToolStripMenuItem
            // 
            _DOMToolStripMenuItem.Name = "_DOMToolStripMenuItem";
            _DOMToolStripMenuItem.Size = new Size(128, 22);
            _DOMToolStripMenuItem.Text = "DOM";
            _DOMToolStripMenuItem.Click += OnDOMType;
            // 
            // analyzeToolStripMenuItem
            // 
            analyzeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { executeToolStripMenuItem });
            analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            analyzeToolStripMenuItem.Size = new Size(60, 20);
            analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // executeToolStripMenuItem
            // 
            executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            executeToolStripMenuItem.Size = new Size(115, 22);
            executeToolStripMenuItem.Text = "Execute";
            executeToolStripMenuItem.Click += OnAnalyze;
            // 
            // transformToHTMToolStripMenuItem
            // 
            transformToHTMToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { executeToolStripMenuItem1 });
            transformToHTMToolStripMenuItem.Name = "transformToHTMToolStripMenuItem";
            transformToHTMToolStripMenuItem.Size = new Size(118, 20);
            transformToHTMToolStripMenuItem.Text = "Transform to HTM:";
            // 
            // executeToolStripMenuItem1
            // 
            executeToolStripMenuItem1.Name = "executeToolStripMenuItem1";
            executeToolStripMenuItem1.Size = new Size(115, 22);
            executeToolStripMenuItem1.Text = "Execute";
            executeToolStripMenuItem1.Click += OnTransform;
            // 
            // _openFileDialog
            // 
            _openFileDialog.DefaultExt = "xml";
            _openFileDialog.FileName = "Seminars.xml";
            _openFileDialog.Filter = "XML files|*.xml";
            _openFileDialog.Title = "Load Seminars";
            // 
            // _saveFileDialog
            // 
            _saveFileDialog.DefaultExt = "xml";
            _saveFileDialog.FileName = "Seminars.xml";
            _saveFileDialog.Filter = "XML files|*.xml";
            _saveFileDialog.Title = "Save Seminars";
            // 
            // _saveHtmlFileDialog
            // 
            _saveHtmlFileDialog.DefaultExt = "htm";
            _saveHtmlFileDialog.FileName = "SeminarsTransform.htm";
            _saveHtmlFileDialog.Filter = "HTML files|*.htm";
            _saveHtmlFileDialog.Title = "Save HTML Seminars";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 544);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(562, 370);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CriteriaControl _criteriaControl1;
        private CriteriaControl _criteriaControl2;
        private CriteriaControl _criteriaControl3;
        private CriteriaControl _criteriaControl4;
        private CriteriaControl _criteriaControl5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem analyzeToolStripMenuItem;
        private ToolStripMenuItem executeToolStripMenuItem;
        private ToolStripMenuItem transformToHTMToolStripMenuItem;
        private ListView _resultView;
        private OpenFileDialog _openFileDialog;
        private ToolStripMenuItem xMLToolStripMenuItem;
        private ToolStripMenuItem loadXMLToolStripMenuItem;
        private ToolStripMenuItem generateRandomXMLToolStripMenuItem;
        private SaveFileDialog _saveFileDialog;
        private ToolStripMenuItem typeToolStripMenuItem;
        private ToolStripMenuItem _SAXToolStripMenuItem;
        private ToolStripMenuItem _XMLLINQToolStripMenuItem;
        private ToolStripMenuItem _DOMToolStripMenuItem;
        private ToolStripMenuItem executeToolStripMenuItem1;
        private SaveFileDialog _saveHtmlFileDialog;
        private ColumnHeader _topicColumn;
        private ColumnHeader _descriptionColumn;
        private ColumnHeader _dateColumn;
        private ColumnHeader _cathedraColumn;
        private ColumnHeader _facultyColumn;
        private ColumnHeader _headerColumn;
    }
}