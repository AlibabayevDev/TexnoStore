using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Domain.Entities
{
	public class ShopCart 
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int LaptopId { get; set; }
		public int PhoneId { get; set; }

	}
}
