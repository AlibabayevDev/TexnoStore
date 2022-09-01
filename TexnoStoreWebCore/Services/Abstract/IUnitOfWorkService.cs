using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStoreWebCore.Services.Abstract
{
    public interface IUnitOfWorkService
    {
        ICameraService CameraService { get; }
        ILaptopService LaptopService { get; }
        IAllProductService AllProductService { get; }
        IHomeService HomeService { get; }
        IPhoneService PhoneService { get; }
    }
}
