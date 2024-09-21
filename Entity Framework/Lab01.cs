namespace iTi_day_14
{
    public partial class Form1 : Form
    {

        int id = 0;
        iTiContext context;

        public Form1()
        {
            InitializeComponent();
            context = new iTiContext();
        }

        #region initialize data
        private void Form1_Load(object sender, EventArgs e)
        {
            GetInstructors();
            GetDepartments();
            EnableAdd(true);
        }
        public void GetInstructors()
            => instructorDataGrid.DataSource = context.Instructors.ToList();
        public void GetDepartments()
        {
            dep_combobox.DataSource = context.Departments.ToList();
            dep_combobox.DisplayMember = "deptdesc";
            dep_combobox.ValueMember = "deptid";
            dep_combobox.SelectedIndex = -1;
        }
        #endregion

        #region functions
        public void SetSelectedRowItems(DataGridViewRow row)
        {
            id = (int)row.Cells[0].Value;
            //if (id == 0) { return; }
            Instructor? instructor = context.Instructors.Where(instructor => instructor.Instructorid == id).FirstOrDefault();
            name_textbox.Text = instructor?.Name;

            degree_combobox.Text = instructor?.Degree;
            // degree_combobox.SelectedIndex = degree_combobox.FindStringExact(degree);

            if (instructor?.Departmentid != null)
                dep_combobox.SelectedValue = instructor.Departmentid;

            salary_numeric.Value = instructor?.Salary is null ? 0 : Convert.ToInt32(instructor.Salary);
        }
        public void ClearFields()
        {
            name_textbox.Clear();
            degree_combobox.SelectedIndex = -1;
            degree_combobox.Text = string.Empty;
            dep_combobox.SelectedIndex = -1;
            salary_numeric.Value = 0;
        }
        public void EnableAdd(bool enable)
        {
            insert_button.Enabled = enable;
            delete_button.Enabled = !enable;
            update_button.Enabled = !enable;
        }
        #endregion

        #region data queries
        public void InsertInstructor()
        {
            Instructor instructor = new Instructor()
            {
                Name = name_textbox.Text,
                Degree = degree_combobox.Text,
                Departmentid = (int?)dep_combobox.SelectedValue,
                Salary = salary_numeric.Value,
            };
            context.Add(instructor);
            context.SaveChanges();
        }
        public void UpdateInstructor()
        {
            Instructor? instructor = context.Instructors.Where(instructor => instructor.Instructorid == id).FirstOrDefault();
            if (instructor != null)
            {
                instructor.Name = name_textbox.Text;
                instructor.Degree = degree_combobox.Text;
                instructor.Departmentid = (int?)dep_combobox.SelectedValue;
                instructor.Salary = salary_numeric.Value;

                context.SaveChanges();
            }
        }
        public void DeleteInstructor()
        {
            Instructor? instructor = context.Instructors.Where(instructor => instructor.Instructorid == id).FirstOrDefault();
            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
                context.SaveChanges();
            }
        }
        #endregion

        #region button clicks
        private void InsertOnClick(object sender, EventArgs e)
        {
            InsertInstructor();
            GetInstructors();
            ClearFields();
        }
        private void UpdateOnClick(object sender, EventArgs e)
        {
            UpdateInstructor();
            GetInstructors();
            ClearFields();
            EnableAdd(true);
        }
        private void DeleteOnClick(object sender, EventArgs e)
        {
            DeleteInstructor();
            GetInstructors();
            ClearFields();
            EnableAdd(true);
        }
        private void ClearOnClick(object sender, EventArgs e)
        {
            ClearFields();
            EnableAdd(true);
        }

        private void OnRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = instructorDataGrid.SelectedRows[0];
            EnableAdd(false);
            if (row != null) SetSelectedRowItems(row);
        }
        #endregion

    }
}