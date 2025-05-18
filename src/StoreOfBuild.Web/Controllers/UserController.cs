using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IManager _manager;

        public UserController(ILogger<UserController> logger, IManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.ListAll();
            var userDto = users.Select(x => new UserDto { Email = x.Email, Id = x.Id });
            return View(userDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            await _manager.CreateAsync(userDto.Email, userDto.Password, userDto.Role);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}