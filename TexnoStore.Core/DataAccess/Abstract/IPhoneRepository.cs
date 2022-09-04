using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Phone;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface IPhoneRepository : IMainRepository
    {
        List<Phone> Phones();
        Phone PhoneProduct(int productId);
        List<Phone> SearchPhones(string Name);

    }
}
