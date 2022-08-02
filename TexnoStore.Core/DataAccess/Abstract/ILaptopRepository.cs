using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities.Laptop;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface ILaptopRepository : IMainRepository
    {
        List<Laptop> Laptops();
        List<Laptop> SearchLaptops(string Name);

    }
}
