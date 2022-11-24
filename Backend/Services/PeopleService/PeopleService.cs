using Backend.Dto;
using Backend.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.PeopleService
{
    public class PeopleService : IPeopleService
    {
        public bool HasCorrectAttributes(PersonToCreateDto person)
        {
            if (person.Name.IsNullOrEmpty() || person.Email.IsNullOrEmpty() || person.PhoneNumber.IsNullOrEmpty())
            { 
                return false; 
            }
            else 
            {
                return true; 
            }
        }
    }
}
