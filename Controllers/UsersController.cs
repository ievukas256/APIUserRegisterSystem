using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using Microsoft.AspNetCore.Mvc;

namespace APIUserRegisterSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        [HttpGet("Get by id")]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
        [HttpPost]
        public User Add([FromBody] UserDTO user)
        {
            return _userRepository.Add(user);
        }
        [HttpPut("Update all")]
        public User Update([FromQuery] int id, [FromBody] UserDTO user)
        {
            return _userRepository.Update(id, user);
        }
        [HttpPut("Update name")]
        public User UpdateName([FromQuery] int id, [FromBody] UserNameDTO user)
        {
            return _userRepository.UpdateName(id, user);
        }
        [HttpPut("Update Surname")]
        public User UpdateSurName([FromQuery] int id, [FromBody] UserSurnameDTO user)
        {
            return _userRepository.UpdateSurName(id, user);
        }
        [HttpPut("Update IdNumber")]
        public User UpdateIdNumber([FromQuery] int id, [FromBody] UserIdNumberDTO user)
        {
            return _userRepository.UpdateIdNumber(id, user);
        }
        [HttpPut("Update Phone")]
        public User UpdatePhone([FromQuery] int id, [FromBody] UserPhoneDTO user)
        {
            return _userRepository.UpdatePhone(id, user);
        }
        [HttpPut("Update Mail")]
        public User UpdateMail([FromQuery] int id, [FromBody] UserMailDTO user)
        {
            return _userRepository.UpdateMail(id, user);
        }
        [HttpDelete]
        public User Delete([FromQuery] int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
