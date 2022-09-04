using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface IShopCartService
    {
        List<ShopCartModel> ShopCartList(int id);
        double ShopCartPrice(int id);
        void Delete(int id);
    }
}
