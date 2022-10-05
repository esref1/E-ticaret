using Core.Results;
using Entities;

namespace Business.Abstract
{
    public interface IOrdersRelationService
    {
        public Task<IResult> AllAddAsync(Orders data);
        public Task<IResult> UpdateAsync(Orders data); // Şuanlık Sadece Kargo Takip
        public Task<IList<Orders>> GetAllOrders();
        public Task<Orders> GetOrdersRelationById(int id);
    }
}
