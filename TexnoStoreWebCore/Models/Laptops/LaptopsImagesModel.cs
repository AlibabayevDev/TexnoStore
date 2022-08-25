using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStoreWebCore.Models.Laptops
{
    public class LaptopsImagesModel
    {
        public int Id { get; set; }
        public virtual LaptopModel Laptop { get; set; }
        public virtual List<Image> Image { get; set; }
    }
}
