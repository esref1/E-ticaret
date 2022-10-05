using Core.Results;
using Entities;

namespace Business.Abstract
{
    public interface ICategoriesService
    {
        public Task<IResult> AddAsync(Categories data);
        public Task<IResult> UpdateAsync(Categories data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IList<Categories>> GetAllCategoriesAsync();
        public Task<Categories> GetAllProductsFirstCategoriesAsync(int CategoriesId);
        public Task<Categories> GetFirstCategoriesAsync(int CategoriesId);
    }
}
