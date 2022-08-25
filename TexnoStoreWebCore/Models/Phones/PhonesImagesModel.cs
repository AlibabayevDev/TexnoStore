using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStoreWebCore.Models.Phones
{
    public class PhonesImagesModel
    {
        public int Id { get; set; }
        public virtual PhoneModel Phone { get; set; }
        public virtual List<Image> Image { get; set; }
    }
}
