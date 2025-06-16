using Utils.Enums;

namespace Delegate_Nullable_Types.Models
{
    public class User : BaseEntity
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public User(string username, string email, Role role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Role = role;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Username: {Username}, Email: {Email}, Role: {Role}");
        }
    }

}
