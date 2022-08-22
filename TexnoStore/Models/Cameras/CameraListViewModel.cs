using System.Collections;
using System.Collections.Generic;

namespace TexnoStore.Models.Cameras
{
    public class CameraListViewModel : AllProductsListViewModel
    {
        public IEnumerable<CameraModel> Cameras { get; set; }
        public CameraModel Camera { get; set; }

        public ShopCartModel ShopCartModel { get; set; }

        public List<ReviewModel> Reviews { get; set; }

        public ReviewModel Review { get; set; }
    }
}
