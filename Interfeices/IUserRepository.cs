using APIUserRegisterSystem.Entities;

namespace APIUserRegisterSystem.Interfeices
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        User Add(UserDTO user);
        User Update(int id, UserDTO user);
        User UpdateName(int id, UserNameDTO user);
        User UpdateSurName(int id, UserSurnameDTO user);
        User UpdateIdNumber(int id, UserIdNumberDTO user);
        User UpdatePhone(int id, UserPhoneDTO user);
        User UpdateMail(int id, UserMailDTO user);
        User Delete(int id);
    }
}
