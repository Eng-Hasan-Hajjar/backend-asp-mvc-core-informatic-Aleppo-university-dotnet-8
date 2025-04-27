using System.ComponentModel.DataAnnotations;

namespace informatic_asp_mvc.Models
{
    public class ObjectionOrder
    {
        [Key]
        public int OBJ_ORDER_ID { get; set; }

        public int STU_ID { get; set; }
        public int SUB_ID { get; set; }

        public string ORDER_REASON { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OBJ_ORDER_DATE { get; set; }

        public string DEG_TYPE { get; set; }
        public string OBJECTION_RESAULT { get; set; }

        public int ADM_ID { get; set; }
    }

}
