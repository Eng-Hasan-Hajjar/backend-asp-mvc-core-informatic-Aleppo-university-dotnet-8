using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System;
namespace informatic_asp_mvc.Models
{
    public class Student
    {
        [Key]
        public int STU_ID { get; set; }

        public string STU_NAME { get; set; }
        public string STU_FTHR { get; set; }
        public string STU_MTHR { get; set; }
        public string STU_NICK { get; set; }

        [DataType(DataType.Date)]
        public DateTime? STU_BRTH { get; set; }

        [DataType(DataType.Date)]
        public DateTime? JOIN_DATE { get; set; }

        public string STU_GENDER { get; set; }
        public string COMPAR_TYPE { get; set; }
        public string NATIONALITY { get; set; }

        public double? BAC_AVG { get; set; }

        public string STU_PASS { get; set; }

        public string STU_STATE { get; set; }
        public int? STU_YEAR { get; set; }

        public int? CLS_ID { get; set; }


        [Required(ErrorMessage = "الرقم الوطني مطلوب")]
    
        // الحقل الجديد للرقم الوطني
        public string NATIONAL_NUMBER { get; set; }

        // الحقل الجديد للرقم 
        public string PHONE_NUMBER { get; set; }

    }

}
