using TexnoStore.Core.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TexnoStore.Mapper.Phones;
using TexnoStore.Models.Phones;

namespace TexnoStore.Controllers
{
    public class PhoneController : BaseController
    {
        private readonly IUnitOfWork db;

        public PhoneController(IUnitOfWork db) : base(db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var phones = db.PhoneRepository.Phones();

            PhoneMapper phoneMapper = new PhoneMapper();
            List<PhoneModel> phonesModels = new List<PhoneModel>();

            for (int i = 0; i < phones.Count; i++)
            {
                var phone = phones[i];
                var phoneModel = phoneMapper.Map(phone);

                phonesModels.Add(phoneModel);
            }
            var model = new PhoneListViewModel
            {
                Phones = phonesModels,
            };
            return View(model);
        }

        public IActionResult PhoneProduct(int id)
        {
            var phones = db.PhoneRepository.Phones();

            PhoneMapper phoneMapper = new PhoneMapper();
            List<PhoneModel> phonesModels = new List<PhoneModel>();

            for (int i = 0; i < phones.Count; i++)
            {
                var phone = phones[i];
                var phoneModel = phoneMapper.Map(phone);

                phonesModels.Add(phoneModel);
            }
            var model = new PhoneListViewModel
            {
                Phone = phonesModels.FirstOrDefault(x => x.Id == id),
            };

            return View(model);
        }
    }
}
