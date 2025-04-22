using informatic_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace informatic_asp_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRegisterViewModel model)
        {
            // استخدام أسماء الأعمدة الصحيحة من الكلاس User
            var user = _context.Users.FirstOrDefault(u => u.FullName == model.Username && u.PasswordHash == model.Password);

            if (user != null)
            {
                // يمكن استخدام Session أو Cookie هنا لتخزين معلومات المستخدم
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid credentials";
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginRegisterViewModel model)
        {
            if (_context.Users.Any(u => u.FullName == model.Username))
            {
                ViewBag.Error = "Username already exists";
                return View(model);
            }

            _context.Users.Add(new User
            {
                FullName = model.Username,
                PasswordHash = model.Password
            });

            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
