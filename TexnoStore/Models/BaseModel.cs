using System;

namespace TexnoStore.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime AddDate { get; set; }
        public AllProductsListViewModel ShopCartList { get; set; }
    }
}
