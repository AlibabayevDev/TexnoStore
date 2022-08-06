using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Laptops
{
    public class LaptopListViewModel : AllProductsListViewModel
    {
        public IEnumerable<LaptopModel> Laptops { get; set; }
        public LaptopModel Laptop { get; set; }
        public ShopCartModel ShopCart { get; set; }

        public List<ReviewModel> Reviews { get; set; }

        public ReviewModel Review { get; set; }
    }
}
