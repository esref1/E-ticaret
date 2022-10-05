using Core.Results;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> AddAsync(Customers data)
        {
            return await _unitOfWork.RepoCustomers.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncDelete(x => x.Id == Id).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        [PerformanceAspect]
        public async Task<IList<Customers>> GetAllCustomersAsync()
        {
            return await _unitOfWork.RepoCustomers.AsyncGetAll();
        }
        [PerformanceAspect]
        public async Task<IList<Customers>> GetAllOrderFirstCustomersAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncGetAll(x => x.Id == Id, x => x.Orders);
        }
        [PerformanceAspect]
        public async Task<Customers> GetFirstCustomersAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncFirst(x => x.Id == Id);
        }
        [PerformanceAspect, LogAspect]
        public async Task<Customers> LoginAsync(string Email, string Password)
        {
            return await _unitOfWork.RepoCustomers.Login(Email, Password);
        }
        [PerformanceAspect, LogAspect]
        public async Task<string> PaswordForgotAsync(string Email)
        {
            return await _unitOfWork.RepoCustomers.ForgotPasswords(Email);
        }
        [ExceptionAspect, LogAspect, PerformanceAspect]
        public async Task<IResult> UpdateAsync(Customers data)
        {
            return await _unitOfWork.RepoCustomers.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}
