using informatic_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;


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
        //    var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.PasswordHash == model.Password);
            // تسجيل الدخول باستخدام الرقم الجامعي
            var user = _context.Users
                .FirstOrDefault(u => u.UniversityId == model.UniversityId && u.PasswordHash == model.Password);

            if (user != null)
            {


                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    // كلمة المرور صحيحة
                    return RedirectToAction("Index", "Home");
                }

                // يمكن استخدام Session أو Cookie هنا لتخزين معلومات المستخدم
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "البيانات غير صحيحة";
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginRegisterViewModel model)
        {

            // أنشئ هاشّر
            var passwordHasher = new PasswordHasher<User>();

            if (!ModelState.IsValid)
            {
                ViewBag.Error = "جميع الحقول مطلوبة";
                return View(model);
            }

            if (_context.Users.Any(u => u.FullName == model.FullName))
            {
                ViewBag.Error = "الاسم الكامل موجود بالفعل  ";
                return View(model);
            }


            if (_context.Users.Any(u => u.Username == model.Username))
            {
                ViewBag.Error = "اسم المستخدم موجود بالفعل";
                return View(model);
            }

            // التحقق من تطابق كلمة المرور وتأكيدها
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "كلمة المرور وتأكيدها غير متطابقتين";
                return View(model);
            }

            // التحقق من وجود بريد إلكتروني مستخدم سابقًا
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ViewBag.Error = "البريد الإلكتروني مستخدم مسبقًا";
                return View(model);
            }

            // إنشاء مستخدم جديد
            var newUser = new User
            {
                FullName = model.FullName,
                Username = model.Username,
                Email = model.Email,
              //  PasswordHash = model.Password, // يفضل لاحقًا تشفير كلمة المرور!

                Role = model.Role,
                UniversityId = model.UniversityId
            };


            // شفّر كلمة المرور
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, model.Password);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            // توجيه المستخدم لصفحة تسجيل الدخول أو صفحة ترحيبية
            return RedirectToAction("Login", "Account");

     

         

        }
    }
}
