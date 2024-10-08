﻿using Application.Features.Tasks.Commands.Add;
using Application.Features.Tasks.Commands.Update;
using FluentValidation;

namespace Application.Features.Tasks.Validations
{
    public class AddTaskValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskValidator()
        {
            RuleFor(task => task.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(task => task.Description)
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}
