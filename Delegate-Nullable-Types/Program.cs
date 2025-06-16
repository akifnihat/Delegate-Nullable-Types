using Delegate_Nullable_Types.Models;
using Utils.Enums;

namespace Delegate_Nullable_Types
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Role role;
            while (true)
            {
                Console.WriteLine("Enter role (Admin/Member):");
                if (Enum.TryParse<Role>(Console.ReadLine(), out role))
                    break;
                Console.WriteLine("Invalid role. Try again.");
            }

            User user = new User(username, email, role);
            user.ShowInfo();

            Library library = new Library(10);

            int choice;
            do
            {
                Console.WriteLine("\n1. Add book\n2. Get book by id\n3. Get all books\n4. Delete book by id\n5. Edit book name\n6. Filter by page count\n0. Quit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Only admins can add books!");
                                break;
                            }
                            Console.Write("Enter book name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter author name: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter page count: ");
                            int pages = int.Parse(Console.ReadLine());
                            Book book = new Book(name, author, pages);
                            library.AddBook(book);
                            Console.WriteLine("Book added.");
                            break;

                        case 2:
                            Console.Write("Enter book id: ");
                            int id2 = int.Parse(Console.ReadLine());
                            var b2 = library.GetBookById(id2);
                            if (b2 == null)
                                Console.WriteLine("Book not found.");
                            else
                                b2.ShowInfo();
                            break;

                        case 3:
                            var all = library.GetAllBooks();
                            all.ForEach(b => b.ShowInfo());
                            break;

                        case 4:
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Only admins can delete books!");
                                break;
                            }
                            Console.Write("Enter book id to delete: ");
                            int id4 = int.Parse(Console.ReadLine());
                            library.DeleteBookById(id4);
                            Console.WriteLine("Deleted.");
                            break;

                        case 5:
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Only admins can edit books!");
                                break;
                            }
                            Console.Write("Enter book id to edit: ");
                            int id5 = int.Parse(Console.ReadLine());
                            Console.Write("Enter new name: ");
                            string newName = Console.ReadLine();
                            library.EditBookName(id5, newName);
                            Console.WriteLine("Name updated.");
                            break;

                        case 6:
                            Console.Write("Enter min pages: ");
                            int min = int.Parse(Console.ReadLine());
                            Console.Write("Enter max pages: ");
                            int max = int.Parse(Console.ReadLine());
                            var filtered = library.FilterByPageCount(min, max);
                            filtered.ForEach(b => b.ShowInfo());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            } while (choice != 0);

        }
    }
}
