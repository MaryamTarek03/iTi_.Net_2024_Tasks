namespace iTi_day_12
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            instructorDataGrid = new DataGridView();
            name_textbox = new TextBox();
            name_label = new Label();
            degree_label = new Label();
            degree_combobox = new ComboBox();
            salary_numeric = new NumericUpDown();
            label1 = new Label();
            department_label = new Label();
            insert_button = new Button();
            update_button = new Button();
            delete_button = new Button();
            dep_combobox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)instructorDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)salary_numeric).BeginInit();
            SuspendLayout();
            // 
            // instructorDataGrid
            // 
            instructorDataGrid.AccessibleName = "dataGridName";
            instructorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            instructorDataGrid.Location = new Point(350, 12);
            instructorDataGrid.Name = "instructorDataGrid";
            instructorDataGrid.RowHeadersWidth = 51;
            instructorDataGrid.Size = new Size(438, 426);
            instructorDataGrid.TabIndex = 3;
            instructorDataGrid.RowHeaderMouseDoubleClick += GridRowDoubleClick;
            // 
            // name_textbox
            // 
            name_textbox.Font = new Font("Lotion", 9F, FontStyle.Bold, GraphicsUnit.Point);
            name_textbox.Location = new Point(81, 18);
            name_textbox.Name = "name_textbox";
            name_textbox.PlaceholderText = "Please enter instructor name";
            name_textbox.Size = new Size(263, 25);
            name_textbox.TabIndex = 4;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Lotion", 12F, FontStyle.Bold, GraphicsUnit.Point);
            name_label.Location = new Point(3, 19);
            name_label.Name = "name_label";
            name_label.Size = new Size(54, 24);
            name_label.TabIndex = 5;
            name_label.Text = "Name";
            // 
            // degree_label
            // 
            degree_label.AutoSize = true;
            degree_label.Font = new Font("Lotion", 12F, FontStyle.Bold, GraphicsUnit.Point);
            degree_label.Location = new Point(3, 70);
            degree_label.Name = "degree_label";
            degree_label.Size = new Size(76, 24);
            degree_label.TabIndex = 6;
            degree_label.Text = "Degree";
            // 
            // degree_combobox
            // 
            degree_combobox.Font = new Font("Lotion", 9F, FontStyle.Bold, GraphicsUnit.Point);
            degree_combobox.FormattingEnabled = true;
            degree_combobox.Items.AddRange(new object[] { "Master", "PhD" });
            degree_combobox.Location = new Point(81, 68);
            degree_combobox.Name = "degree_combobox";
            degree_combobox.Size = new Size(263, 26);
            degree_combobox.TabIndex = 7;
            // 
            // salary_numeric
            // 
            salary_numeric.Font = new Font("Lotion", 9F, FontStyle.Bold, GraphicsUnit.Point);
            salary_numeric.Location = new Point(129, 171);
            salary_numeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            salary_numeric.Name = "salary_numeric";
            salary_numeric.Size = new Size(215, 25);
            salary_numeric.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lotion", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 171);
            label1.Name = "label1";
            label1.Size = new Size(76, 24);
            label1.TabIndex = 9;
            label1.Text = "Salary";
            // 
            // department_label
            // 
            department_label.AutoSize = true;
            department_label.Font = new Font("Lotion", 12F, FontStyle.Bold, GraphicsUnit.Point);
            department_label.Location = new Point(3, 126);
            department_label.Name = "department_label";
            department_label.Size = new Size(120, 24);
            department_label.TabIndex = 11;
            department_label.Text = "Department";
            // 
            // insert_button
            // 
            insert_button.Font = new Font("Lotion", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            insert_button.Location = new Point(3, 295);
            insert_button.Name = "insert_button";
            insert_button.Size = new Size(341, 44);
            insert_button.TabIndex = 12;
            insert_button.Text = "Insert";
            insert_button.UseVisualStyleBackColor = true;
            insert_button.Click += InsertClick;
            // 
            // update_button
            // 
            update_button.Font = new Font("Lotion", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            update_button.Location = new Point(3, 345);
            update_button.Name = "update_button";
            update_button.Size = new Size(341, 44);
            update_button.TabIndex = 13;
            update_button.Text = "Update";
            update_button.UseVisualStyleBackColor = true;
            update_button.Click += UpdateClick;
            // 
            // delete_button
            // 
            delete_button.Font = new Font("Lotion", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            delete_button.Location = new Point(3, 395);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(341, 44);
            delete_button.TabIndex = 14;
            delete_button.Text = "Delete";
            delete_button.UseVisualStyleBackColor = true;
            delete_button.Click += DeleteClick;
            // 
            // dep_combobox
            // 
            dep_combobox.Font = new Font("Lotion", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dep_combobox.FormattingEnabled = true;
            dep_combobox.Location = new Point(129, 124);
            dep_combobox.Name = "dep_combobox";
            dep_combobox.Size = new Size(215, 26);
            dep_combobox.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dep_combobox);
            Controls.Add(delete_button);
            Controls.Add(update_button);
            Controls.Add(insert_button);
            Controls.Add(department_label);
            Controls.Add(label1);
            Controls.Add(salary_numeric);
            Controls.Add(degree_combobox);
            Controls.Add(degree_label);
            Controls.Add(name_label);
            Controls.Add(name_textbox);
            Controls.Add(instructorDataGrid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)instructorDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)salary_numeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView instructorDataGrid;
        private TextBox name_textbox;
        private Label name_label;
        private Label degree_label;
        private ComboBox degree_combobox;
        private NumericUpDown salary_numeric;
        private Label label1;
        private Label department_label;
        private Button insert_button;
        private Button update_button;
        private Button delete_button;
        private ComboBox dep_combobox;
    }
}