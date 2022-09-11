using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStoreWebCore.Models
{
    public class ProductImagesModel
    {
        public int Id { get; set; }
        public virtual BaseModel Product { get; set; }
        public virtual List<Image> Image { get; set; }
    }
}
