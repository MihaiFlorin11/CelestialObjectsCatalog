namespace Application.Abstraction
{
    public class BaseEntityModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
