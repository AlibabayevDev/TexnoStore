using TexnoStore.Core.Domain.Entities;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Models;
using TexnoStoreWebCore.Models;

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
				ProductId = model.ProductId,
				Count = model.Count,
				Name = model.Name,
				AddDate = model.AddDate,
				Sale = model.Sale,
				LongDesc=model.LongDesc,
				MainImg = model.MainImg,
				ShortDesc=model.ShortDesc,
				OldPrice = model.OldPrice,
				Price = model.Price,
				ProductType = model.ProductType,
			};
		}

		public ShopCartModel Map(ShopCart entity)
		{
			return new ShopCartModel()
			{
				Id = entity.Id,
				UserId = entity.UserId,
				ProductId = entity.ProductId,
				Count = entity.Count,
				Name = entity.Name,
				AddDate = entity.AddDate,
				LongDesc = entity.LongDesc,
				MainImg = entity.MainImg,
				ShortDesc = entity.ShortDesc,
				Price = entity.Price,
				OldPrice =entity.OldPrice,
				Sale = entity.Sale,
				ProductType=entity.ProductType,	
			};
		}
	}
}
