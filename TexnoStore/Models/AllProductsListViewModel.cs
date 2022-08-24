using System.Collections.Generic;
using TexnoStore.Models.Cameras;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;

namespace TexnoStore.Models
{
    public class AllProductsListViewModel : BaseModel
    {
        public IEnumerable<BaseModel> Products { get; set; }
        public IEnumerable<LaptopModel> LaptopModel { get; set; }
        public IEnumerable<PhoneModel> PhoneModel { get; set; }
        public IEnumerable<CameraModel> CameraModel { get; set; }
    }
}
