using APIUserRegisterSystem.Entities;

namespace APIUserRegisterSystem.Interfeices
{
    public interface ILoginRepository
    {
        List<Login> GetAll();
        Login Get(int id);
        Login Add(LoginDTO login);
        Login Update(int id, LoginDTO login);
        Login Delete(int id);
    }
}
