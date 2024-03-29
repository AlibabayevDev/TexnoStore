﻿using System.Collections.Generic;

namespace TexnoStoreWebCore.Models.Laptops
{
    public class LaptopModel :BaseModel
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
        public CategoryModel Category { get; set; }
        public ProductImagesModel LaptopsImages { get; set; }
    }
}
