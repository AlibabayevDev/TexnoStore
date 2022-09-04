using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStoreWebCore.Mapper.Phones;
using TexnoStoreWebCore.Models.Phones;
using TexnoStoreWebCore.Services.Abstract;

namespace TexnoStoreWebCore.Services.Implementations
{
	class PhoneService : IPhoneService
	{
		private readonly IUnitOfWork db;
		public PhoneService(IUnitOfWork db)
		{
			this.db = db;
		}

		public List<PhoneModel> Phones()
		{
			var phones = db.PhoneRepository.Phones();
			PhoneMapper phoneMapper = new PhoneMapper();
			List<PhoneModel> phoneModels = new List<PhoneModel>();

			for(int i = 0; i < phones.Count; i++)
			{
				var phone = phones[i];
				var phoneModel = phoneMapper.Map(phone);
				phoneModels.Add(phoneModel);
			}

			return phoneModels;
		}

		public PhoneModel PhoneProduct(int id)
		{
			var phoneProduct = db.PhoneRepository.PhoneProduct(id);
			PhoneMapper phoneMapper = new PhoneMapper();
			var phoneModel = phoneMapper.Map(phoneProduct);

			return phoneModel;
		}


		public List<PhoneModel> SearchPhones(string name)
		{
			var phones = db.PhoneRepository.SearchPhones(name);
			PhoneMapper phoneMapper = new PhoneMapper();
			List<PhoneModel> phoneModels = new List<PhoneModel>();

			for(int i = 0; i < phones.Count; i++)
			{
				var phone = phones[i];
				var phoneModel = phoneMapper.Map(phone);
				phoneModels.Add(phoneModel);
			}
			return phoneModels;
		}
	}
}
