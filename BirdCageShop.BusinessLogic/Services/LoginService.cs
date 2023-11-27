using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.User;
using Ecommerce.BusinessLogic.ViewModels;   
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace BirdCageShop.BusinessLogic.Services
{
    public interface ILoginService
    {
            public LoginViewModel Authenticate(LoginRequestModel loginRequest);
        }
    public class LoginService : ILoginService {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginService(IUserRepository userRepository, IMapper mapper,IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = optionsMonitor.CurrentValue;
        }

        public LoginViewModel Authenticate(LoginRequestModel loginRequest)
        {

            var user = _userRepository.Get().SingleOrDefault(x => x.Username.Equals(loginRequest.Username));

            if (user == null || !PasswordHasher.VerifyPassword(loginRequest.Password, user.Password))
            {
                // Authentication failed
                return null;
            }


            return _mapper.Map<LoginViewModel>(user);
        }
     
        public class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                return hashedPassword.Equals(HashPassword(password), StringComparison.OrdinalIgnoreCase);
            }
        }

    }
    }
