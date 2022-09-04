using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;
using TexnoStoreWebCore.Models;

namespace TexnoStore.Models.Phones
{
    public class PhoneListViewModel : BaseModel
    {
        public IEnumerable<PhoneModel> Phones { get; set; }
        public PhoneModel Phone { get; set; }
        public List<ReviewModel> Reviews { get; set; }
        public ShopCartModel ShopCart { get; set; }
        public ReviewModel Review { get; set; }
    }
}
