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
        IRequestHandler<GetAllEvaluationQuerie, IQueryResult>,
        IRequestHandler<GetCourseStudentQuerie, IQueryResult>,
        IRequestHandler<GetAllCourseStudentQuerie, IQueryResult>


    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ICourseStudentRepository _courseStudentRepository;

        public EvaluationQuerieHandler(IEvaluationRepository evaluationRepository,
                                       ICourseStudentRepository courseStudentRepository)
        {
            _evaluationRepository = evaluationRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<IQueryResult> Handle(GetEvaluationQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _evaluationRepository.GetById(request.id)));
        }

        public async Task<IQueryResult> Handle(GetAllEvaluationQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _evaluationRepository.GetAll()));
        }

        public async Task<IQueryResult> Handle(GetCourseStudentQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _courseStudentRepository.GetById(request.id)));
        }

        public async Task<IQueryResult> Handle(GetAllCourseStudentQuerie request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", _courseStudentRepository.GetAll()));
        }
    }
}
