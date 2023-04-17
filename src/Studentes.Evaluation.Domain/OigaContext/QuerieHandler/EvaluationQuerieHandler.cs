using MediatR;
using Studentes.Evaluation.Domain.OigaContext.Queries;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Domain.OigaContext.QuerieHandler
{
    public class EvaluationQuerieHandler :
        IRequestHandler<GetEvaluationQuerie, IQueryResult>,
        IRequestHandler<GetAllEvaluationQuerie, IQueryResult>
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public EvaluationQuerieHandler(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<IQueryResult> Handle(GetEvaluationQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _evaluationRepository.GetById(request.id)));
        }

        public async Task<IQueryResult> Handle(GetAllEvaluationQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _evaluationRepository.GetAll()));
        }
    }
}
