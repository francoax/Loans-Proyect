using Backend.Dto;
using Backend.Entities;

namespace Backend.Services.PeopleService
{
    public interface IPeopleService
    {
        bool HasCorrectAttributes(PersonToCreateDto person);
    }
}
