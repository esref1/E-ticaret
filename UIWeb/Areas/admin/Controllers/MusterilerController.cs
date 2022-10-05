using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class MusterilerController : Controller
    {
        private readonly ICustomerService service;
        public MusterilerController(ICustomerService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllCustomersAsync().Result);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Customers data)
        {
            return View(service.AddAsync(data).Result);
        }
        [Route("/admin/musteriler/update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetFirstCustomersAsync(Id).Result);
        }
        [HttpPost]
        [Route("/admin/musteriler/update/{Id}")]
        public IActionResult Update(int Id,Customers data)
        {
            ViewBag.Message = service.UpdateAsync(data).Result;
            return View(service.GetFirstCustomersAsync(Id).Result);
        }
        [Route("/admin/musteriler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            TempData["Message"] = service.DeleteAsync(Id).Result;
            return Redirect("/admin/Musteriler");
        }
    }
}
