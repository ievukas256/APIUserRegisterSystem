using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using APIUserRegisterSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIUserRegisterSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public List<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }
        [HttpGet("Get by id")]
        public Address Get(int id)
        {
            return _addressRepository.Get(id);
        }
        [HttpPost]
        public Address Add([FromBody] AddressDTO address)
        {
            return _addressRepository.Add(address);
        }
        [HttpPut]
        public Address Update([FromQuery] int id, [FromBody] AddressDTO address)
        {
            return _addressRepository.Update(id, address);
        }
        [HttpDelete]
        public Address Delete([FromQuery] int id)
        {
            return _addressRepository.Delete(id);
        }
    }
}
