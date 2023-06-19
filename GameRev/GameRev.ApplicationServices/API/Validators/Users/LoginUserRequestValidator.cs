using FluentValidation;
using GameRev.ApplicationServices.API.Domain.Requests.Users;

namespace GameRev.ApplicationServices.API.Validators.Users
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.Login).Length(1, 50);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
