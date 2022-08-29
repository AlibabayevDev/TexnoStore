using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface IAllProductService
    {
        List<BaseModel> GetAllProduct();
        BaseModel AllProduct(int id);
        ShopCartModel QuickViewProduct(int id);
    }
}
