using APIUserRegisterSystem.DB;
using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using Azure.Core;

namespace APIUserRegisterSystem.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository()
        {
        }

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public Login Add(LoginDTO login)
        {
            var newLogin = new Login
            {
                UserName = login.UserName,
                Password = login.Password

            };
            _context.Add(newLogin);
            _context.SaveChanges();
            return newLogin;
        }

        public Login Delete(int id)
        {
            var login = _context.Logins.SingleOrDefault(x => x.Id == id);
            _context.Remove(login);
            _context.SaveChanges();
            return login;
        }

        public Login Get(int id)
        {
            return _context.Logins.SingleOrDefault(x => x.Id == id);
        }

        public List<Login> GetAll()
        {
            return _context.Logins.ToList();
        }

        public Login Update(int id, LoginDTO login)
        {
            var upLogin = _context.Logins.SingleOrDefault(x => x.Id == id);
            upLogin.UserName = login.UserName;
            upLogin.Password = login.Password;
            _context.SaveChanges();
            return upLogin;
        }
    }
}
