using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Laptops;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface ILaptopService
    {
        List<LaptopModel> Laptops();
        LaptopModel LaptopProduct(int id);
        List<ReviewModel> Reviews(int id);
        string AddReview(ReviewModel model);
    }
}
