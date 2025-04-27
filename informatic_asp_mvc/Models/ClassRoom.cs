using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class ClassRoom
    {
        [Key]
        public int CLS_ID { get; set; }

        public string ATTENDANCE_FILE { get; set; }
    }
}
