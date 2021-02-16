using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uppgift_1_Identity_Kurs_5.Data;
using Uppgift_1_Identity_Kurs_5.Models;
using Uppgift_1_Identity_Kurs_5.Services;

namespace Uppgift_1_Identity_Kurs_5.Controllers
{
    public class SchoolClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public SchoolClassesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,IUserService userService)
        {
            _context = context;
            _userManager = userManager;
            _userService = userService;
        }

        // GET: SchoolClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: SchoolClasses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            
            var schoolClass = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);

            var users = _context.Users.Where(m => m.Id == id).ToList();

            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // GET: SchoolClasses/Create
        public async Task<IActionResult> Create()
        {
        
            var teachers = await _userService.GetAllTeachersAsync();


            ViewData["Teacher"] = new SelectList(teachers, "Id", "DisplayName");
         

            return View();
        }

        // POST: SchoolClasses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] SchoolClass schoolClass, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = await _userManager.FindByIdAsync(model.Role);
                var las = schoolClass.Id;
          

                schoolClass.Teacher = user;
                
                _context.Add(schoolClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SchoolClasses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teachers = await _userService.GetAllTeachersAsync();

         
            var model = new List<AddTeacher>();

            foreach (var user in _userManager.Users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                if (role == "Teacher")
                {
                    var teacher = new AddTeacher()
                    {
                        UserId = user.Id,
                        Name = user.DisplayName,
                        IsSelected = false
                    };
                    model.Add(teacher);

                }

            }
   
            return View(model);
        }

           

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] SchoolClass schoolClass, List<AddTeacher> model)
        {
            if (id != schoolClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var teacher = await _userManager.FindByIdAsync(model[i].UserId);
                    if (model[i].IsSelected)
                    {
                        schoolClass.Teacher = teacher;
                        _context.Classes.Update(schoolClass);
                        _context.SaveChanges();
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolClass = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(schoolClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassExists(string id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
