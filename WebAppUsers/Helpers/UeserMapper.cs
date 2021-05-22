using DataLibrary.Models;
using WebAppUsers.ModelsDto;

namespace WebAppUsers.Helpers
{
    public class UeserMapper
    {
        public static User UserFromAddDto(UserAddDto src)
        {
            if (src != null)
            {
                return new User
                {
                    UserId = src.UserId,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    WebSite = src.WebSite,
                    TimeZone = src.TimeZone,
                    PhoneSkype = src.PhoneSkype,
                    About = src.About,
                    Avatar = src.Avatar,
                };
            }
            return null;
        }

        public static UserShortDto ToShortDto(User src)
        {
            if (src != null)
            {
                return new UserShortDto
                {
                    UserId = src.UserId,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    TimeZone = src.TimeZone,
                    SendTasks = src.SendTasks,
                    TaskInterval = src.TaskInterval,
                };
            }
            return null;
        }
    }
}
