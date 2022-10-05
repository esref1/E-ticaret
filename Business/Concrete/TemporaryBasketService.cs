using Core.Results;
using Core.Results.ComplexTypes;

namespace Business.Concrete
{
    public class TemporaryBasketService : ITemporaryBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        public TemporaryBasketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(TemporaryBaskets data)
        {
            var SepetteDurum = unitOfWork.RepoTemporaryBaskets.AsyncFirst(x=> x.ProductsId == data.ProductsId && x.BasketId == data.BasketId).Result;


            if (SepetteDurum != null)
            {
                SepetteDurum.Piece += 1;
                return await unitOfWork.RepoTemporaryBaskets.AsyncUpdate(SepetteDurum).ContinueWith(x => unitOfWork.SaveChanges()).Result;
            }
            else
            {
                return await unitOfWork.RepoTemporaryBaskets.AsyncAdd(data).ContinueWith(x => unitOfWork.SaveChanges()).Result;
            }
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await unitOfWork.RepoTemporaryBaskets.AsyncDelete(x => x.Id == Id).ContinueWith(x => unitOfWork.SaveChanges()).Result;
        }
        [LogAspect, PerformanceAspect]
        public async Task<IList<TemporaryBaskets>> GetBasketsAsync(int BasketId)
        {
            return await unitOfWork.RepoTemporaryBaskets.AsyncGetAll(x => x.BasketId == BasketId);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> PieceUpdateAsync(int Id, bool Process)
        {
            var SepettekiUrun = unitOfWork.RepoTemporaryBaskets.AsyncFirst(x=> x.Id == Id).Result;
            var StoktakiUrun = unitOfWork.RepoProducts.AsyncFirst(x=> x.Id == SepettekiUrun.ProductsId).Result;
            if (Process) // TRUE ise Arttırma / FALSE ise Azaltma Olacak 
            {
                // Stok'taki adet'ten yüksek Ürün Sipariş Edilememesi lazım.
                if (StoktakiUrun.Stock > SepettekiUrun.Piece)
                {
                    SepettekiUrun.Piece++;
                    return await unitOfWork.RepoTemporaryBaskets.AsyncUpdate(SepettekiUrun).ContinueWith(x => unitOfWork.SaveChanges()).Result;
                }
                else
                {
                    return Result.FactoryResult(StatusCode.Success, "Maximum " + StoktakiUrun.Stock + " Adet Sipariş Verilebilir.");
                }
            }
            else
            {
                if (SepettekiUrun.Piece > 1)
                {
                    SepettekiUrun.Piece--;
                    return await unitOfWork.RepoTemporaryBaskets.AsyncUpdate(SepettekiUrun).ContinueWith(x => unitOfWork.SaveChanges()).Result;
                }
                else
                {
                    return Result.FactoryResult(StatusCode.Success, "Minimum 1 Adet Sipariş Verilebilir.");
                }
            }
        }
    }
}
