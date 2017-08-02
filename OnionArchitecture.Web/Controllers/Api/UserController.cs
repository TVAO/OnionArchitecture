using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Repository.Interfaces;
using OnionArchitecture.Repository.Models;
using OnionArchitecture.Web.ViewModels;

namespace OnionArchitecture.Web.Controllers.Api
{
    //[Route("api/users/{userName}")]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserController(IUserRepository repository,
            ILogger<UserController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.FindAsync(1); // Hard coded id fetch 
                var model = _mapper.Map<User, UserViewModel>(result);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get user : {ex.Message}");
                return BadRequest("Error occurred");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string userName, [FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Save to database
                var newUser = _mapper.Map<UserViewModel, User>(user);
                newUser.Name = userName;
                int isSuccees = await _repository.CreateAsync(newUser);

                if (isSuccees == 1)
                {
                    var newViewModel = _mapper.Map<User, UserViewModel>(newUser);
                    return Created($"api/users/{user.Name}", newViewModel);
                }
            }

            return BadRequest("Failed to save the user");
        }

    }
}
