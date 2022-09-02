using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface ICheckOutService
    {
        List<ShopCartModel> CheckOutProducts(int id);
    }
}
