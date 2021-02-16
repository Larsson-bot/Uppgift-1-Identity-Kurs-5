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

      

        public async Task<IActionResult> Index()
        {
            ViewBag.Roles = _userService.GetAllRoles();
            ViewBag.Users = await _userService.GetAllUsers();
            return View();
        }

        //public async Task<IActionResult> Create()
        //{

        //}
    }
}
