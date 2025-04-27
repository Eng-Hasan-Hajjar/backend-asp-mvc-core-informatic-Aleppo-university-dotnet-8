using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class RepracOrder
    {
        [Key]
        public int REPRAC_ORDER_ID { get; set; }

        public int STU_ID { get; set; }
        public int SUB_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RE_ORDER_DATE { get; set; }

        public string RE_ORDER_RESON { get; set; }
        public string ORDER_STATE { get; set; }

        public int ADM_ID { get; set; }
    }

}
