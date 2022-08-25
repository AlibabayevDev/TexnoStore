using System.Collections.Generic;

namespace TexnoStoreWebCore.Models.Phones
{
    public class PhoneModel : BaseModel
    {
        public int ImageId { get; set; }
        public CategoryModel Category { get; set; }
        public PhonesImagesModel PhonesImages { get; set; }
    }
}
