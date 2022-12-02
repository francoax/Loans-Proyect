using Backend.Data.UOW;
using Backend.Dto;
using Backend.Handlers;
using Backend.Statics;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IJwtHandler jwtHandler;

        public AuthController(
            IJwtHandler jwtHandler,
            IUnitOfWork uow)
        {
            this.jwtHandler = jwtHandler;
            this.uow = uow;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserForLoginDto user)
        {
            if (user.HasAnyPropertyNullOrEmpty())
                return BadRequest("Ingrese los datos necesarios.");

            var userToLogIn = uow.UsersRepository.Get(user);
            if (userToLogIn is null) 
                return NotFound("Usuarios y/o contraseñas incorrectos");

            var rolUser = uow.RolesRepository.FindRole(userToLogIn.RolId);
            userToLogIn.Role = rolUser;

            var bearer = jwtHandler.GenerateToken(user, userToLogIn.Role);

            return Ok(new
            {
                token = bearer,
            });
        }
    }
}
