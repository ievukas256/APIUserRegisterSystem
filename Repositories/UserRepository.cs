using APIUserRegisterSystem.DB;
using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using Azure.Core;

namespace APIUserRegisterSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserRepository()
        {
        }

        public User Add(UserDTO user)
        {
            var newUser = new User
            {
                Name = user.Name,
                SurName = user.SurName,
                IdNumber = user.IdNumber,
                Phone = user.Phone,
                Mail = user.Mail,
                Photo = user.Photo
            };
            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            _context.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(int id, UserDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.Name = user.Name;
            upUser.SurName = user.SurName;
            upUser.IdNumber = user.IdNumber;
            upUser.Phone = user.Phone;
            upUser.Mail = user.Mail;
            upUser.Photo = user.Photo;
            _context.SaveChanges();
            return upUser;
        }
        public User UpdateName(int id, UserNameDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.Name = user.Name;
            _context.SaveChanges();
            return upUser;
        }
        public User UpdateSurName(int id, UserSurnameDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.SurName = user.SurName;
            _context.SaveChanges();
            return upUser;
        }
        public User UpdateIdNumber(int id, UserIdNumberDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.IdNumber = user.IdNumber;
            _context.SaveChanges();
            return upUser;
        }
        public User UpdatePhone(int id, UserPhoneDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.Phone = user.Phone;
            _context.SaveChanges();
            return upUser;
        }
        public User UpdateMail(int id, UserMailDTO user)
        {
            var upUser = _context.Users.SingleOrDefault(x => x.Id == id);
            upUser.Mail = user.Mail;
            _context.SaveChanges();
            return upUser;
        }
    }
}
