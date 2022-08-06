using TexnoStore.Core.Domain.Entities;
using TexnoStore.Models;

namespace TexnoStore.Mapper
{
	public class ShopCartMapper
	{
		public ShopCart Map(ShopCartModel model)
		{
			return new ShopCart()
			{
				Id = model.Id,
				UserId = model.UserId,
				LaptopId = model.LaptopId,
				PhoneId = model.PhoneId,
			};
		}

		public ShopCartModel Map(ShopCart entity)
		{
			return new ShopCartModel()
			{
				Id = entity.Id,
				UserId = entity.UserId,
				LaptopId = entity.LaptopId,
				PhoneId = entity.PhoneId,
			};
		}
	}
}
