using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Data.DTO;
using OnionArchitecture.Services.Interfaces;
using OnionArchitecture.Web.ViewModels;

namespace OnionArchitecture.Web.Controllers.Web
{

    public class AppController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AppController(IUserService userService,
            IMapper mapper,
            ILogger<AppController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _userService.GetUserWithId1();
                var viewModel = _mapper.Map<UserDTO, UserViewModel>(user);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get users in Index page: {ex.Message}");
                return Redirect("/error");
            }
        }

       
        public async Task<IActionResult> Create(UserViewModel userViewModel) //([Bind("Name")] UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = _mapper.Map<UserViewModel, NewUserDTO>(userViewModel);

                    var isSuccess = await _userService.SaveNewUser(newUser);
                    if (isSuccess)
                    {
                        return Created("Index", userViewModel); // HTTP 201 response 
                    }
                    else
                    {
                        return Redirect("/error");
                    }
                    //return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get users in Index page: {ex.Message}");
                return Redirect("/error");
            }
            return RedirectToAction("Index");
        }

    }
}