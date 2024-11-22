using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Helpers;

namespace UserService.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(UserHelper userHelper, IMapper mapper) : ControllerBase
    {
        private readonly UserHelper _userHelper = userHelper;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await _userHelper.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost("find-users")]
        public async Task<ActionResult<UserReadDto>> GetUsersByIds([FromBody] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var users = await _userHelper.GetUserByIds(ids);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpPost("eligible-students")]
        public async Task<ActionResult<UserReadDto>> GetEligibleUsers(IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var users = await _userHelper.GetEligibleUsers(ids);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpPost("insert")]
        public async Task<ActionResult<UserReadDto>> Login([FromBody] LoginCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validatedUser = await _userHelper.Login(user);

            if (validatedUser == null)
            {
                ModelState.AddModelError("", "NIM or Password incorrect!");
                return Unauthorized(ModelState);
            }

            return Ok(_mapper.Map<UserReadDto>(validatedUser));
        }
    }
}
