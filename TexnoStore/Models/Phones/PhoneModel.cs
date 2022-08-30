using System.Collections.Generic;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Models.Phones
{
    public class PhoneModel : BaseModel
    {
        public int ImageId { get; set; }
        public CategoryModel Category { get; set; }
        public PhonesImagesModel PhonesImages { get; set; }
    }
}
