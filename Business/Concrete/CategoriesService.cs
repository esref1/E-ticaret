using Core.Results;

namespace Business.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoCategories.AsyncDelete(x => x.Id == Id).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [LogAspect, PerformanceAspect]
        public async Task<IList<Categories>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.RepoCategories.AsyncGetAll();
        }
        [LogAspect, PerformanceAspect]
        public async Task<Categories> GetAllProductsFirstCategoriesAsync(int CategoriesId)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(x => x.Id == CategoriesId, x => x.Products);
        }
        [LogAspect, PerformanceAspect]
        public async Task<Categories> GetFirstCategoriesAsync(int CategoriesId)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(x => x.Id == CategoriesId);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}
