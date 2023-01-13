using APIUserRegisterSystem.Entities;

namespace APIUserRegisterSystem.Interfeices
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
        Address Get(int id);
        Address Add(AddressDTO address);
        Address Update(int id, AddressDTO address);
        Address Delete(int id);
    }
}
