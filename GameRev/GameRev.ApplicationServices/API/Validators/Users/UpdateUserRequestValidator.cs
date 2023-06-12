using FluentValidation;
using GameRev.ApplicationServices.API.Domain.Requests.Users;

namespace GameRev.ApplicationServices.API.Validators.Users
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Login).Length(1, 50).WithMessage("Login cannot be empty and cannot be longer than 50 characters.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Surname cannot be longer than 50 characters.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("There must be email address");
        }
    }
}
