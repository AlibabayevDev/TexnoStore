using System.Collections.Generic;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;

namespace TexnoStore.Models
{
    public class AllProductsListViewModel : BaseModel
    {
        public IEnumerable<LaptopModel> LaptopModel { get; set; }
        public IEnumerable<PhoneModel> PhoneModel { get; set; }
    }
}
