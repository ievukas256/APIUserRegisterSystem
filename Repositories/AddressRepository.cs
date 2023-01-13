using APIUserRegisterSystem.DB;
using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using Azure.Core;

namespace APIUserRegisterSystem.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

       /* public AddressRepository()
        {
        }*/

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public Address Add(AddressDTO address)
        {
            var newAddress = new Address
            {
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                FlatNumber = address.FlatNumber

            };
            _context.Add(newAddress);
            _context.SaveChanges();
            return newAddress;
        }

        public Address Delete(int id)
        {
            var address = _context.Addresses.SingleOrDefault(x => x.Id == id);
            _context.Remove(address);
            _context.SaveChanges();
            return address;
        }

        public Address Get(int id)
        {
            return _context.Addresses.SingleOrDefault(x => x.Id == id);
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address Update(int id, AddressDTO address)
        {
            var addr = _context.Addresses.SingleOrDefault(x => x.Id == id);
            addr.City = address.City;
            addr.Street = address.Street;
            addr.HouseNumber = address.HouseNumber;
            addr.FlatNumber = address.FlatNumber;
            _context.SaveChanges();
            return addr;
        }
    }
}
