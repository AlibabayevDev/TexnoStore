using System.Collections.Generic;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;

namespace TexnoStore.Models
{
    public class ShopCartListViewModel : BaseModel
    {
        public IEnumerable<ShopCartModel> ShopCartModels { get; set; }
        public double ShopCartPrice { get; set; }
        public int ShopCartCount = 0;
    }
}
