using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;
using TexnoStore.Core.Domain.Entities;
using TexnoStore.Mapper;
using TexnoStore.Models.Laptops;

namespace TexnoStore.Controllers
{
    public abstract class BaseController : Controller
    {
        public abstract IActionResult ShopCart(LaptopListViewModel viewModel);

        public abstract IActionResult ShopCartbyId(int Id);
        
    }
}
