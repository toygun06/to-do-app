namespace Application.Features.Auth.Command.Register
{
    public class UserRegisterResponse
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
