using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Ad
    {
        [Key]
        public int AD_ID { get; set; }

        public string AD_TITLE { get; set; }
        public string AD_DESCRIB { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AD_DATE { get; set; }

        public int DOC_ID { get; set; }
        public int? TARGET_YEAR { get; set; }
    }

}
