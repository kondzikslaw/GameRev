﻿using FluentValidation;
using GameRev.ApplicationServices.API.Domain.Requests;

namespace GameRev.ApplicationServices.API.Validators
{
    public class AddReviewsRequestValidator : AbstractValidator<AddReviewsRequest>
    {
        public AddReviewsRequestValidator()
        {
            RuleFor(x => x.Rate).InclusiveBetween(1, 10).WithMessage("Incorrect value.");
            RuleFor(x => x.Content).Length(1, 2000).WithMessage("Incorrect value length. Please insert value between 1 and 2000 characters");
            RuleFor(x => x.AuthorId).EmailAddress().WithMessage("Please insert email address");
        }
    }
}
