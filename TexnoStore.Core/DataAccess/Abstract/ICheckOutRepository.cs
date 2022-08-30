using TexnoStore.Core.Domain.Entities;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface ICheckOutRepository
    {
        bool Insert(OrderDetails model);
        bool InsertOrderProducts(int id);
    }
}
