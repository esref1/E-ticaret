using DataAccess.Repository;

namespace DataAccess.Abstract
{
    public interface ICustomersRepo:IRepositories<Customers>
    {
        public Task<Customers> Login(string Email, string Passwords);
        public Task<string> ForgotPasswords(string Email);
    }
}
