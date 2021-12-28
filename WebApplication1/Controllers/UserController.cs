using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _userRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            return await _userRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser([FromBody] UserModel user)
        {
            var Newuser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { Id = user.Id }, Newuser);
        }
        /* [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> PutUser(int id, [FromBody] UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userRepository.Update(user);
            return NoContent();
        }*/
        [HttpDelete]
        public async Task<ActionResult<UserModel>> DeleteUser(int id, [FromBody] UserModel user)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _userRepository.Delete(id);
            return NoContent();
        }
    }
}
