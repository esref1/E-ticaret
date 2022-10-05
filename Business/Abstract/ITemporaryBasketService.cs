using Core.Results;
using Entities;

namespace Business.Abstract
{
    public interface ITemporaryBasketService
    {

        public Task<IResult> AddAsync(TemporaryBaskets data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IResult> PieceUpdateAsync(int Id, bool Process);
        public Task<IList<TemporaryBaskets>> GetBasketsAsync(int BasketId);
    }
}
