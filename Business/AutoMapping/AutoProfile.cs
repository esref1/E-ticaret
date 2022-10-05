using AutoMapper;
using Entities.DTO;

namespace Business.AutoMapping
{
    public class AutoProfile:Profile
    {
        public AutoProfile()
        {
            //Veritabanından Gelen NESNE, Dto NESNE'sine dönüştürülme istendiğini Kabul et diyoruz.
            CreateMap<Products, DtoProducts>();// Entity To Dto Convert
            //Veritabanından Gelen NESNE, Dto NESNE'sine dönüştürülme istendiğini Kabul et diyoruz.
            // Arayüzden Gelen DTO Nesne'sini Veritabanı NESNE'sine dönüştürülme istendiğini Kabul et diyoruz.

            CreateMap<Products, DtoProductsCrud>().ReverseMap(); //Entity To Dto Convert -- Dto To Entity Convert

            // Bu Sınıf Ayağa Kalktığı Zaman Bütün Dönüştürmeler Aktif Olarak Hazır Bekler.


            // Aşağıdaki Gibi Sistemi Çalıştırmak istiyorsak, Lazy Load Mantığı Kullanmamız gerekmektedir.
            // Sınıf Ayağa Kalktığında Hangisi Kullanıldıysa O Hemen Hazırlanıp işleme Başlasın.

            // Lazy Load => Sistemleri kullanacağı zaman hazır edip, kullanıma sunan dahili bir kütüphanedir. 
        }
    }
}
