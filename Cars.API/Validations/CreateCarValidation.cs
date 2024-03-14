using FluentValidation;
using Cars.API.Dtos;
using Cars.API.Data;

namespace Cars.API.Validations
{
    public class CreateCarValidation : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidation(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Model)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(50);
            RuleFor(dto => dto.Price)
                .NotEmpty();
            RuleFor(dto => dto.Probeg)
                .NotEmpty();
            RuleFor(dto => dto.Color)
                .NotEmpty()
                .MaximumLength(25);
            RuleFor(dto => dto.Engine)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(70);
            RuleFor(dto => dto.CategoryId)
                .NotEmpty();
        }
    }
}
