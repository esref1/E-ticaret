using Core.Results;
using Entities;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public Task<IResult> AddAsync(Customers data);
        public Task<IResult> UpdateAsync(Customers data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<Customers> GetFirstCustomersAsync(int Id);
        public Task<IList<Customers>> GetAllCustomersAsync();
        public Task<IList<Customers>> GetAllOrderFirstCustomersAsync(int Id);
        public Task<Customers> LoginAsync(string Email, string Password);
        public Task<string> PaswordForgotAsync(string Email);

    }
}
