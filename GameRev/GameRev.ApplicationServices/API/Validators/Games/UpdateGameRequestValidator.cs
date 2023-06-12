using FluentValidation;
using GameRev.ApplicationServices.API.Domain.Requests.Games;

namespace GameRev.ApplicationServices.API.Validators.Games
{
    public class UpdateGameRequestValidator : AbstractValidator<UpdateGameRequest>
    {
        public UpdateGameRequestValidator()
        {
            RuleFor(x => x.Title).Length(1, 300).WithMessage("Incorrect value length. Please insert value between 1 and 300 characters");
            RuleFor(x => x.Description).Length(1, 2000).WithMessage("Incorrect value length. Please insert value between 1 and 2000 characters");
            RuleFor(x => x.ReleaseYear.ToString()).Length(1, 4);
        }
    }
}
