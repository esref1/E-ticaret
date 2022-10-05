using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class SiparislerController : Controller
    {
        private readonly IOrdersRelationService service;
        public SiparislerController(IOrdersRelationService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAllOrders().Result);
        }
        [Route("/admin/Detay/{Id}")]
        public IActionResult Detay(int Id)
        {
            var adata = service.GetOrdersRelationById(Id).Result;
            return View(service.GetOrdersRelationById(Id).Result);
        }

    }
}
