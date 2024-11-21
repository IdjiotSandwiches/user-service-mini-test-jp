using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Dtos;
using UserService.Helpers;
using UserService.Models;

namespace UserService.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserHelper _userHelper;
        private readonly IMapper _mapper;

        public UsersController(UserHelper userHelper, IMapper mapper)
        {
            _userHelper = userHelper;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _userHelper.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost]
        public ActionResult<UserReadDto> Login([FromBody] Login user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validatedUser = _userHelper.Login(user);

            if (validatedUser == null)
            {
                ModelState.AddModelError("", "NIM or Password incorrect!");
                return Unauthorized(ModelState);
            }

            return Ok(_mapper.Map<UserReadDto>(validatedUser));
        }
    }
}
