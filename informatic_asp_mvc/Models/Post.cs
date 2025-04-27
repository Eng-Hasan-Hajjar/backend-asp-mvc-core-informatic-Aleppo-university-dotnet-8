using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Post
    {
        [Key]
        public int PST_ID { get; set; }

        public string PST_TITLE { get; set; }
        public string PST_DESCRIB { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PST_DATE { get; set; }

        public int DOC_ID { get; set; }
        public int STU_ID { get; set; }
    }

}
