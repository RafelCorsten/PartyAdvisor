namespace Domain.Common
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsDeleted { get; protected set; }
    }
}
