using LibraryManagement.Core;
using LibraryManagement.DataAccess;
using LibraryManagement.Domain;
using System.Data.SQLite;

namespace LibraryManagement.Forms
{
    public partial class FormMain : Form
    {
        private IDataService<Book> listDataService = new ListDataService();
        private IDataService<Book> sqliteDataService2 = new SQLiteDataService(new("Data Source=Library.db"));

        private IDataService<Book> dataService = 
            new DbDataService(
                new SQLiteConnection("Data Source=Library.db"),
                new DirectoryInfo(@".\Databases\SQL\SQLite\"));
        private Book book;

        public FormMain()
        {
            InitializeComponent();

            this.dataGridViewData.DataSource = this.dataService.Get();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (this.dataGridViewData.RowCount == 0)
                Button_Status(false);
        }

        private void Data_Reload()
        {
            this.dataGridViewData.DataSource = null;
            this.dataGridViewData.DataSource = this.dataService.Get();

            if (this.dataGridViewData.RowCount == 0)
                Button_Status(false);
            else
                Button_Status(true);
        }

        private void Button_Status(bool status)
        {
            this.buttonUpdate.Enabled = status;
            this.buttonDelete.Enabled = status;
        }

        private void buttonCreateOrUpdate_Click(object sender, EventArgs e)
        {
            Book b = this.book;

            if (sender == buttonCreate)
            {
                b = new Book();
            }

            if (new FormData(this.dataService, b).ShowDialog() != DialogResult.OK)
                return;

            this.Data_Reload();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.DataResource.DeleteMessage, Resource.DataResource.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dataService.Delete(book.Id);
                this.Data_Reload();
            }
        }

        private void dataGridViewData_SelectionChanged(object sender, EventArgs e)
        {
            book = null;

            try
            {
                book = dataGridViewData.CurrentRow.DataBoundItem as Book;
            }
            catch { }
        }
    }
}
