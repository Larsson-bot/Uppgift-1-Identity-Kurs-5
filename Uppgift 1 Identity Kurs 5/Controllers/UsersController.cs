using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift_1_Identity_Kurs_5.Services;

namespace Uppgift_1_Identity_Kurs_5.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _userService.GetAllRoles();

            return View();
        }
    }
}
