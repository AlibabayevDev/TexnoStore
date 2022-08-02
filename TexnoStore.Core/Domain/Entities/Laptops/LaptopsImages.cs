namespace TexnoStore.Core.Domain.Entities.Laptop
{
    public class LaptopsImages
    {
        public int Id { get; set; }
        public virtual Laptop Laptop { get; set; }
        public virtual List<Image> Img { get; set; }
    }
}
