using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System;
namespace informatic_asp_mvc.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // تأكد أن STU_ID تلقائي التزايد
        public int STU_ID { get; set; }

        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        public string STU_NAME { get; set; }

        [Required(ErrorMessage = "اسم الأب مطلوب")]
        public string STU_FTHR { get; set; }

        [Required(ErrorMessage = "اسم الأم مطلوب")]
        public string STU_MTHR { get; set; }

        public string STU_NICK { get; set; } // اختياري

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
        public DateTime STU_BRTH { get; set; } // اجعله غير Nullable

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "تاريخ الالتحاق مطلوب")]
        public DateTime JOIN_DATE { get; set; } // اجعله غير Nullable

        [Required(ErrorMessage = "الجنس مطلوب")]
        public string STU_GENDER { get; set; }

        [Required(ErrorMessage = "نوع المفاضلة مطلوب")]
        public string COMPAR_TYPE { get; set; }

        [Required(ErrorMessage = "الجنسية مطلوبة")]
        public string NATIONALITY { get; set; }

        [Range(50, 100, ErrorMessage = "المعدل يجب أن يكون بين 50 و100")]
        public double BAC_AVG { get; set; } // اجعله غير Nullable

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [MinLength(8, ErrorMessage = "كلمة المرور يجب أن تكون 8 أحرف على الأقل")]
        public string STU_PASS { get; set; }

        [Required(ErrorMessage = "الحالة الدراسية مطلوبة")]
        public string STU_STATE { get; set; }

        [Range(1, 4, ErrorMessage = "السنة الدراسية يجب أن تكون بين 1 و4")]
        public int STU_YEAR { get; set; } // اجعله غير Nullable

        [Required(ErrorMessage = "رقم الفصل مطلوب")]
        public int CLS_ID { get; set; } // اجعله غير Nullable

        [Required(ErrorMessage = "الرقم الوطني مطلوب")]
        public string NATIONAL_NUMBER { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone(ErrorMessage = "رقم هاتف غير صحيح")]
        public string PHONE_NUMBER { get; set; }

    }

}
