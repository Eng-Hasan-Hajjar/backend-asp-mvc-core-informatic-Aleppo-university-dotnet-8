using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Stu_Sub
    {
        [Key]
        public int STU_SUB_ID { get; set; }

        public int STU_ID { get; set; }
        public int SUB_ID { get; set; }

        public double? PRACTICE_DEG { get; set; }
        public double? THEORIC_DEG { get; set; }

        public string NOTE { get; set; }
    }

}
