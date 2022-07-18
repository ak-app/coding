using LibraryManagement.Core;
using LibraryManagement.Domain;
using LibraryManagement.Domain.Exeptions;

namespace LibraryManagement.Forms
{
    public partial class FormData : Form
    {
        private IDataService<Book> dataService;
        private Book book;

        public FormData(IDataService<Book> dataService, Book book)
        {
            InitializeComponent();

            this.book = book;
            this.dataService = dataService;
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (this.book.Id == 0)
            {
                this.Text = Resource.DataResource.Add;
                this.buttonDo.Text = Resource.DataResource.Add;
            }
            else
            {
                this.Text = Resource.DataResource.Update;
                this.buttonDo.Text = Resource.DataResource.Update;

                this.textBoxISBN.ReadOnly = true;
                this.textBoxISBN.Text = this.book.ISBN;
                this.textBoxTitle.Text = this.book.Title;
                this.textBoxAutor.Text = this.book.Author;
            }
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            this.TextBoxClearError(new[]
            {
                this.textBoxISBN,
                this.textBoxTitle,
                this.textBoxAutor
            });

            this.book.ISBN = this.textBoxISBN.Text;
            this.book.Title = this.textBoxTitle.Text;
            this.book.Author = this.textBoxAutor.Text;

            try
            {
                if (this.book.Id == 0)
                {
                    this.dataService.Insert(this.book);
                }
                else
                {
                    this.dataService.Update(this.book.Id, this.book);
                }
            }
            catch (BookException bookex)
            {
                switch (bookex.Accessor)
                {
                    case nameof(Book.ISBN):
                        this.TextBoxShowError(textBoxISBN, bookex.Message);
                        break;
                    case nameof(Book.Title):
                        this.TextBoxShowError(textBoxTitle, bookex.Message);
                        break;
                    case nameof(Book.Author):
                        this.TextBoxShowError(textBoxAutor, bookex.Message);
                        break;
                    default:
                        MessageBox.Show(bookex.Message, Resource.DataResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resource.DataResource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TextBoxShowError(TextBox textBox, string message)
        {
            this.errorProvider.SetError(textBox, message);

            textBox.BackColor = Color.Red;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void TextBoxClearError(IEnumerable<TextBox> textBoxes)
        {
            textBoxes.ToList().ForEach(t =>
            {
                this.errorProvider.SetError(t, string.Empty);
                t.BackColor = Color.White;
            });
        }
    }
}
