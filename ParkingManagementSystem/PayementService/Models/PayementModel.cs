
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuthService.Models.Dto;

namespace PayemetServices.Models
{
    public class PayementModel
    {
        [Key]
        public int PaymentID { get; set; }

        public int UserID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }


        public UserDto User { get; set; }
    }
}