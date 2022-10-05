using Business.Abstract;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class UrunlerController : Controller
    {
        private readonly IProductsService service;
        private readonly ICategoriesService categoriesService;
        public UrunlerController(IProductsService service, ICategoriesService categoriesService)
        {
            this.service = service;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            return View(service.GetAllProducts().Result);
        }
        public IActionResult Insert()
        {
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile MainImages, DtoProductsCrud data, IList<IFormFile> resimler)
        {
            string AnaResimResponse = Helpers.ImagesUpload.Upload(MainImages);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                data.MainImage = AnaResimResponse;
            }
            int i = 0;
            string[] isimler = { "", "", "", "" };
            foreach (var item in resimler)
            {
                string ResimAdi = Helpers.ImagesUpload.Upload(item);
                if (ResimAdi != "0" && ResimAdi != "1")
                {
                    isimler[i] = ResimAdi;
                    i++;
                }
            }
            if (isimler[0] != "") { data.Images1 = isimler[0]; }
            if (isimler[1] != "") { data.Images2 = isimler[1]; }
            if (isimler[2] != "") { data.Images3 = isimler[2]; }
            if (isimler[3] != "") { data.Images4 = isimler[3]; }

            ViewBag.Message = service.AddAsync(data).Result;
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View();
        }
        [Route("/admin/urunler/update/{Id}")]
        public IActionResult Update(int Id)
        {
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View(service.GetRelationProduct(Id).Result);
        }
        [Route("/admin/urunler/update/{Id}")]
        [HttpPost]
        public IActionResult Update(int Id, IFormFile MainImages, Products data, IList<IFormFile> resimler)
        {
            string AnaResimResponse = Helpers.ImagesUpload.Upload(MainImages);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse != "1")
            {
                Helpers.ImagesUpload.ImagesDelete(data.MainImage);
                data.MainImage = AnaResimResponse;
            }
            int i = 0;
            string[] isimler = { "", "", "", "" };
            foreach (var item in resimler)
            {
                string ResimAdi = Helpers.ImagesUpload.Upload(item);
                if (ResimAdi != "0" && ResimAdi != "1")
                {
                    isimler[i] = ResimAdi;
                    i++;
                }
            }
            if (isimler[0] != "") { Helpers.ImagesUpload.ImagesDelete(data.MainImage); data.Images1 = isimler[0]; }
            if (isimler[1] != "") { Helpers.ImagesUpload.ImagesDelete(data.MainImage); data.Images2 = isimler[1]; }
            if (isimler[2] != "") { Helpers.ImagesUpload.ImagesDelete(data.MainImage); data.Images3 = isimler[2]; }
            if (isimler[3] != "") { Helpers.ImagesUpload.ImagesDelete(data.MainImage); data.Images4 = isimler[3]; }

            ViewBag.Message = service.UpdateAsync(data).Result;
            ViewBag.Kategoriler = categoriesService.GetAllCategoriesAsync().Result;
            return View(service.GetRelationProduct(Id).Result);
        }

        [Route("/admin/urunler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            TempData["Message"] = service.DeleteAsync(Id);
            return Redirect("/admin/Urunler");
        }
    }
}
