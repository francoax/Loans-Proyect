using Backend.Dto;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Statics
{
    public static class GenericExtensions
    {
        public static bool HasAnyPropertyNullOrEmpty(this object person)
        {
            foreach(var prop in person.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    string? value = prop.GetValue(person) as string;
                    if (value.IsNullOrEmpty()) return true;
                }
            }
            return false;
        }
    }
}
