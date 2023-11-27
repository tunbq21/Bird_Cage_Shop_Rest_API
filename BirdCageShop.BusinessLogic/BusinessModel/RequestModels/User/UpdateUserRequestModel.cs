

namespace Ecommerce.BusinessLogic.RequestModels.User 
{

   public class UpdateUserRequestModel {
        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public int? RoleId { get; set; }
    }

}
