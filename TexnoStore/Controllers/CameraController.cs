using Microsoft.AspNetCore.Mvc;
using TexnoStore.Core.DataAccess.Abstract;

namespace TexnoStore.Controllers
{
    public class CameraController : BaseController
    {
        private readonly IUnitOfWork db;
        public CameraController(IUnitOfWork db) : base(db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
