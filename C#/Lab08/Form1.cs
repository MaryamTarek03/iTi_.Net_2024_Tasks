using Npgsql;
using System.Data;

namespace iTi_day_12
{
    public partial class Form1 : Form
    {
        NpgsqlConnection connection;
        int currentSelectedID = 0;

        public Form1()
        {
            InitializeComponent();
            connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=root;Database=iTi");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetInstructor();
            GetDepartment();
        }

        #region initialize data
        public void GetInstructor()
        {
            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText
                = @"
                SELECT InstructorID AS Instructor_ID, Name, Degree, Salary, departments.deptdesc AS department_name, departments.deptid AS Department_ID
                FROM instructor
                INNER JOIN departments
                ON departments.deptid = instructor.departmentid
                ";
            NpgsqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            connection.Close();

            instructorDataGrid.DataSource = dt;
        }
        public void GetDepartment()
        {
            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText
                = "SELECT deptID AS dept_id, deptDesc AS dept_name FROM departments";
            NpgsqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            connection.Close();

            dep_combobox.DataSource = dt;
            dep_combobox.DisplayMember = "dept_name";
            dep_combobox.ValueMember = "dept_id";
            dep_combobox.SelectedIndex = -1;
        }
        #endregion

        #region functions
        public void SetSelectedRowItems(DataGridViewRow row)
        {
            currentSelectedID = (int)row.Cells["Instructor_ID"].Value;
            name_textbox.Text = row.Cells["Name"].Value.ToString();

            string? degree = row.Cells["Degree"].Value.ToString();
            degree_combobox.SelectedIndex = degree_combobox.FindStringExact(degree);

            if (row.Cells["Department_ID"].Value != DBNull.Value)
                dep_combobox.SelectedValue = Convert.ToInt32(row.Cells["Department_ID"].Value);

            salary_numeric.Value = (row.Cells["Salary"].Value) is DBNull ? 0 : Convert.ToInt32(row.Cells["Salary"].Value);
        }
        public void ClearFields()
        {
            name_textbox.Clear();
            degree_combobox.SelectedIndex = -1;
            dep_combobox.SelectedIndex = -1;
            salary_numeric.Value = 0;
        }
        public void UpdateInstructor()
        {
            if (currentSelectedID == 0) return;
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText
                = "UPDATE instructor SET name = @name, Degree = @degree, Salary = @salary, departmentID = @depID WHERE instructorID = @id";
            command.Parameters.AddWithValue("name", name_textbox.Text);
            command.Parameters.AddWithValue("salary", salary_numeric.Value);
            command.Parameters.AddWithValue("Degree", degree_combobox.Text);
            command.Parameters.AddWithValue("depID", dep_combobox.SelectedValue);
            command.Parameters.AddWithValue("id", currentSelectedID);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteInstructor()
        {
            if (currentSelectedID == 0) return;

            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM instructor WHERE instructorID = @id;";
            command.Parameters.AddWithValue("id", currentSelectedID);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void InsertInstructor()
        {
            connection.Open();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText 
                = "INSERT INTO instructor (Name, Degree, Salary, DepartmentID) VALUES (@name, @degree, @salary, @depID)";
            command.Parameters.AddWithValue("name", name_textbox.Text);
            command.Parameters.AddWithValue("degree", degree_combobox.Text);
            command.Parameters.AddWithValue("salary", salary_numeric.Value);
            command.Parameters.AddWithValue("depID", dep_combobox.SelectedValue);

            command.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region button clicks
        private void GridRowDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = instructorDataGrid.SelectedRows[0];
            if (row != null) SetSelectedRowItems(row);
        }
        private void DeleteClick(object sender, EventArgs e)
        {
            DeleteInstructor();
            GetInstructor();
            ClearFields();
        }
        private void UpdateClick(object sender, EventArgs e)
        {
            UpdateInstructor();
            GetInstructor();
            ClearFields();
        }
        private void InsertClick(object sender, EventArgs e)
        {
            InsertInstructor();
            GetInstructor();
            ClearFields();
        }
        #endregion
    }
}