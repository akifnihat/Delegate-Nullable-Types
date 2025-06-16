namespace Delegate_Nullable_Types
{
    public abstract class BaseEntity : IEntity
    {
        private static int _idCounter = 1;
        public int Id { get; }

        public BaseEntity()
        {
            Id = _idCounter++;
        }
    }
}
