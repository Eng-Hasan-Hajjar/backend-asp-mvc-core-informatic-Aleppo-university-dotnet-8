using informatic_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace informatic_asp_mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreateModal", new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                // تسجيل أخطاء التحقق
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                _logger.LogWarning("فشل التحقق من البيانات: {Errors}", string.Join(", ", errors));
                return PartialView("_CreateModal", student);
            }

            try
            {
                // التحقق من التكرار
                if (await _context.Students.AnyAsync(s => s.NATIONAL_NUMBER == student.NATIONAL_NUMBER))
                {
                    ModelState.AddModelError("NATIONAL_NUMBER", "الرقم الوطني مسجل مسبقًا");
                    return PartialView("_CreateModal", student);
                }

                // تسجيل البيانات التي سيتم حفظها
                _logger.LogInformation("محاولة حفظ طالب جديد: {Student}", System.Text.Json.JsonSerializer.Serialize(student));

                // حفظ البيانات
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Student")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ أثناء حفظ الطالب: {Message}", ex.Message);
                return Json(new
                {
                    success = false,
                    error = "حدث خطأ أثناء الحفظ: " + ex.Message
                });
            }
        }

        // باقي الإجراءات كما هي
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.STU_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.STU_ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.STU_ID == id);
        }
    }
}
