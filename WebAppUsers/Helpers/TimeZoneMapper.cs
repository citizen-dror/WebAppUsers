using WebAppUsers.ModelsDto;

namespace WebAppUsers.Helpers
{
    public class TimeZoneMapper
    {
        public static TimeZoneShortDto ToShortDto(DataLibrary.Models.TimeZone src)
        {
            if (src != null)
            {
                return new TimeZoneShortDto
                {
                    Name = src.Name,
                    UtcOffset = src.UtcOffset,
                };
            }
            return null;
        }
    }
}
