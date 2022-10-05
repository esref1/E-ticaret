using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class CustomerRepo : Repositories<Customers>, ICustomersRepo
    {
        private readonly DbContext context;
        public CustomerRepo(DbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<string> ForgotPasswords(string Email)
        {
            var data = context.Set<Customers>().Where(x => x.Email == Email).FirstOrDefault();
            if (data != null)
            {
                data.Password = new Random().Next(111111, 999999).ToString();
                return await Task.Run(() => context.Update(data)).ContinueWith(x => data.Password);
            }
            else
            {
                return await Task.Run(() => "Kullanıcı Bulunamadı");
            }
        }

        public async Task<Customers> Login(string Email, string Passwords)
        {
            var data = context.Set<Customers>().Where(x => x.Email == Email && x.Password == Passwords).FirstOrDefault();

            return await Task.Run(() => data);
        }
    }
}
