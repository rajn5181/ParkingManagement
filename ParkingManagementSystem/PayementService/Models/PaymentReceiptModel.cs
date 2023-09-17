using PayemetServices.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PayemetServices.Models
{
    public class PaymentReceiptModel
    {
        [Key]
        public int PaymentReceiptID { get; set; }

        public int PaymentID { get; set; }

        public string ReceiptNumber { get; set; }

        [ForeignKey("PaymentID")]
        public PayementModel Payment { get; set; }
    }
}