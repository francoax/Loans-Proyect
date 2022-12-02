using Backend.Dto;
using Backend.Entities;

namespace Backend.Statics
{
    public static class ThingExtensions
    {
        public static ThingDto ToDto(this Thing thing)
        {
            return new ThingDto
            {
                Id = thing.Id,
                Description = thing.Description
            };
        }
        public static List<ThingDto> ToDto(this IList<Thing> things)
        {
            var thingsDto= new List<ThingDto>();
            foreach(Thing item in things)
            {
                thingsDto.Add(item.ToDto());
            }
            return thingsDto;
        }

    }
}
