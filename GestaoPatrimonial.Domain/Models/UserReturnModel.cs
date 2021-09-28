namespace GestaoPatrimonial.Domain.Models
{
    public class UserReturnModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserReturnModel(string id, string userName, string email, string phoneNumber)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
