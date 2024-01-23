using System.Threading.Tasks;
using TaxiBooking.Models.DTO.UserDto;

namespace TaxiBooking.Repositories
{
    public interface IUserRepository
    {
        string GetToken(string userId);
    }
}
