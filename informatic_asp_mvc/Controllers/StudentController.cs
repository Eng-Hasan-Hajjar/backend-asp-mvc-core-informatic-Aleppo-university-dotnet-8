using informatic_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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


        // إضافة إجراء Details لعرض تفاصيل الطالب
        [HttpGet]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Fetching details for student with ID: {StudentId}", id);
            var student = _context.Students.FirstOrDefault(s => s.STU_ID == id);
            if (student == null)
            {
                _logger.LogWarning("لم يتم العثور على طالب بالمعرف: {StudentId}", id);
                return NotFound();
            }

            return PartialView("_DetailsModal", student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Fetching student for edit with ID: {StudentId}", id);
            var student = _context.Students.FirstOrDefault(s => s.STU_ID == id);
            if (student == null)
            {
                _logger.LogWarning("لم يتم العثور على طالب بالمعرف: {StudentId}", id);
                return NotFound();
            }
            return PartialView("_EditModal", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            _logger.LogInformation("Received Edit request for student with ID: {StudentId}", id);
            _logger.LogInformation("Student data: {Student}", System.Text.Json.JsonSerializer.Serialize(student));
            if (id != student.STU_ID)
            {
                return Json(new { success = false, error = "معرف الطالب غير صحيح" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                _logger.LogWarning("فشل التحقق من البيانات: {Errors}", string.Join(", ", errors));
                return PartialView("_EditModal", student);
            }

            try
            {
                // التحقق من تكرار الرقم الوطني (باستثناء الطالب الحالي)
                if (await _context.Students.AnyAsync(s => s.NATIONAL_NUMBER == student.NATIONAL_NUMBER && s.STU_ID != id))
                {
                    ModelState.AddModelError("NATIONAL_NUMBER", "الرقم الوطني مسجل مسبقًا");
                    return PartialView("_EditModal", student);
                }

                _logger.LogInformation("Updating student with ID: {StudentId}", id);
                _context.Update(student);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Student")
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.STU_ID))
                {
                    return Json(new { success = false, error = "الطالب غير موجود" });
                }
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ أثناء تعديل الطالب: {Message}", ex.Message);
                return Json(new
                {
                    success = false,
                    error = "حدث خطأ أثناء الحفظ: " + ex.Message
                });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Attempting to delete student with ID: {StudentId}", id);
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    _logger.LogWarning("Student with ID: {StudentId} not found", id);
                    return Json(new { success = false, error = "الطالب غير موجود" });
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Student with ID: {StudentId} deleted successfully", id);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting student with ID: {StudentId}", id);
                return Json(new { success = false, error = "حدث خطأ أثناء الحذف: " + ex.Message });
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.STU_ID == id);
        }
    }
    /*
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewToStringAsync(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var viewResult = controller.ViewEngine.FindView(controller.ControllerContext, viewName, false);
                var viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync(viewContext);
                return writer.ToString();
            }
        }
    }

    */

}

