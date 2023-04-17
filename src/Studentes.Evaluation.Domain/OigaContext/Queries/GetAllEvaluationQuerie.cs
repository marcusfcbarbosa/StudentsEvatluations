using FluentValidator;
using MediatR;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Queries;
using System;

namespace Studentes.Evaluation.Domain.OigaContext.Queries
{
    public class GetAllEvaluationQuerie : Notifiable, IQuerie, IRequest<IQueryResult>
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
