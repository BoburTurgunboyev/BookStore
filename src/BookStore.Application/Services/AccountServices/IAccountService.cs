using BookStore.Application.Dtos;

namespace BookStore.Application.Services.AccountServices
{
    public interface IAccountService
    {
        public ValueTask<bool> Login(LoginDto loginDto);
        public ValueTask<bool> Registor(RegistorDto registorDto);
    }
}
