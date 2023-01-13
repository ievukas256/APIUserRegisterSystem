using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Interfeices;
using APIUserRegisterSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIUserRegisterSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginsController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public List<Login> GetAll()
        {
            return _loginRepository.GetAll();
        }
        [HttpGet("Get by id")]
        public Login Get(int id)
        {
            return _loginRepository.Get(id);
        }
        [HttpPost]
        public Login Add([FromBody] LoginDTO login)
        {
            return _loginRepository.Add(login);
        }
        [HttpPut]
        public Login Update([FromQuery] int id, [FromBody] LoginDTO login)
        {
            return _loginRepository.Update(id, login);
        }
        [HttpDelete]
        public Login Delete([FromQuery] int id)
        {
            return _loginRepository.Delete(id);
        }
    }
}
