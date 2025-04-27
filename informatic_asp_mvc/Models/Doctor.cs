using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Doctor
    {
        [Key]
        public int DOC_ID { get; set; }

        public string DOC_NAME { get; set; }
        public string DOC_MAIL { get; set; }
        public string DOC_DEPT { get; set; }

        public int? NUM_PROJECT { get; set; }

        public string ADMIN_POSI { get; set; }
        public string DOC_PASS { get; set; }
    }

}
