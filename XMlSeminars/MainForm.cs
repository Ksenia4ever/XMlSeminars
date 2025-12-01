using Commands;
using Controllers;
using DataModel;

namespace XMlSeminars
{
    public partial class MainForm : Form
    {
        Parser? DocumentParser { get; set; } = null;
        AnalyzerType Analyzer { get; set; } = AnalyzerType.SAX;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
            UpdateType(AnalyzerType.SAX);
        }

        void OnLoadXml(object sender, EventArgs e)
        {
            try
            {
                var res = _openFileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var cmd = new LoadXmlCommand() { FilePath = _openFileDialog.FileName };
                    cmd.Execute();

                    if (cmd.Parser != null)
                    {
                        UpdateUI(cmd.Parser);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnGenerateRandom(object sender, EventArgs e)
        {
            try
            {
                var res = _saveFileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var gen = new SeminarGenerator();
                    var seminars = gen.CreateSeminars();

                    var cmd = new SaveXmlCommand()
                    {
                        FilePath = _saveFileDialog.FileName,
                        Seminars = seminars
                    };
                    cmd.Execute();

                    if (cmd.Parser != null)
                    {
                        UpdateUI(cmd.Parser);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnSAXType(object sender, EventArgs e)
        {
            try
            {
                UpdateType(AnalyzerType.SAX);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnLINQType(object sender, EventArgs e)
        {
            try
            {
                UpdateType(AnalyzerType.LINQ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnDOMType(object sender, EventArgs e)
        {
            try
            {
                UpdateType(AnalyzerType.DOM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnAnalyze(object sender, EventArgs e)
        {
            try
            {
                if (DocumentParser == null)
                {
                    MessageBox.Show("Please load or generate XML file", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var criteria = new List<Criteria?>()
                {
                    _criteriaControl1.Criteria,
                    _criteriaControl2.Criteria,
                    _criteriaControl3.Criteria,
                    _criteriaControl4.Criteria,
                    _criteriaControl5.Criteria,
                }
                .Where(c => c != null)
                .Cast<Criteria>()
                .ToList();

                var cmd = new AnalyzeCommand()
                {
                    Parser = DocumentParser,
                    Analyzer = Analyzer,
                    InputCriteria = criteria
                };
                cmd.Execute();

                if (cmd.Seminars != null)
                {
                    UpdateResult(cmd.Seminars);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnTransform(object sender, EventArgs e)
        {
            try
            {
                if (DocumentParser == null)
                {
                    MessageBox.Show("Please load or generate XML file", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var res = _saveHtmlFileDialog.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    var cmd = new TransformCommand()
                    {
                        SourceFile = DocumentParser.FilePath,
                        OutputFile = _saveHtmlFileDialog.FileName,
                    };

                    cmd.Execute();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void InitializeControls()
        {
            UpdateResult(new List<Seminar>());
        }

        void UpdateUI(Parser parser)
        {
            DocumentParser = parser;
            _criteriaControl1.Parser = parser;
            _criteriaControl2.Parser = parser;
            _criteriaControl3.Parser = parser;
            _criteriaControl4.Parser = parser;
            _criteriaControl5.Parser = parser;
        }

        void UpdateType(AnalyzerType analyzer)
        {
            Analyzer = analyzer;

            switch(Analyzer)
            {
                case AnalyzerType.SAX:
                    _SAXToolStripMenuItem.Checked = true;
                    _XMLLINQToolStripMenuItem.Checked = false;
                    _DOMToolStripMenuItem.Checked = false;
                    break;
                case AnalyzerType.LINQ:
                    _SAXToolStripMenuItem.Checked = false;
                    _XMLLINQToolStripMenuItem.Checked = true;
                    _DOMToolStripMenuItem.Checked = false;
                    break;
                case AnalyzerType.DOM:
                    _SAXToolStripMenuItem.Checked = false;
                    _XMLLINQToolStripMenuItem.Checked = false;
                    _DOMToolStripMenuItem.Checked = true;
                    break;
            }
        }

        void UpdateResult(List<Seminar> seminars)
        {
            var items = seminars.Select(s =>
            {
                var item = new ListViewItem(s.Topic);
                item.SubItems.AddRange(
                [
                    s.Description ?? string.Empty,
                    s.Cathedra ?? string.Empty,
                    $"{s.Faculty?.Department ?? string.Empty} ({s.Faculty?.Branch ?? string.Empty})",
                    s.Date?.ToString("d") ?? string.Empty,
                    $"{s.Header?.Surname ?? string.Empty} {s.Header?.Name ?? string.Empty}",
                ]);

                return item;
            });

            _resultView.Items.Clear();
            _resultView.Items.AddRange(items.ToArray());

            var totalWidth = _resultView.ClientSize.Width;
            var colWidth = totalWidth / _resultView.Columns.Count;

            foreach (ColumnHeader col in _resultView.Columns)
            {
                col.Width = colWidth;
            }
        }
    }
}
