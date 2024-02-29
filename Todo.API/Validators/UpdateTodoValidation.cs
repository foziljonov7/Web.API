using FluentValidation;
using Todo.API.Data;
using Todo.API.Dtos;

namespace Todo.API.Validators
{
    public class UpdateTodoValidation : AbstractValidator<UpdateTodoDto>
    {
        public UpdateTodoValidation(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title not empty")
                .MinimumLength(3).WithMessage("Title minimum length 3")
                .MaximumLength(50).WithMessage("Title maximum length 50");

            RuleFor(dto => dto.Description)
                .MaximumLength(250).WithMessage("Description maximum length 250");
        }
    }
}
