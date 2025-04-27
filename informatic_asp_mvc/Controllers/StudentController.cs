using informatic_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace informatic_asp_mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object _logger;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
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
            try
            {
                if (ModelState.IsValid)
                {
                    if (_context.Students.Any(s => s.NATIONAL_NUMBER == student.NATIONAL_NUMBER))
                    {
                        ModelState.AddModelError("NATIONAL_NUMBER", "الرقم الوطني مسجل مسبقاً");
                        return PartialView("_CreateModal", student);
                    }

                    await _context.Students.AddAsync(student);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                return PartialView("_CreateModal", student);
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ
             
                return StatusCode(500, new { error = "حدث خطأ داخلي" });
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
