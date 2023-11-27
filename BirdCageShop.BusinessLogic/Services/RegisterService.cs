using AutoMapper;
using BirdCageShop.BusinessLogic.BusinessModel.RequestModels.User;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using static BirdCageShop.BusinessLogic.Services.LoginService;

namespace BirdCageShop.BusinessLogic.Services
{
    public interface IRegisterService
    {
        public bool Register(RegisterRequestModel regisRequest);
    }
    public class RegisterService : IRegisterService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
       
        }

        public bool Register(RegisterRequestModel regisRequest)
        {
            var existingUser = _userRepository.Get().SingleOrDefault(x => x.Username.Equals(regisRequest.Username));
            if (regisRequest.Password != regisRequest.ConfirmPassword || regisRequest == null || existingUser != null) return false;
         
            var register = _mapper.Map<User>(regisRequest);
            register.Password = PasswordHasher.HashPassword(regisRequest.Password);

            register.UserId = Guid.NewGuid().ToString();
            register.RoleId = (int?)UserRoleEnum.Customer;
            register.CreateTime = DateTime.Now;
            register.Status = (int?)UserStatusEnum.Active;

            _userRepository.Create(register);
            _userRepository.Save();

            return true;
            
        }
    }
}
