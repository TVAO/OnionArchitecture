// IUserService.cs is a part of the GDPR Bachelor project. Created: 14, 03, 2017.
// Creators: Dennis Thinh Tan Nguyen & Thor Valentin Aakjær Olesen Nielsen.

using System.Threading.Tasks;
using OnionArchitecture.Data.DTO;

namespace OnionArchitecture.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> SaveNewUser(NewUserDTO userDto);

        Task<UserDTO> GetUserWithId1();
    }
}