using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Subject
    {
        [Key]
        public int SUB_ID { get; set; }

        public string SUB_NAME { get; set; }
        public string SUB_TYPE { get; set; }

        public int DOC_ID { get; set; }

        public string ACAD_DESCRIB { get; set; }
        public string COURSE_EXAMS { get; set; }

        public int? SUB_YEAR { get; set; }
        public string SUB_SEMESTER { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EXAM_DATE { get; set; }
    }
}
