namespace LoggerApplication.Repository.Domain
{
    public abstract class BaseWithIdEntity : BaseEntity
    {
        public int Id { get; set; }
    }
}
