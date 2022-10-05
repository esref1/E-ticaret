using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    public class CikisController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            TempData["CikisMesaji"] = "Güvenli Bir Şekilde Çıkış Yapıldı";
            return Redirect("/Uyelik");
        }
    }
}
