using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayemetServices.Models
{
    public class PayementModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        public string UserID { get; set; }

        public int Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string RPID { get; set; }
    }
}