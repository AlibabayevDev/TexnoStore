﻿using TexnoStoreWebCore.Models;

namespace TexnoStore.Models
{
	public class ShopCartModel : BaseModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int Count { get; set; }
		public int ProductId { get; set; }
	}
}