using FluentValidator;
using MediatR;
using Studentes.Evaluation.Shared.Queries;
using Studentes.Evaluation.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator.Validation;

namespace Studentes.Evaluation.Domain.OigaContext.Queries
{
    public class GetCourseStudentQuerie : Notifiable, IQuerie, IRequest<IQueryResult>
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
