namespace Autoprezzit_interface
{
    partial class UIForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            province_combobox = new ComboBox();
            year_textbox = new TextBox();
            power_textbox = new TextBox();
            panel3 = new Panel();
            automatic__radiobutton = new RadioButton();
            manual_radiobutton = new RadioButton();
            semi_radiobutton = new RadioButton();
            panel2 = new Panel();
            used__radiobutton = new RadioButton();
            new_radiobutton = new RadioButton();
            km_textbox = new TextBox();
            fuel_combobox = new ComboBox();
            version_combobox = new ComboBox();
            province_label = new Label();
            label3 = new Label();
            tear_label = new Label();
            label2 = new Label();
            powerkw_label = new Label();
            make_label = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            model_combobox = new ComboBox();
            make_combobox = new ComboBox();
            evaluate_button = new Button();
            result_label = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.FromArgb(33, 33, 33);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1575, 153);
            panel1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5684557F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.2714615F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.0166035F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.86599F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.923423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.923423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.923423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.923423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.923423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.660378F));
            tableLayoutPanel1.Controls.Add(province_combobox, 9, 1);
            tableLayoutPanel1.Controls.Add(year_textbox, 8, 1);
            tableLayoutPanel1.Controls.Add(power_textbox, 7, 1);
            tableLayoutPanel1.Controls.Add(panel3, 6, 1);
            tableLayoutPanel1.Controls.Add(panel2, 4, 1);
            tableLayoutPanel1.Controls.Add(km_textbox, 5, 1);
            tableLayoutPanel1.Controls.Add(fuel_combobox, 3, 1);
            tableLayoutPanel1.Controls.Add(version_combobox, 2, 1);
            tableLayoutPanel1.Controls.Add(province_label, 9, 0);
            tableLayoutPanel1.Controls.Add(label3, 6, 0);
            tableLayoutPanel1.Controls.Add(tear_label, 8, 0);
            tableLayoutPanel1.Controls.Add(label2, 4, 0);
            tableLayoutPanel1.Controls.Add(powerkw_label, 7, 0);
            tableLayoutPanel1.Controls.Add(make_label, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 3, 0);
            tableLayoutPanel1.Controls.Add(label7, 2, 0);
            tableLayoutPanel1.Controls.Add(label4, 5, 0);
            tableLayoutPanel1.Controls.Add(model_combobox, 1, 1);
            tableLayoutPanel1.Controls.Add(make_combobox, 0, 1);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.3225822F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.6774178F));
            tableLayoutPanel1.Size = new Size(1572, 150);
            tableLayoutPanel1.TabIndex = 14;
            tableLayoutPanel1.CellPaint += tableLayoutPanel1_CellPaint;
            // 
            // province_combobox
            // 
            province_combobox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            province_combobox.BackColor = Color.White;
            province_combobox.DropDownHeight = 300;
            province_combobox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            province_combobox.FormattingEnabled = true;
            province_combobox.IntegralHeight = false;
            province_combobox.ItemHeight = 22;
            province_combobox.Location = new Point(1488, 97);
            province_combobox.Margin = new Padding(10, 3, 10, 3);
            province_combobox.Name = "province_combobox";
            province_combobox.Size = new Size(74, 30);
            province_combobox.Sorted = true;
            province_combobox.TabIndex = 24;
            province_combobox.Text = "-";
            // 
            // year_textbox
            // 
            year_textbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            year_textbox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            year_textbox.Location = new Point(1364, 98);
            year_textbox.Margin = new Padding(10, 3, 10, 3);
            year_textbox.Name = "year_textbox";
            year_textbox.PlaceholderText = "2025";
            year_textbox.Size = new Size(104, 28);
            year_textbox.TabIndex = 23;
            year_textbox.TextAlign = HorizontalAlignment.Center;
            year_textbox.KeyPress += textBox_KeyPress;
            // 
            // power_textbox
            // 
            power_textbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            power_textbox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            power_textbox.Location = new Point(1240, 98);
            power_textbox.Margin = new Padding(10, 3, 10, 3);
            power_textbox.Name = "power_textbox";
            power_textbox.PlaceholderText = "0";
            power_textbox.Size = new Size(104, 28);
            power_textbox.TabIndex = 22;
            power_textbox.TextAlign = HorizontalAlignment.Center;
            power_textbox.KeyPress += textBox_KeyPress;
            // 
            // panel3
            // 
            panel3.Controls.Add(automatic__radiobutton);
            panel3.Controls.Add(manual_radiobutton);
            panel3.Controls.Add(semi_radiobutton);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(1109, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(118, 69);
            panel3.TabIndex = 21;
            // 
            // automatic__radiobutton
            // 
            automatic__radiobutton.Anchor = AnchorStyles.None;
            automatic__radiobutton.AutoSize = true;
            automatic__radiobutton.Checked = true;
            automatic__radiobutton.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            automatic__radiobutton.ForeColor = SystemColors.Control;
            automatic__radiobutton.Location = new Point(2, 45);
            automatic__radiobutton.Name = "automatic__radiobutton";
            automatic__radiobutton.Size = new Size(90, 21);
            automatic__radiobutton.TabIndex = 29;
            automatic__radiobutton.TabStop = true;
            automatic__radiobutton.Text = "Automatic";
            automatic__radiobutton.TextAlign = ContentAlignment.MiddleCenter;
            automatic__radiobutton.UseVisualStyleBackColor = true;
            // 
            // manual_radiobutton
            // 
            manual_radiobutton.Anchor = AnchorStyles.None;
            manual_radiobutton.AutoSize = true;
            manual_radiobutton.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            manual_radiobutton.ForeColor = SystemColors.Control;
            manual_radiobutton.Location = new Point(2, 3);
            manual_radiobutton.Name = "manual_radiobutton";
            manual_radiobutton.Size = new Size(72, 21);
            manual_radiobutton.TabIndex = 27;
            manual_radiobutton.Text = "Manual";
            manual_radiobutton.TextAlign = ContentAlignment.MiddleCenter;
            manual_radiobutton.UseVisualStyleBackColor = true;
            // 
            // semi_radiobutton
            // 
            semi_radiobutton.Anchor = AnchorStyles.None;
            semi_radiobutton.AutoSize = true;
            semi_radiobutton.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            semi_radiobutton.ForeColor = SystemColors.Control;
            semi_radiobutton.Location = new Point(2, 24);
            semi_radiobutton.Name = "semi_radiobutton";
            semi_radiobutton.Size = new Size(123, 21);
            semi_radiobutton.TabIndex = 28;
            semi_radiobutton.Text = "Semi-automatic";
            semi_radiobutton.TextAlign = ContentAlignment.MiddleCenter;
            semi_radiobutton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(used__radiobutton);
            panel2.Controls.Add(new_radiobutton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(861, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(118, 69);
            panel2.TabIndex = 12;
            // 
            // used__radiobutton
            // 
            used__radiobutton.Anchor = AnchorStyles.Top;
            used__radiobutton.AutoSize = true;
            used__radiobutton.Checked = true;
            used__radiobutton.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            used__radiobutton.ForeColor = SystemColors.Control;
            used__radiobutton.Location = new Point(28, 32);
            used__radiobutton.Name = "used__radiobutton";
            used__radiobutton.Size = new Size(65, 23);
            used__radiobutton.TabIndex = 27;
            used__radiobutton.TabStop = true;
            used__radiobutton.Text = "Used";
            used__radiobutton.TextAlign = ContentAlignment.MiddleCenter;
            used__radiobutton.UseVisualStyleBackColor = true;
            // 
            // new_radiobutton
            // 
            new_radiobutton.Anchor = AnchorStyles.None;
            new_radiobutton.AutoSize = true;
            new_radiobutton.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            new_radiobutton.ForeColor = SystemColors.Control;
            new_radiobutton.Location = new Point(28, 3);
            new_radiobutton.Name = "new_radiobutton";
            new_radiobutton.Size = new Size(62, 23);
            new_radiobutton.TabIndex = 28;
            new_radiobutton.Text = "New";
            new_radiobutton.TextAlign = ContentAlignment.MiddleCenter;
            new_radiobutton.UseVisualStyleBackColor = true;
            // 
            // km_textbox
            // 
            km_textbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            km_textbox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            km_textbox.Location = new Point(992, 98);
            km_textbox.Margin = new Padding(10, 3, 10, 3);
            km_textbox.Name = "km_textbox";
            km_textbox.PlaceholderText = "0";
            km_textbox.Size = new Size(104, 28);
            km_textbox.TabIndex = 12;
            km_textbox.TextAlign = HorizontalAlignment.Center;
            km_textbox.KeyPress += textBox_KeyPress;
            // 
            // fuel_combobox
            // 
            fuel_combobox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fuel_combobox.BackColor = Color.White;
            fuel_combobox.DropDownHeight = 300;
            fuel_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            fuel_combobox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            fuel_combobox.FormattingEnabled = true;
            fuel_combobox.IntegralHeight = false;
            fuel_combobox.ItemHeight = 22;
            fuel_combobox.Location = new Point(651, 97);
            fuel_combobox.Margin = new Padding(10, 3, 10, 3);
            fuel_combobox.Name = "fuel_combobox";
            fuel_combobox.Size = new Size(197, 30);
            fuel_combobox.Sorted = true;
            fuel_combobox.TabIndex = 20;
            // 
            // version_combobox
            // 
            version_combobox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            version_combobox.AutoCompleteMode = AutoCompleteMode.Append;
            version_combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            version_combobox.BackColor = Color.White;
            version_combobox.DropDownHeight = 300;
            version_combobox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            version_combobox.FormattingEnabled = true;
            version_combobox.IntegralHeight = false;
            version_combobox.ItemHeight = 22;
            version_combobox.Location = new Point(353, 97);
            version_combobox.Margin = new Padding(10, 3, 10, 3);
            version_combobox.Name = "version_combobox";
            version_combobox.Size = new Size(278, 30);
            version_combobox.Sorted = true;
            version_combobox.TabIndex = 19;
            version_combobox.Text = "-";
            // 
            // province_label
            // 
            province_label.Anchor = AnchorStyles.Bottom;
            province_label.AutoSize = true;
            province_label.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            province_label.ForeColor = Color.FromArgb(56, 136, 221);
            province_label.Location = new Point(1483, 13);
            province_label.Margin = new Padding(3, 0, 3, 10);
            province_label.Name = "province_label";
            province_label.Size = new Size(83, 52);
            province_label.TabIndex = 10;
            province_label.Text = "Province";
            province_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(56, 136, 221);
            label3.Location = new Point(1121, 39);
            label3.Margin = new Padding(3, 0, 3, 10);
            label3.Name = "label3";
            label3.Size = new Size(93, 26);
            label3.TabIndex = 16;
            label3.Text = "Gearbox";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tear_label
            // 
            tear_label.Anchor = AnchorStyles.Bottom;
            tear_label.AutoSize = true;
            tear_label.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            tear_label.ForeColor = Color.FromArgb(56, 136, 221);
            tear_label.Location = new Point(1389, 39);
            tear_label.Margin = new Padding(3, 0, 3, 10);
            tear_label.Name = "tear_label";
            tear_label.Size = new Size(54, 26);
            tear_label.TabIndex = 9;
            tear_label.Text = "Year";
            tear_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(56, 136, 221);
            label2.Location = new Point(865, 39);
            label2.Margin = new Padding(3, 0, 3, 10);
            label2.Name = "label2";
            label2.Size = new Size(109, 26);
            label2.TabIndex = 13;
            label2.Text = "New/used";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // powerkw_label
            // 
            powerkw_label.Anchor = AnchorStyles.Bottom;
            powerkw_label.AutoSize = true;
            powerkw_label.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            powerkw_label.ForeColor = Color.FromArgb(56, 136, 221);
            powerkw_label.Location = new Point(1240, 39);
            powerkw_label.Margin = new Padding(3, 0, 3, 10);
            powerkw_label.Name = "powerkw_label";
            powerkw_label.Size = new Size(104, 26);
            powerkw_label.TabIndex = 8;
            powerkw_label.Text = "PowerKW";
            powerkw_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // make_label
            // 
            make_label.Anchor = AnchorStyles.Bottom;
            make_label.AutoSize = true;
            make_label.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            make_label.ForeColor = Color.FromArgb(56, 136, 221);
            make_label.Location = new Point(50, 39);
            make_label.Margin = new Padding(3, 0, 3, 10);
            make_label.Name = "make_label";
            make_label.Size = new Size(65, 26);
            make_label.TabIndex = 17;
            make_label.Text = "Make";
            make_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(56, 136, 221);
            label5.Location = new Point(217, 39);
            label5.Margin = new Padding(3, 0, 3, 10);
            label5.Name = "label5";
            label5.Size = new Size(74, 26);
            label5.TabIndex = 11;
            label5.Text = "Model";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(56, 136, 221);
            label6.Location = new Point(699, 39);
            label6.Margin = new Padding(3, 0, 3, 10);
            label6.Name = "label6";
            label6.Size = new Size(101, 26);
            label6.TabIndex = 14;
            label6.Text = "Fuel type";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(56, 136, 221);
            label7.Location = new Point(450, 39);
            label7.Margin = new Padding(3, 0, 3, 10);
            label7.Name = "label7";
            label7.Size = new Size(84, 26);
            label7.TabIndex = 12;
            label7.Text = "Version";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(66, 146, 231);
            label4.Location = new Point(1021, 39);
            label4.Margin = new Padding(3, 0, 3, 10);
            label4.Name = "label4";
            label4.Size = new Size(45, 26);
            label4.TabIndex = 15;
            label4.Text = "KM";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // model_combobox
            // 
            model_combobox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            model_combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            model_combobox.BackColor = Color.White;
            model_combobox.DropDownHeight = 300;
            model_combobox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            model_combobox.FormattingEnabled = true;
            model_combobox.IntegralHeight = false;
            model_combobox.ItemHeight = 22;
            model_combobox.Location = new Point(176, 97);
            model_combobox.Margin = new Padding(10, 3, 10, 3);
            model_combobox.MaxDropDownItems = 10;
            model_combobox.Name = "model_combobox";
            model_combobox.Size = new Size(157, 30);
            model_combobox.Sorted = true;
            model_combobox.TabIndex = 18;
            model_combobox.TextChanged += model_combobox_TextChanged;
            // 
            // make_combobox
            // 
            make_combobox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            make_combobox.AutoCompleteMode = AutoCompleteMode.Append;
            make_combobox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            make_combobox.BackColor = Color.White;
            make_combobox.DropDownHeight = 300;
            make_combobox.DropDownWidth = 200;
            make_combobox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            make_combobox.FormattingEnabled = true;
            make_combobox.IntegralHeight = false;
            make_combobox.ItemHeight = 22;
            make_combobox.Location = new Point(10, 97);
            make_combobox.Margin = new Padding(10, 3, 10, 3);
            make_combobox.MaxDropDownItems = 10;
            make_combobox.Name = "make_combobox";
            make_combobox.Size = new Size(146, 30);
            make_combobox.Sorted = true;
            make_combobox.TabIndex = 2;
            make_combobox.Text = "-";
            make_combobox.TextChanged += make_combobox_TextChanged;
            // 
            // evaluate_button
            // 
            evaluate_button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            evaluate_button.BackColor = Color.FromArgb(36, 116, 201);
            evaluate_button.BackgroundImageLayout = ImageLayout.None;
            evaluate_button.Cursor = Cursors.Hand;
            evaluate_button.FlatAppearance.BorderColor = Color.FromArgb(56, 136, 221);
            evaluate_button.FlatAppearance.BorderSize = 2;
            evaluate_button.FlatStyle = FlatStyle.Flat;
            evaluate_button.Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold);
            evaluate_button.ForeColor = Color.White;
            evaluate_button.Location = new Point(670, 225);
            evaluate_button.Name = "evaluate_button";
            evaluate_button.Size = new Size(230, 54);
            evaluate_button.TabIndex = 12;
            evaluate_button.Text = "Evaluate";
            evaluate_button.UseVisualStyleBackColor = false;
            evaluate_button.MouseUp += collectData;
            // 
            // result_label
            // 
            result_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            result_label.AutoEllipsis = true;
            result_label.Font = new Font("Microsoft YaHei UI", 30F, FontStyle.Bold);
            result_label.ForeColor = Color.White;
            result_label.Location = new Point(0, 450);
            result_label.Name = "result_label";
            result_label.Size = new Size(1572, 69);
            result_label.TabIndex = 13;
            result_label.Text = "Insert your data";
            result_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UIForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1571, 661);
            Controls.Add(result_label);
            Controls.Add(evaluate_button);
            Controls.Add(panel1);
            MinimumSize = new Size(1400, 500);
            Name = "UIForm";
            Text = "Car price predictor";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label province_label;
        private Label label3;
        private Label tear_label;
        private Label label2;
        private Label powerkw_label;
        private Label make_label;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label4;
        private ComboBox fuel_combobox;
        private ComboBox version_combobox;
        private ComboBox make_combobox;
        private ComboBox model_combobox;
        private TextBox km_textbox;
        private Panel panel2;
        private RadioButton used__radiobutton;
        private RadioButton new_radiobutton;
        private Panel panel3;
        private RadioButton manual_radiobutton;
        private RadioButton semi_radiobutton;
        private RadioButton automatic__radiobutton;
        private ComboBox province_combobox;
        private TextBox year_textbox;
        private TextBox power_textbox;
        private Button evaluate_button;
        private Label result_label;
    }
}
