using Backend.Dto;
using Backend.Entities;

namespace Backend.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(UserForLoginDto user, Role rol);
    }
}
