using System.Collections.Generic;

namespace TexnoStore.Models.Phones
{
    public class PhoneModel : BaseEntity
    {
        public string LognDesc { get; set; }
        public int Sale { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int ImageId { get; set; }
        public string MainImg { get; set; }
        public CategoryModel Category { get; set; }
        public PhonesImagesModel PhonesImages { get; set; }
    }
}
