using FluentValidation;
using NZWalksApi.Models.Dtos;

namespace NZWalksApi.Validators.Region
{
    public class AddRegionRequestValidator:AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(m => m.Code).NotEmpty();
            RuleFor(m => m.Name).NotEmpty().WithMessage("NO nulos papo");
            RuleFor(m => m.Population).GreaterThanOrEqualTo(0);
            RuleFor(m => m.Area).GreaterThan(0);
            RuleFor(m => m.Lat).GreaterThanOrEqualTo(0);
            RuleFor(m => m.Long).GreaterThanOrEqualTo(0);
        }
    }
}
