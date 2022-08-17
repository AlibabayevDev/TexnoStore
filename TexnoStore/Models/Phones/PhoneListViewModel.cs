using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Phones
{
    public class PhoneListViewModel : BaseModel
    {
        public IEnumerable<PhoneModel> Phones { get; set; }
        public PhoneModel Phone { get; set; }
    }
}
