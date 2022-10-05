using AutoMapper;
using Core.Results;
using Entities.DTO;

namespace Business.Concrete
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(DtoProductsCrud data)
        {
            return await _unitOfWork.RepoProducts.AsyncAdd(mapper.Map<Products>(data)).ContinueWith(x=> _unitOfWork.SaveChanges()).Result;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoProducts.AsyncDelete(x=> x.Id == Id).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [PerformanceAspect,LogAspect]
        public async Task<IList<DtoProducts>> GetAllProducts()
        {
            return await Task.Run(()=> mapper.Map<IList<DtoProducts>>(_unitOfWork.RepoProducts.AsyncGetAll().Result));
        }
        [PerformanceAspect]
        public async Task<Products> GetRelationProduct(int Id)
        {
            return await _unitOfWork.RepoProducts.AsyncFirst(x=> x.Id == Id,x=> x.Categories);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Products data)
        {
            return await _unitOfWork.RepoProducts.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}
