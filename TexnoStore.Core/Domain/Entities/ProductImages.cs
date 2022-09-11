using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.Domain.Entities
{
    public class ProductImages
    {
        public int Id { get; set; }
        public virtual BaseEntity Product { get; set; }
        public virtual List<Image> Image { get; set; }
    }
}
