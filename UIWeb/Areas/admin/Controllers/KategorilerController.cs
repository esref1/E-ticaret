using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class KategorilerController : Controller
    {
        private readonly ICategoriesService service;

        public KategorilerController(ICategoriesService service)
        {
            this.service = service;
        }

        // Kategoriler Listeleniyor.
        public IActionResult Index()
        {
            return View(service.GetAllCategoriesAsync().Result);
        }
        
        // Ekleme Yapılacak Olan Sayfayı açmamızı sağlayan Metot.
        public IActionResult Insert()
        {
            return View();
        }

        // Kategoriler Insert Sayfasında Kaydet butonuna Tıklandığında Tetiklenen Metot ve Sayfa Yenilendikten sonra Sayfadan çıkana Aktif Olarak Kalan Metottur.
        [HttpPost]
        public IActionResult Insert(Categories data)
        {
            return View(service.AddAsync(data).Result);
        }

        // Update işlemleri ID Bilgisine göre yapılacağından dolayı URL yapısının bir Kısmının Dinamik olması zorunludur. Nedeni ise ID Dinamik olsun ki hangi sayfa açıldığında ID bilgisini URL üzerinden okuyup güncelleme yaptıralım.

        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetFirstCategoriesAsync(Id).Result);
        }
        [HttpPost]
        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id,Categories data)
        {
            data.Id = Id;
            ViewBag.Message = service.UpdateAsync(data).Result;

            // Güncelleme Yapıldıktan Sonra Güncellenen verileri görebilmek için Dataları tekrar Çekmemiz gerekmektedir.
            return View(service.GetFirstCategoriesAsync(Id).Result);
        }

        // 5dk geliyom
        [Route("/admin/Kategoriler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            TempData["Message"] = service.DeleteAsync(Id).Result;
            return Redirect("/admin/Kategoriler");
        }
    }
}
