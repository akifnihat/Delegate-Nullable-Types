
using Utils.Enums;

namespace Delegate_Nullable_Types
{
    public class User:IEntity
    {
        private static int _idCounter = 0;
        public int Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public User(string username, string email, Role role)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username bos ola bilmez");
            
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email bos ola bilmez");

            Username = username;
            Email = email;
            Role = role;
            Id = ++_idCounter;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Username: {Username}, Email: {Email}, Role: {Role}");
        }
    }
}
