using Backend.Entities;

namespace Backend.Handlers
{
    public interface IJwtHandler
    {
        string GenerateToken(User user, Role rol);
    }
}
