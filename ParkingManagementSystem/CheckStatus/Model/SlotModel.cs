using System.ComponentModel.DataAnnotations;

namespace CheckStatus.Model
{
    public class SlotModel
    {
        [Key]
        public string Id { get; set; }
        public bool Two { get; set; }
        public bool Three { get; set; }
        public bool Six { get; set; }
        public bool Twelve { get; set; }
        public bool Day { get; set; }
    }
}
