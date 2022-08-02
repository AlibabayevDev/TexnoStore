namespace TexnoStore.Core.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime AddDate { get; set; }
    }
}
