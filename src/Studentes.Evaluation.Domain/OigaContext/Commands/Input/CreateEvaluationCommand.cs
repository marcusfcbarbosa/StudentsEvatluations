using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Commands;
using System;

namespace Studentes.Evaluation.Domain.OigaContext.Commands.Input
{
    public class CreateEvaluationCommand : Notifiable
                                            ,ICommand
                                            ,IRequest<ICommandResult>
    {
        public int stars { get; set; }
        public string description { get; set; }
        public Guid course_student_id { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
            .Requires()
                .IsLowerThan(stars, 0, "stars", "stars is required"));

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(description, "description", "description  is required")
                );

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(course_student_id == Guid.Empty, "course_student_id", "course_student_id  is required"));

        }
    }
}
