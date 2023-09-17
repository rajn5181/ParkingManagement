using System.ComponentModel.DataAnnotations.Schema;
using AuthService.Models.Dto;
namespace PayemetServices.Models
{
    public class PaymentHistoryModel
    {
        public int PaymentHistoryID { get; set; }

        public int UserID { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        [ForeignKey("ID")]
        public UserDto User { get; set; }
    }
}