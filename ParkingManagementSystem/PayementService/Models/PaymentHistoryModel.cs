using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PayemetServices.Models
{
    public class PaymentHistoryModel
    {
        [Key]
        public int PaymentHistoryID { get; set; }

        public int UserID { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}