using FluentValidation;
using GameRev.ApplicationServices.API.Domain.Requests;

namespace GameRev.ApplicationServices.API.Validators.Reviews
{
    public class UpdateReviewRequestValidator : AbstractValidator<UpdateReviewRequest>
    {
        public UpdateReviewRequestValidator()
        {
            RuleFor(x => x.Rate).InclusiveBetween(1, 10).WithMessage("Incorrect value.");
            RuleFor(x => x.Content).Length(1, 2000).WithMessage("Incorrect value length. Please insert value between 1 and 2000 characters");
        }
    }
}
