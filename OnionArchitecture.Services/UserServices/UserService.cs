using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnionArchitecture.Data.DTO;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Models;
using OnionArchitecture.Services.Interfaces;

namespace OnionArchitecture.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }



        public async Task<bool> SaveNewUser(NewUserDTO userDto)
        {
            var userDTO = new UserDTO
            {
                Name = userDto.Name, 
                Alias = "HARDCODED", 
                CreatedOn = DateTime.Now, 
                IsHero = true
            };
            var newUser = _mapper.Map<UserDTO, User>(userDTO);

            var result = await _userRepository.CreateAsync(newUser);

            if (result > 0)
            {
                return true;
            }
            else return false;

        }

        public async Task<UserDTO> GetUserWithId1()
        {
            var user = await _userRepository.FindAsync(1); 
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;

        }

      
    }
}
