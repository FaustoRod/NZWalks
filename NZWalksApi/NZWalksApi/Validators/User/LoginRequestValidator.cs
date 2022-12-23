using FluentValidation;
using NZWalksApi.Models.Dtos;

namespace NZWalksApi.Validators.User
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(m=>m.UserName).NotEmpty();
            RuleFor(m=>m.Password).NotEmpty();
        }
    }
}
