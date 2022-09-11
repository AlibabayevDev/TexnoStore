namespace TexnoStore.Core.Domain.Entities.Laptop
{
    public class Laptop:BaseEntity
    {
        public int ImageId { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public string RAM { get; set; }
        public string OperatingSystem { get; set; }
        public string GraphicsCoprocessor { get; set; }
        public string ScreenMatrix { get; set; }
        public string Weight { get; set; }
        public string Display { get; set; }
        public string ScreenSize { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public ProductImages LaptopsImages { get; set; }
    }
}
