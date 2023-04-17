using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Studentes.Evaluation.Domain.OigaContext.Commands.Input
{
    public class DeleteEvaluationCommand : Notifiable
                                            , ICommand
                                            , IRequest<ICommandResult>
    {
        public Guid id { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsFalse(id == Guid.Empty, "id", "id  is required"));
        }
    }
}
