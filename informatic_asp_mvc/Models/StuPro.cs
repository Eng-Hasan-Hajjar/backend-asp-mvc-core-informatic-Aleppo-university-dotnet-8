using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class StuPro
    {
        [Key]
        public int STU_PRO_ID { get; set; }

        public int STU_ID { get; set; }
        public int PRO_ID { get; set; }

        public string STU_PRO_STATE { get; set; }
    }
}
