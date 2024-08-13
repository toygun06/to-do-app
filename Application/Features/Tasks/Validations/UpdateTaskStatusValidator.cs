using Application.Features.Tasks.Commands.UpdateTaskStatus;
using FluentValidation;

namespace Application.Features.Tasks.Validations
{
    public class UpdateTaskStatusValidator : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskStatusValidator() 
        {
            RuleFor(task => task.Status)
                .IsInEnum();
        }
    }
}
