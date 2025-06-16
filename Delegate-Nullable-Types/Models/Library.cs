using Utils.Exceptions;
namespace Delegate_Nullable_Types.Models
{
    public class Library : BaseEntity
    {
        public int BookLimit { get; set; }
        private List<Book> _books = new List<Book>();

        public Library(int bookLimit)
        {
            BookLimit = bookLimit;
        }

        public void AddBook(Book book)
        {
            if (_books.Count(b => !b.IsDeleted) >= BookLimit)
                throw new CapacityLimitException("Book limit exceeded!");

            if (_books.Any(b => !b.IsDeleted && b.Name == book.Name))
                throw new AlreadyExistsException("This book already exists!");

            _books.Add(book);
        }

        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id cannot be null!");

            return _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        }

        public List<Book> GetAllBooks()
        {
            return _books.Where(b => !b.IsDeleted).ToList();
        }

        public void DeleteBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id cannot be null!");

            var book = _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            if (book == null)
                throw new NotFoundException("Book not found!");

            book.IsDeleted = true;
        }

        public void EditBookName(int? id, string newName)
        {
            if (id == null)
                throw new NullReferenceException("Id cannot be null!");

            var book = _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            if (book == null)
                throw new NotFoundException("Book not found!");

            book.Name = newName;
        }

        public List<Book> FilterByPageCount(int min, int max)
        {
            return _books.Where(b => !b.IsDeleted && b.PageCount >= min && b.PageCount <= max).ToList();
        }
    }

}
