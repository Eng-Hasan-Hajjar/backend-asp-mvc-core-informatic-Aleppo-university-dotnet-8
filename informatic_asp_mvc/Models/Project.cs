using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class Project
    {
        [Key]
        public int PRO_ID { get; set; }

        public string PRO_TITLE { get; set; }
        public string PRO_DESCRIB { get; set; }
        public string PRO_TOOL { get; set; }
        public string PRO_TYPE { get; set; }

        public int DOC_ID { get; set; }
        public string PRO_DOCUMENT { get; set; }

        public string PRO_STATE { get; set; }

        public int? EXEC_YEAR { get; set; }
        public double? PRO_DEG { get; set; }

        public int ADM_ID { get; set; }
    }

}
