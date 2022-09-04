using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStoreWebCore.Models.Phones;

namespace TexnoStoreWebCore.Services.Abstract
{
	public interface IPhoneService
	{
		List<PhoneModel> Phones();
		PhoneModel PhoneProduct(int id);
		List<PhoneModel> SearchPhones(string name);
	}
}
