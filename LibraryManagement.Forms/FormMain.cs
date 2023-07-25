using LibraryManagement.Access.Interfaces;
using LibraryManagement.Business;
using LibraryManagement.Forms.Properties;
using LibraryManagement.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace LibraryManagement.Forms
{
    public partial class FormMain : Form
    {
        private readonly DbConnection _connection;
        private readonly BookDataService _bookDataService;
        private readonly IDataAccess<Book> _bookDataAccess;

        public FormMain()
        {
            // Data service list in memory
            //_bookDataAccess = new Access.Memory.BookDataAccess();

            // Data service with file
            //_bookDataAccess = new Access.File.BookDataAccess("Books.dat");

            // Data service in database
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // -> With native SQL
            //_connection = new SqliteConnection(config.GetConnectionString("SQLiteConnectionString"));
            //_bookDataAccess = new Access.Db.BookDataAccess(_connection);
            // -> With EFCore
            _connection = new SqliteConnection(config.GetConnectionString("SQLiteCoreConnectionString"));
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<Access.Core.DataContext>()
                .UseSqlite(_connection);
            _bookDataAccess = new Access.Core.BookDataAccess(new Access.Core.DataContext(builder.Options));


            _bookDataService = new BookDataService(_bookDataAccess);
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridViewData.DataSource = null;
            dataGridViewData.DataSource = _bookDataService.Books;

            dataGridViewData.Columns[nameof(BaseModel.Id)].DisplayIndex = 0;
            dataGridViewData.Columns[nameof(Book.ISBN)].DisplayIndex = 1;
            dataGridViewData.Columns[nameof(Book.Title)].DisplayIndex = 2;
            dataGridViewData.Columns[nameof(Book.Title)].HeaderText = FormResource.Text_Title;
            dataGridViewData.Columns[nameof(Book.Author)].DisplayIndex = 3;
            dataGridViewData.Columns[nameof(Book.Author)].HeaderText = FormResource.Text_Author;

            dataGridViewData.AutoResizeColumns();

            buttonDelete.Enabled = (dataGridViewData.Rows.Count > 0);
            buttonUpdate.Enabled = (dataGridViewData.Rows.Count > 0);
        }

        private void dataGridViewData_SelectionChanged(object sender, EventArgs e)
        {
            _bookDataService.Current = null;

            try
            {
                _bookDataService.Current = (sender as DataGridView)?.CurrentRow?.DataBoundItem as Book;
            }
            catch { }
        }

        private void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (sender == buttonCreate)
                _bookDataService.Current = new();

            if (new FormData(_bookDataService).ShowDialog() == DialogResult.OK)
                FormMain_Load(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(FormResource.Text_ReallyDelete, nameof(MessageBoxIcon.Warning), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            _bookDataService.Remove(_bookDataService.Current.Id);
            FormMain_Load(sender, e);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) => _bookDataAccess?.Dispose();
    }
}