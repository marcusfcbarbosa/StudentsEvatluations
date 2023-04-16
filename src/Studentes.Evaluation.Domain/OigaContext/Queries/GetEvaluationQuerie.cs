using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Queries;
using System;

namespace Studentes.Evaluation.Domain.OigaContext.Queries
{
    public class GetEvaluationQuerie : Notifiable, IQuerie, IRequest<IQueryResult>
    {
        public Guid id { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(id == Guid.Empty, "id", "id  is required"));
        }
    }
}
