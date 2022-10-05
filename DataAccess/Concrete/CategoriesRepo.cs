using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    // Base Keyword'u üst sınıfın Yapıcı Metot'una erişip parametre göndermemizi sağlıyor.
    public class CategoriesRepo : Repositories<Categories>, ICategoriesRepo
    {
        public CategoriesRepo(DbContext context):base(context)
        {

        }
    }
}
