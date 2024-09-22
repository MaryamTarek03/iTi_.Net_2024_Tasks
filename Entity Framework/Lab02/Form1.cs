using iTi_day_15_lab.Models;

namespace iTi_day_15_lab
{
    public partial class Form1 : Form
    {
        int newsId = 0;
        int authorId = 5;
        NewsArchiveContext context;

        public Form1()
        {
            InitializeComponent();
            context = new NewsArchiveContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAuth();
            EnableAdd(true);
        }

        public void ShowAuth()
        {
            username_textbox.Visible = true;
            password_textbox.Visible = true;
            login_button.Visible = true;
            register_button.Visible = true;

            newsDataGrid.Visible = false;
            title_textbox.Visible = false;
            brief_textbox.Visible = false;
            content_textbox.Visible = false;
            category_combobox.Visible = false;
            insert_button.Visible = false;
            update_button.Visible = false;
            delete_button.Visible = false;
            clear_button.Visible = false;
        }
        public void ShowNews()
        {
            GetAuthorNewsPieces();
            GetCategories();

            username_textbox.Visible = false;
            password_textbox.Visible = false;
            login_button.Visible = false;
            register_button.Visible = false;

            newsDataGrid.Visible = true;
            title_textbox.Visible = true;
            brief_textbox.Visible = true;
            content_textbox.Visible = true;
            category_combobox.Visible = true;
            insert_button.Visible = true;
            update_button.Visible = true;
            delete_button.Visible = true;
            clear_button.Visible = true;
        }

        #region authentication page

        #region data queries
        public bool AuthorExist(string username)
        {
            try
            {
                Author? author = context.Author?
                    .Where(author => author.Username == username_textbox.Text)
                    .Single();
                return author != null;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                return false;
            }
        }
        public Author GetAuthorByUsername(string username)
        {
            Author? author
                = context.Author?
                .Where(author => author.Username == username_textbox.Text)
                .SingleOrDefault();
            return author;
        }
        public void AddAuthor()
        {
            Author author = new Author()
            {
                Username = username_textbox.Text,
                Password = password_textbox.Text,
                JoinedAt = DateTime.UtcNow,
                Name = username_textbox.Text,
                Age = 24,
            };
            try
            {
                context.Author?.Add(author);
                context.SaveChanges();
                authorId = author.Id;
                welcome_message.Text += author.Name;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region functions
        public bool FieldsEmpty()
            => username_textbox.Text.Length == 0 || password_textbox.Text.Length == 0;
        #endregion

        #region button clicks
        private void OnLoginClick(object sender, EventArgs e)
        {
            if (FieldsEmpty())
            {
                MessageBox.Show("Please fill the fields");
                return;
            }
            if (!AuthorExist(username_textbox.Text))
            {
                MessageBox.Show("The author doesn't exist!");
                return;
            }
            Author author = GetAuthorByUsername(username_textbox.Text);
            if (author.Password != password_textbox.Text)
            {
                MessageBox.Show("The password is incorrect!");
                return;
            }
            authorId = author.Id;
            welcome_message.Text += author.Name;
            ShowNews();
        }
        private void OnRegisterClick(object sender, EventArgs e)
        {
            if (FieldsEmpty())
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (AuthorExist(username_textbox.Text))
            {
                MessageBox.Show("This author already exist!");
                return;
            }
            AddAuthor();
            ShowNews();
        }
        #endregion

        #endregion

        #region news page
        #region get data
        public void GetCategories()
        {
            category_combobox.DataSource = context.Category?.ToList();
            category_combobox.DisplayMember = "Name";
            category_combobox.ValueMember = "Id";
            category_combobox.SelectedIndex = 0;
        }
        public void GetAuthorNewsPieces()
        {
            newsDataGrid.DataSource
            = context.NewsPiece?
              .Where(newsPiece => newsPiece.AuthorId == authorId)
              .Select(n => new { n.Id, n.Title, n.Brief, n.Description, Category_Name = n.Category.Name, n.Date, n.Time })
              .ToList();
        }
        #endregion

        #region functions
        // select row data and put in fields
        public void SetSelectedRowItems(DataGridViewRow row)
        {
            newsId = (int)row.Cells[0].Value;
            var newsPiece = context.NewsPiece?.Where(newsPiece => newsPiece.Id == newsId).FirstOrDefault();
            title_textbox.Text = newsPiece?.Title;
            brief_textbox.Text = newsPiece?.Brief;
            content_textbox.Text = newsPiece?.Description;
            category_combobox.SelectedIndex = category_combobox.FindStringExact(newsPiece?.Category?.Name);
        }

        // clear the fields
        public void ClearFields()
        {
            title_textbox.Clear();
            brief_textbox.Clear();
            content_textbox.Clear();
            title_textbox.Clear();
            category_combobox.SelectedIndex = 0;
            EnableAdd(true);
        }

        // enable add & disable update and delete
        public void EnableAdd(bool enable)
        {
            insert_button.Enabled = enable;
            delete_button.Enabled = !enable;
            update_button.Enabled = !enable;
        }
        #endregion

        #region data queries
        public void InsertNewsPiece()
        {
            int categoryId = (int)category_combobox.SelectedValue;
            Author? author = context.Author?.Where(author => author.Id == authorId).FirstOrDefault();
            Category? category
                = context.Category?
                .Where(category => category.Id == categoryId)
                .FirstOrDefault();
            NewsPiece newsPiece = new NewsPiece()
            {
                Author = author,
                AuthorId = authorId,
                Title = title_textbox.Text,
                Brief = brief_textbox.Text,
                Description = content_textbox.Text,
                Category = category,
                CategoryId = categoryId,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = DateTime.Now.TimeOfDay,
            };
            context.Add(newsPiece);
            context.SaveChanges();
        }
        public void UpdateNewsPiece()
        {
            var newsPiece
                = context.NewsPiece?
                .Where(news => news.Id == newsId)
                .FirstOrDefault();
            if (newsPiece != null)
            {
                newsPiece.Title = title_textbox.Text;
                newsPiece.Brief = brief_textbox.Text;
                newsPiece.Description = content_textbox.Text;
                newsPiece.CategoryId = (int)category_combobox.SelectedValue;
                newsPiece.Date = DateOnly.FromDateTime(DateTime.Now);
                newsPiece.Time = DateTime.Now.TimeOfDay;
            }
            context.SaveChanges();
        }
        public void DeleteNewsPiece()
        {
            var newsPiece
                = context.NewsPiece?
                .Where(news => news.Id == newsId)
                .FirstOrDefault();

            context.NewsPiece?.Remove(newsPiece);
            context.SaveChanges();
        }
        #endregion

        #region button clicks
        private void OnInsertClick(object sender, EventArgs e)
        {
            InsertNewsPiece();
            GetAuthorNewsPieces();
            ClearFields();
        }
        private void OnUpdateClick(object sender, EventArgs e)
        {
            UpdateNewsPiece();
            GetAuthorNewsPieces();
            ClearFields();
        }
        private void OnDeleteClick(object sender, EventArgs e)
        {
            DeleteNewsPiece();
            GetAuthorNewsPieces();
            ClearFields();
        }
        private void OnClearClick(object sender, EventArgs e)
        {
            ClearFields();
            GetAuthorNewsPieces();
            EnableAdd(true);
        }

        private void OnRowHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = newsDataGrid.SelectedRows[0];
            EnableAdd(false);
            if (row != null) SetSelectedRowItems(row);
        }
        #endregion
        #endregion

    }
}