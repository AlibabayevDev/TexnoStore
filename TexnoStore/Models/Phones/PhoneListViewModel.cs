using System.Collections.Generic;
using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Models.Phones
{
    public class PhoneListViewModel : BaseEntity
    {
        public IEnumerable<PhoneModel> Phones { get; set; }
    }
}
