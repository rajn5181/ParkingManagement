using System.ComponentModel.DataAnnotations;

namespace CheckStatus.Model
{
    public class SlotModel
    {
        [Key]
        public string Id { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public int Six { get; set; }
        public int Twelve { get; set; }
        public int Day { get; set; }
        public int Limit_Block1 { get; set; }
        public int Limit_Block2 { get; set; }
        public int Limit_Block3 { get; set; }
        public int Limit_Block4 { get; set; }
        public int Limit_Block5 { get; set; }
        public decimal PricePerHour { get; set; }



    }
}
