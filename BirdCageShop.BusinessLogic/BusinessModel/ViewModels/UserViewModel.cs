

namespace Ecommerce.BusinessLogic.ViewModels 
{

    public class UserViewModel {
        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? BannedTime { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }
      


    }

}
