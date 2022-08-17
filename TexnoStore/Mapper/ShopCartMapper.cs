using TexnoStore.Core.Domain.Entities;
using TexnoStore.Mapper.Laptops;
using TexnoStore.Models;

namespace TexnoStore.Mapper
{
	public class ShopCartMapper
	{
		public readonly LaptopMapper laptopMapper = new LaptopMapper();
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
				LongDesc=model.LognDesc,
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
				LognDesc = entity.LongDesc,
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
