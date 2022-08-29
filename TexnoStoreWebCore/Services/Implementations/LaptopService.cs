using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Mapper.Laptops;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Laptops;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
    public class LaptopService : ILaptopService
    {
        public readonly IUnitOfWork db;
        public LaptopService(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<LaptopModel> Laptops()
        {
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopModels.Add(laptopModel);
            }

            return laptopModels;
        }


        public LaptopModel LaptopProduct(int id)
        {
            var laptops = db.LaptopRepository.Laptops();

            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopModels.Add(laptopModel);
            }

            return laptopModels.FirstOrDefault(x => x.Id == id);
        }

        public string AddReview(ReviewModel model)
        {
            string ErrorMessage;

            ReviewMapper reviewMapper = new ReviewMapper();

            var review = reviewMapper.Map(model);
            try
            {
                db.ReviewRepository.Add(review);
                ErrorMessage = "Succesfully added";

            }
            catch (Exception ex)
            {
                ErrorMessage = "Something went wrong";
            }

            return ErrorMessage;
        }
    }
}
