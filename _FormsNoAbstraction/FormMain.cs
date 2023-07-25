using LibraryManagement.Models;

namespace LibraryManagement.Forms
{
    public partial class FormMain : Form
    {
        private Book book;
        private List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                ISBN = "123-1234567890",
                Title = "Gregs Tagebuch",
                Author = "Greg"
            },
            new Book
            {
                Id = 2,
                ISBN = "321-1234567890",
                Title = "Eine unendliche Geschichte der Zeit",
                Author = "Stephen Hawking"
            }
        };

        public FormMain()
        {
            this.InitializeComponent();
            this.Data_Reload();
        }

        private void Data_Reload()
        {
            this.dataGridViewData.DataSource = null;
            this.dataGridViewData.DataSource = this.books;

            if (this.dataGridViewData.RowCount == 0)
                this.Button_Status(false);
            else
                this.Button_Status(true);
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
                b = new Book();

            if (new FormData(this.books, b).ShowDialog() != DialogResult.OK)
                return;

            this.Data_Reload();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Wirklich löschen?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.books.Remove(book);
                this.Data_Reload();
            }
        }

        private void dataGridViewData_SelectionChanged(object sender, EventArgs e)
        {
            this.book = null;

            if (this.dataGridViewData.CurrentRow.DataBoundItem is not null)
                this.book = dataGridViewData.CurrentRow.DataBoundItem as Book;
        }
    }
}
