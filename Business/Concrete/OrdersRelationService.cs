using Core.Results;

namespace Business.Concrete
{
    public class OrdersRelationService : IOrdersRelationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersRelationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AllAddAsync(Orders data)
        {
            return await _unitOfWork.RepoOrders.AsyncAdd(data).ContinueWith(x =>
              {
                  foreach (var item in data.OrderDetails)
                  {
                      item.OrdersId = data.Id;
                      _unitOfWork.RepoOrderDetails.AsyncAdd(item);
                  }

              }).ContinueWith(x =>
              {
                  foreach (var item2 in data.OrderAddress)
                  {
                      item2.OrdersId = data.Id;
                      _unitOfWork.RepoOrderAddress.AsyncAdd(item2);
                  }
              }).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [PerformanceAspect]
        public async Task<IList<Orders>> GetAllOrders()
        {
            return await Task.Run(()=> _unitOfWork.RepoOrders.AsyncGetAll(null, x => x.Customers).Result.OrderByDescending(x => x.OrderDate).ToList());
        }
        [PerformanceAspect]
        public async Task<Orders> GetOrdersRelationById(int id)
        {
            return await _unitOfWork.RepoOrders.AsyncFirst(x => x.Id == id, x => x.OrderAddress, x => x.OrderDetails, x => x.Customers);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Orders data)
        {
            return await _unitOfWork.RepoOrders.AsyncUpdate(data).ContinueWith(x=>  _unitOfWork.SaveChanges()).Result;
        }
    }
}
