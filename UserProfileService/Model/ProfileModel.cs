namespace UserProfileService.Model
{
    public class ProfileModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Identifications { get; set; }
        public string PhoneNo { get; set; }
        public string Rpid { get; set; }
        public string PKID { get; set; } 
        public string location { get; set; }
        public string Slot { get; set; }
        public string VehicleNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal Amount { get; set; }
        public string UserName { get; set; } 
        public DateTime Bookdate { get; set; }
        public string checkIn { get; set; }
        public string Checkout { get; set; }
    }
}
