using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Quiz
    {
        [Key]
        public int QU_ID { get; set; }

        public string QU_TEXT { get; set; }

        public string ANSR_1 { get; set; }
        public string ANSR_2 { get; set; }
        public string ANSR_3 { get; set; }
        public string ANSR_4 { get; set; }

        public string RIGHT_ANSR { get; set; }

        public int SUB_ID { get; set; }
        public int DOC_ID { get; set; }
    }

}
