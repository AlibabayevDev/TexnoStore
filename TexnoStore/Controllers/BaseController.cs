using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Core.Domain.Entities.Cameras;
using TexnoStore.Core.Domain.Entities.Laptop;
using TexnoStore.Core.Domain.Entities.Phone;
using TexnoStore.Mapper;
using TexnoStore.Models;
using TexnoStore.Models.Cameras;
using TexnoStore.Models.Laptops;
using TexnoStore.Models.Phones;
using TexnoStoreWebCore.Mapper;
using TexnoStoreWebCore.Mapper.Cameras;
using TexnoStoreWebCore.Mapper.Laptops;
using TexnoStoreWebCore.Mapper.Phones;
using TexnoStoreWebCore.Models;
using TexnoStoreWebCore.Models.Cameras;
using TexnoStoreWebCore.Models.Laptops;
using TexnoStoreWebCore.Models.Phones;

namespace TexnoStore.Controllers
{
    public  class BaseController : Controller
    {
        private readonly IUnitOfWork db;

		public AllProductsListViewModel Checkout()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userid = db.LoginRepository.Get(User.Identity.Name);




                var user = db.ShopCartRepository.GetAll(userid.Id);
                var laptops = db.LaptopRepository.Laptops();
                var laptopModel = LaptopsModels(laptops);
                var phones = db.PhoneRepository.Phones();
                var phonesModel = PhoneModels(phones);

                AllProductsListViewModel shopcartproducts = new AllProductsListViewModel();

                var laptoplist = new List<LaptopModel>();
                var phonelist = new List<PhoneModel>();

                shopcartproducts.LaptopModel = laptoplist;
                shopcartproducts.PhoneModel = phonelist;
                return shopcartproducts;
            }
            else
            {
                var shopcartproducts = new AllProductsListViewModel()
                {
                    LaptopModel = new List<LaptopModel>(),
                    PhoneModel = new List<PhoneModel>()
                };
                return shopcartproducts;
            }
            
        }

        public List<LaptopModel> LaptopsModels(List<Laptop> laptops)
        {
            LaptopMapper laptopMapper = new LaptopMapper();
            List<LaptopModel> laptopsModels = new List<LaptopModel>();

            for (int i = 0; i < laptops.Count; i++)
            {
                var laptop = laptops[i];
                var laptopModel = laptopMapper.Map(laptop);

                laptopsModels.Add(laptopModel);
            }

            return laptopsModels;
        }


        public List<PhoneModel> PhoneModels(List<Phone> phones)
        {
            PhoneMapper phoneMapper = new PhoneMapper();
            List<PhoneModel> phonesModels = new List<PhoneModel>();

            for (int i = 0; i < phones.Count; i++)
            {
                var phone = phones[i];
                var phoneModel = phoneMapper.Map(phone);

                phonesModels.Add(phoneModel);
            }

            return phonesModels;
        }

        public List<CameraModel> CameraModels(List<Camera> cameras)
        {
            CameraMapper cameraMapper = new CameraMapper();
            List<CameraModel> cameraModels = new List<CameraModel>();

            for(int i = 0; i < cameras.Count; i++)
            {
                var camera = cameras[i];
                var cameraModel = cameraMapper.Map(camera);

                cameraModels.Add(cameraModel);
            }

            return cameraModels;
        }

        public List<BaseModel> BaseModels(List<BaseEntity> products)
        {
            BaseMapper baseMapper = new BaseMapper();
            List<BaseModel> productsModels = new List<BaseModel>();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                var productModel = baseMapper.Map(product);

                productsModels.Add(productModel);
            }

            return productsModels;
        }
    }
}
