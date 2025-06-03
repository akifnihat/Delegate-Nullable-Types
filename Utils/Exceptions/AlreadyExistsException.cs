
namespace Utils.Exceptions
{
    internal class AlreadyExistsException:Exception
    {
        public AlreadyExistsException():base()
        { 

        }

        public AlreadyExistsException(string message) : base(message)
        {

        }

    }
}
