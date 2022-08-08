using System.Collections.Generic;

namespace TexnoStore.Models.Laptops
{
    public class LaptopModel :BaseModel
    {
        public string LognDesc { get; set; }
        public int Sale { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int ImageId { get; set; }
        public string MainImg { get; set; }
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
        public string ShortDesc { get; set; }
        public CategoryModel Category { get; set; }
        public LaptopsImagesModel LaptopsImages { get; set; }
    }
}
