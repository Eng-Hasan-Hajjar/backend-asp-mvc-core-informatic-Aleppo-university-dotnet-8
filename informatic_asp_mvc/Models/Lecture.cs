using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Lecture
    {
        [Key]
        public int LEC_ID { get; set; }

        public string LEC_FILE { get; set; }
        public string LEC_TITLE { get; set; }
        public string LEC_TYPE { get; set; }

        public int SUB_ID { get; set; }

        public string LEC_NOTE { get; set; }
        public int? LEC_DATE { get; set; }
    }

}
