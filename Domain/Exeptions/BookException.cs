namespace LibraryManagement.Domain.Exeptions
{
    public class BookException : Exception
    {
        public BookException(string accessor, string message) : base(message) => this.Accessor = accessor;

        public string Accessor { get; set; }

        public override string Message => $"{this.Accessor}: {base.Message}";
    }
}
