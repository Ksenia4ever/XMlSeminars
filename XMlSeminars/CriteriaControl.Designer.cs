namespace XMlSeminars
{
    partial class CriteriaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _attributeComboBox = new ComboBox();
            _tableLayoutPanel = new TableLayoutPanel();
            _textValueComboBox = new ComboBox();
            _fromDateTimePicker = new DateTimePicker();
            _sortComboBox = new ComboBox();
            _toDateTimePicker = new DateTimePicker();
            _useCheckBox = new CheckBox();
            _tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _attributeComboBox
            // 
            _attributeComboBox.Dock = DockStyle.Fill;
            _attributeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _attributeComboBox.FormattingEnabled = true;
            _attributeComboBox.Location = new Point(103, 5);
            _attributeComboBox.Margin = new Padding(3, 5, 3, 3);
            _attributeComboBox.Name = "_attributeComboBox";
            _attributeComboBox.Size = new Size(129, 28);
            _attributeComboBox.TabIndex = 1;
            _attributeComboBox.SelectedIndexChanged += OnAttributeChanged;
            // 
            // _tableLayoutPanel
            // 
            _tableLayoutPanel.ColumnCount = 6;
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846159F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2051277F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2051277F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.2051277F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            _tableLayoutPanel.Controls.Add(_textValueComboBox, 2, 0);
            _tableLayoutPanel.Controls.Add(_attributeComboBox, 1, 0);
            _tableLayoutPanel.Controls.Add(_fromDateTimePicker, 3, 0);
            _tableLayoutPanel.Controls.Add(_sortComboBox, 5, 0);
            _tableLayoutPanel.Controls.Add(_toDateTimePicker, 4, 0);
            _tableLayoutPanel.Controls.Add(_useCheckBox, 0, 0);
            _tableLayoutPanel.Dock = DockStyle.Fill;
            _tableLayoutPanel.Location = new Point(0, 0);
            _tableLayoutPanel.Name = "_tableLayoutPanel";
            _tableLayoutPanel.RowCount = 1;
            _tableLayoutPanel.RowStyles.Add(new RowStyle());
            _tableLayoutPanel.Size = new Size(1140, 43);
            _tableLayoutPanel.TabIndex = 1;
            // 
            // _textValueComboBox
            // 
            _textValueComboBox.Dock = DockStyle.Fill;
            _textValueComboBox.FormattingEnabled = true;
            _textValueComboBox.Location = new Point(238, 5);
            _textValueComboBox.Margin = new Padding(3, 5, 3, 3);
            _textValueComboBox.Name = "_textValueComboBox";
            _textValueComboBox.Size = new Size(242, 28);
            _textValueComboBox.TabIndex = 2;
            // 
            // _fromDateTimePicker
            // 
            _fromDateTimePicker.Checked = false;
            _fromDateTimePicker.Dock = DockStyle.Fill;
            _fromDateTimePicker.Format = DateTimePickerFormat.Short;
            _fromDateTimePicker.Location = new Point(486, 5);
            _fromDateTimePicker.Margin = new Padding(3, 5, 3, 3);
            _fromDateTimePicker.Name = "_fromDateTimePicker";
            _fromDateTimePicker.Size = new Size(242, 27);
            _fromDateTimePicker.TabIndex = 3;
            // 
            // _sortComboBox
            // 
            _sortComboBox.Dock = DockStyle.Fill;
            _sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _sortComboBox.FormattingEnabled = true;
            _sortComboBox.Location = new Point(982, 5);
            _sortComboBox.Margin = new Padding(3, 5, 3, 3);
            _sortComboBox.Name = "_sortComboBox";
            _sortComboBox.Size = new Size(155, 28);
            _sortComboBox.TabIndex = 5;
            // 
            // _toDateTimePicker
            // 
            _toDateTimePicker.Checked = false;
            _toDateTimePicker.Dock = DockStyle.Fill;
            _toDateTimePicker.Format = DateTimePickerFormat.Short;
            _toDateTimePicker.Location = new Point(734, 5);
            _toDateTimePicker.Margin = new Padding(3, 5, 3, 3);
            _toDateTimePicker.Name = "_toDateTimePicker";
            _toDateTimePicker.Size = new Size(242, 27);
            _toDateTimePicker.TabIndex = 4;
            // 
            // _useCheckBox
            // 
            _useCheckBox.AutoSize = true;
            _useCheckBox.Dock = DockStyle.Top;
            _useCheckBox.Location = new Point(3, 7);
            _useCheckBox.Margin = new Padding(3, 7, 3, 3);
            _useCheckBox.Name = "_useCheckBox";
            _useCheckBox.Size = new Size(94, 24);
            _useCheckBox.TabIndex = 0;
            _useCheckBox.Text = "Criteria";
            _useCheckBox.UseVisualStyleBackColor = true;
            _useCheckBox.CheckedChanged += OnCheckCriteria;
            // 
            // CriteriaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_tableLayoutPanel);
            MinimumSize = new Size(200, 40);
            Name = "CriteriaControl";
            Size = new Size(1140, 43);
            _tableLayoutPanel.ResumeLayout(false);
            _tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox _attributeComboBox;
        private TableLayoutPanel _tableLayoutPanel;
        private ComboBox _sortComboBox;
        private ComboBox _textValueComboBox;
        private DateTimePicker _fromDateTimePicker;
        private DateTimePicker _toDateTimePicker;
        private CheckBox _useCheckBox;
    }
}
