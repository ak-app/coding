using LibraryManagement.Domain;
using System.Data;
using System.Text.RegularExpressions;

namespace LibraryManagement.Forms
{
    public partial class FormData : Form
    {
        private Book book;
        private List<Book> books;

        public FormData(List<Book> books, Book book)
        {
            this.InitializeComponent();

            this.book = book;
            this.books = books;
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (this.book.Id == 0)
            {
                this.Text = "Hinzufügen";
                this.buttonDo.Text = this.Text;
            }
            else
            {
                this.Text = "Bearbeiten";
                this.buttonDo.Text = this.Text;

                this.textBoxISBN.ReadOnly = true;
                this.textBoxISBN.Text = this.book.ISBN;
                this.textBoxTitle.Text = this.book.Title;
                this.textBoxAuthor.Text = this.book.Author;
            }
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            this.TextBoxClearError(new[]
            {
                this.textBoxISBN,
                this.textBoxTitle,
                this.textBoxAuthor
            });

            if(!this.Validate(textBoxISBN, "^[a-zA-Z0-9 ]{1,18}$"))
            {
                this.TextBoxShowError(textBoxISBN, "Titel darf nur Zahlen und Buchstaben enthalten (13:18)");
                return;
            }

            if (!this.Validate(textBoxTitle, "^[a-zA-Z0-9 ]{2,100}$"))
            {
                this.TextBoxShowError(textBoxISBN, "Titel darf nur Zahlen und Buchstaben enthalten (2:100)");
                return;
            }

            if (!this.Validate(textBoxAuthor, "^[a-zA-Z ]{2,100}$"))
            {
                this.TextBoxShowError(textBoxISBN, "Autor darf nur Buchstaben enthalten (2:100)");
                return;
            }

            this.book.ISBN = this.textBoxISBN.Text;
            this.book.Title = this.textBoxTitle.Text;
            this.book.Author = this.textBoxAuthor.Text;

            if(this.book.Id == 0)
            {
                this.book.Id = this.books.Count > 0 ? this.books.Last().Id + 1 : 1;
                this.books.Add(this.book);
            }
            else
            {
                Book b = this.books.Where(b => b.Id == this.book.Id).FirstOrDefault();
                b.Title = this.textBoxTitle.Text;
                b.Author = this.textBoxAuthor.Text;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool Validate(TextBox textBox, string pattern) => (new Regex(pattern).Match(textBox.Text).Success) ? true : false;

        private void TextBoxShowError(TextBox textBox, string message)
        {
            this.errorProvider.SetError(textBox, message);

            textBox.BackColor = Color.Red;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void TextBoxClearError(IEnumerable<TextBox> textBoxes)
        {
            textBoxes.ToList().ForEach(b =>
            {
                this.errorProvider.SetError(b, string.Empty);
                b.BackColor = Color.White;
            });
        }
    }
}
