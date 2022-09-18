using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        ILaptopRepository LaptopRepository { get; }
        IPhoneRepository PhoneRepository { get; }
        IAllProductRepository AllProductRepository { get; }
        ILoginRepository LoginRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IShopCartRepository ShopCartRepository { get; }
        ICameraRepository CameraRepository { get; }
        ICheckOutRepository CheckOutRepository { get; }
        ISubscribeRepository SubscribeRepository { get; }
    }
}
