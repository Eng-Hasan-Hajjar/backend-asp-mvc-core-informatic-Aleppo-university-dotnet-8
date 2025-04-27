using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Admin
    {
        [Key]
        public int ADM_ID { get; set; }

        public string ADM_NAME { get; set; }
        public string ADM_PERMISSION { get; set; }
        public string ADM_PASS { get; set; }
    }

}
