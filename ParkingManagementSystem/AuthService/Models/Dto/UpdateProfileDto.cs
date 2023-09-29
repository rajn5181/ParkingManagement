namespace AuthService.Models.Dto
{
    public class UpdateProfileDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
