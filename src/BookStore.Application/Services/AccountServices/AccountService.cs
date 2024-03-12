using BookStore.Application.Dtos;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async ValueTask<bool> Login(LoginDto loginDto)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Email == loginDto.Email);
                if (user == null)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<bool> Registor(RegistorDto registorDto)
        {
            var registor = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == registorDto.Email);
            if (registor != null)
            {
                return false;
            }

            var user = new User()
            {
                UserName = registorDto.Name,
                Email = registorDto.Email,


            };
            var result = await _userManager.CreateAsync(user, registorDto.Password);
            if (result.Succeeded)
            {
            }
            return true;
        }
    }
}
