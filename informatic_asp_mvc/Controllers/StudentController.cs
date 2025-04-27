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
            return PartialView("_CreateModal", new Student()); // إرجاع مودل جديد

         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateModal", student);
            }

            try
            {
                // التحقق من التكرار
                if (await _context.Students.AnyAsync(s => s.NATIONAL_NUMBER == student.NATIONAL_NUMBER))
                {
                    ModelState.AddModelError("NATIONAL_NUMBER", "الرقم الوطني مسجل مسبقاً");
                    return PartialView("_CreateModal", student);
                }

                // حفظ البيانات
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                // إرجاع استجابة JSON مع رابط التوجيه
                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Student")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ أثناء الحفظ");
                return Json(new
                {
                    success = false,
                    error = "حدث خطأ غير متوقع. يرجى المحاولة مرة أخرى."
                });
            }
        }



        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.STU_ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.STU_ID == id);
        }
    }
}
