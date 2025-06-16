
namespace Delegate_Nullable_Types.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Book(string name, string authorName, int pageCount)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            PageCount = pageCount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Author: {AuthorName}, Pages: {PageCount}, IsDeleted: {IsDeleted}");
        }
    }

}
