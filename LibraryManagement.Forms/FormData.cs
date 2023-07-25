using LibraryManagement.Business;
using LibraryManagement.Forms.Properties;
using LibraryManagement.Models;

namespace LibraryManagement.Forms
{
    public partial class FormData : Form
    {
        private readonly BookDataService _bookDataService;

        public FormData(BookDataService bookDataService)
        {
            _bookDataService = bookDataService ?? throw new NullReferenceException(nameof(BookDataService));

            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (_bookDataService.Current.Id == 0)
            {
                Text = FormResource.Text_Add;
                buttonDo.Text = string.Empty;
                buttonDo.Image = FormResource.Add;
                textBoxISBN.ReadOnly = false;
                return;
            }
            Text = FormResource.Text_Edit;
            textBoxISBN.Text = _bookDataService.Current.ISBN;
            textBoxTitle.Text = _bookDataService.Current.Title;
            textBoxAuthor.Text = _bookDataService.Current.Author;
            buttonDo.Text = string.Empty;
            buttonDo.Image = FormResource.Edit;
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            ClearError(textBoxISBN);
            ClearError(textBoxTitle);
            ClearError(textBoxAuthor);

            _bookDataService.Current.ISBN = textBoxISBN.Text;
            _bookDataService.Current.Title = textBoxTitle.Text;
            _bookDataService.Current.Author = textBoxAuthor.Text;

            try
            {
                _bookDataService.AddOrUpdate(_bookDataService.Current);
            }
            catch (ArgumentException ex)
            {
                switch (ex.ParamName)
                {
                    case nameof(Book.ISBN):
                        SetError(textBoxISBN, ex.Message);
                        break;
                    case nameof(Book.Title):
                        SetError(textBoxTitle, ex.Message);
                        break;
                    case nameof(Book.Author):
                        SetError(textBoxAuthor, ex.Message);
                        break;
                    default:
                        throw new Exception($"{nameof(KeyNotFoundException)}: {ex.ParamName}->{ex.Message}");
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, nameof(MessageBoxIcon.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetError(TextBox textBox, string message)
        {
            textBox.Focus();
            textBox.SelectAll();
            textBox.BackColor = Color.Red;
            errorProvider.SetError(textBox, message);
        }

        private void ClearError(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            errorProvider.SetError(textBox, string.Empty);
        }
    }
}
