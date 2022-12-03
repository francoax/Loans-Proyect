using AutoMapper;
using Backend.Data.UOW;
using Backend.Dto;
using Backend.Entities;
using Backend.Statics;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public UserController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public ActionResult<UserDto> Register([FromBody]UserForCreationDto userToRegister)
        {
            if (uow.UsersRepository.Exists(userToRegister.UserName))
                return BadRequest("Ya existe un usuario con ese username");

            if (userToRegister.HasAnyPropertyNullOrEmpty())
                return BadRequest("Complete los campos necesarios");

            var newUser = mapper.Map<User>(userToRegister);
            var roleUser = uow.RolesRepository.GetRole("user");
            newUser.RoleId = roleUser.Id;

            uow.UsersRepository.Add(newUser);
            uow.CompleteAsync();

            return Created($"/users/{newUser.Id}", newUser);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            var user = uow.UsersRepository.GetById(id);
            if (user is null)
                return NotFound("Usuario no encontrado");

            var role = uow.RolesRepository.GetRole(user.RoleId);
            user.Role = role;

            var userMapped = mapper.Map<UserDto>(user);
            return Ok(userMapped);
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(uow.UsersRepository.GetAll());
        }
    }
}
