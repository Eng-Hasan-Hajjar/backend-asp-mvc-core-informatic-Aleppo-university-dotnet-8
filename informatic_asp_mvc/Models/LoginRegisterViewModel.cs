using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class LoginRegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        // هذا الحقل الذي كان مفقوداً
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيدها غير متطابقتان")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
