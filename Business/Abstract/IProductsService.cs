using Core.Results;
using Entities;
using Entities.DTO;

namespace Business.Abstract
{
    public interface IProductsService
    {
        public Task<IResult> AddAsync(DtoProductsCrud data);
        public Task<IResult> UpdateAsync(Products data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IList<DtoProducts>> GetAllProducts();
        public Task<Products> GetRelationProduct(int Id); // 1.Products'a ait 1.Categories
    }
}
