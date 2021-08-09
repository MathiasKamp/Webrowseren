namespace WebApplication
{
    public class Book
    {
        public Book(int bookNumber, string bookName, int bookYear)
        {
            BookNumber = bookNumber;
            BookName = bookName;
            BookYear = bookYear;
        }

        public Book()
        {
        }

        public int BookNumber { get; set; }
        public string BookName { get; set; }
        public int BookYear { get; set; }
    }
}