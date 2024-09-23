using iTi_day_15_lab.Models;

namespace iTi_day_15_lab
{
    public partial class Form1 : Form
    {
        int newsId = 0;
        Author author;
        NewsArchiveContext context;

        public Form1()
        {
            InitializeComponent();
            context = new NewsArchiveContext();
            author = new Author();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAuth();
            EnableAdd(true);
        }

        public void EnableNews(bool enable)
        {
            username_textbox.Visible = !enable;
            password_textbox.Visible = !enable;
            login_button.Visible = !enable;
            register_button.Visible = !enable;

            newsDataGrid.Visible = enable;
            title_textbox.Visible = enable;
            brief_textbox.Visible = enable;
            content_textbox.Visible = enable;
            category_combobox.Visible = enable;
            insert_button.Visible = enable;
            update_button.Visible = enable;
            delete_button.Visible = enable;
            clear_button.Visible = enable;
            signout_button.Visible = enable;
            welcome_message.Visible = enable;
        }

        public void ShowAuth()
            => EnableNews(false);
        public void ShowNews()
        {
            GetAuthorNewsPieces();
            GetCategories();

            EnableNews(true);
        }

        #region authentication page

        #region data queries
        public bool AuthorExist()
        {
            try
            {
                Author? author = context.Author?
                    .Where(author => author.Username == username_textbox.Text.ToLower())
                    .Single();
                return author != null;
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                return false;
            }
        }
        public Author GetAuthorByUsername()
        {
            Author? author
                = context.Author?
                .Where(author => author.Username == username_textbox.Text.ToLower())
                .SingleOrDefault();
            return author;
        }
        public void AddAuthor()
        {
            Author newAuthor = new Author()
            {
                Username = username_textbox.Text.ToLower(),
                Password = password_textbox.Text,
                JoinedAt = DateTime.UtcNow,
                Name = username_textbox.Text,
                Age = 24,
            };
            try
            {
                context.Author?.Add(newAuthor);
                context.SaveChanges();
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
            if (!AuthorExist())
            {
                MessageBox.Show("The author doesn't exist!");
                return;
            }
            Author author = GetAuthorByUsername();
            if (author.Password != password_textbox.Text)
            {
                MessageBox.Show("The password is incorrect!");
                return;
            }
            this.author = author;
            welcome_message.Text = author.Name;
            ShowNews();
        }
        private void OnRegisterClick(object sender, EventArgs e)
        {
            if (FieldsEmpty())
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (AuthorExist())
            {
                MessageBox.Show("This author already exist!");
                return;
            }
            AddAuthor();
            author = GetAuthorByUsername();
            welcome_message.Text = author.Name;
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
              .Where(newsPiece => newsPiece.AuthorId == author.Id)
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
        public void ShowProfile()
        {
            MessageBox
                .Show(Text = $"ID: {author.Id}\nName: {author.Name}\nAge: {author.Age}\nDate Joined: {author.JoinedAt}\n Username: {author.Username}", "Welcome!");
        }
        #endregion

        #region data queries
        public void InsertNewsPiece()
        {
            int categoryId = (int)category_combobox.SelectedValue;
            Author? newAuthor = context.Author?.Where(author => author.Id == this.author.Id).FirstOrDefault();
            Category? category
                = context.Category?
                .Where(category => category.Id == categoryId)
                .FirstOrDefault();
            NewsPiece newsPiece = new NewsPiece()
            {
                Author = newAuthor,
                AuthorId = author.Id,
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
        private void OnSignOutClick(object sender, EventArgs e)
        {
            username_textbox.Text = string.Empty;
            password_textbox.Text = string.Empty;
            ShowAuth();
        }
        private void OnNameClick(object sender, EventArgs e) => ShowProfile();

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