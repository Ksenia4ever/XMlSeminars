using Controllers;
using DataModel;
using System.Diagnostics;

namespace XMlSeminars
{
    public partial class CriteriaControl : UserControl
    {
        public Parser? Parser
        {
            get => _parser;
            set
            {
                if (value != _parser)
                {
                    _parser = value;
                    UpdateControls();
                }
            }
        }

        public Criteria? Criteria => BuildCriteria();

        public CriteriaControl()
        {
            InitializeComponent();
            InitializeControls();
            UpdateControls();
        }

        void InitializeControls()
        {
            _attributeComboBox.DataSource = Enum.GetValues(typeof(DataModel.Attribute));
            _attributeComboBox.SelectedIndex = 0;

            _sortComboBox.DataSource = Enum.GetValues(typeof(DataModel.SortOrder));
            _sortComboBox.SelectedIndex = 0;
        }

        void OnAttributeChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        void OnCheckCriteria(object sender, EventArgs e)
        {
            UpdateControls();
        }

        void UpdateControls()
        {
            var active = Parser != null;

            _tableLayoutPanel.SuspendLayout();

            var enabled = active && _useCheckBox.Checked;
            _useCheckBox.Enabled = active;
            _attributeComboBox.Enabled = enabled;
            _sortComboBox.Enabled = enabled;
            _fromDateTimePicker.Enabled = enabled;
            _toDateTimePicker.Enabled = enabled;
            _textValueComboBox.Enabled = enabled;

            var criteria = new Criteria() { Attribute = (DataModel.Attribute)_attributeComboBox.SelectedIndex };
            _fromDateTimePicker.Visible = criteria.IsDateAttribute;
            _toDateTimePicker.Visible = criteria.IsDateAttribute;
            _textValueComboBox.Visible = criteria.IsTextAttribute;

            if (active && criteria.IsTextAttribute)
            {
                var options = Parser!.GetOptions(criteria.Attribute);
                _textValueComboBox.Items.Clear();
                _textValueComboBox.Items.AddRange(options.ToArray());
                _textValueComboBox.Text = string.Empty;
            }

            _tableLayoutPanel.ColumnStyles[1].SizeType = SizeType.Percent;
            _tableLayoutPanel.ColumnStyles[1].Width = 30;

            if (criteria.IsTextAttribute)
            {
                _tableLayoutPanel.ColumnStyles[2].SizeType = SizeType.Percent;
                _tableLayoutPanel.ColumnStyles[2].Width = 70;

                _tableLayoutPanel.ColumnStyles[3].SizeType = SizeType.Absolute;
                _tableLayoutPanel.ColumnStyles[3].Width = 0;

                _tableLayoutPanel.ColumnStyles[4].SizeType = SizeType.Absolute;
                _tableLayoutPanel.ColumnStyles[4].Width = 0;
            }
            else if (criteria.IsDateAttribute)
            {
                _tableLayoutPanel.ColumnStyles[2].SizeType = SizeType.Absolute;
                _tableLayoutPanel.ColumnStyles[2].Width = 0;

                _tableLayoutPanel.ColumnStyles[3].SizeType = SizeType.Percent;
                _tableLayoutPanel.ColumnStyles[3].Width = 35;

                _tableLayoutPanel.ColumnStyles[4].SizeType = SizeType.Percent;
                _tableLayoutPanel.ColumnStyles[4].Width = 35;
            }
            else
            {
                Debug.Assert(false);
            }

            _tableLayoutPanel.ResumeLayout();
        }

        Criteria? BuildCriteria()
        {
            var active = Parser != null;
            var enabled = active && _useCheckBox.Checked;
            if (!enabled)
            {
                return null; 
            }

            var criteria = new Criteria()
            {
                Attribute = (DataModel.Attribute)_attributeComboBox.SelectedIndex,
                SortSetting = (DataModel.SortOrder)_sortComboBox.SelectedIndex,
            };

            if (criteria.IsTextAttribute)
            {
                criteria.TextValue = _textValueComboBox.Text;
            }
            else if (criteria.IsDateAttribute)
            {
                var val1 = _fromDateTimePicker.Value;
                var val2 = _toDateTimePicker.Value;

                criteria.FromDateValue = val1 < val2 ? val1 : val2;
                criteria.ToDateValue = val1 < val2 ? val2 : val1;
            }
            else
            {
                Debug.Assert(false);
            }

            return criteria;
        }

        Parser? _parser = null;
    }
}
