using Application.Features.Tasks.Queries.GetByUserId;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tasks.Validations
{
    public class GetTasksByUserIdValidator : AbstractValidator<GetTasksByUserIdQuery>
    {
        public GetTasksByUserIdValidator() 
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id sıfırdan büyük ve boş olmamalıdır.");
        }
    }
}
