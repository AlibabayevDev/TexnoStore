using System;

namespace TexnoStore.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime AddDate { get; set; }
        public AllProductsListViewModel AllProductsListViewModel = new AllProductsListViewModel();
    }
}
