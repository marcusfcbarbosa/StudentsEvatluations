using MediatR;
using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Domain.OigaContext
{
    public class EvaluationHandler :
        IRequestHandler<CreateEvaluationCommand, ICommandResult>,
        IRequestHandler<DeleteEvaluationCommand, ICommandResult>

        
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ICourseStudentRepository _courseStudentRepository;
        public EvaluationHandler(IEvaluationRepository evaluationRepository,
               ICourseStudentRepository courseStudentRepository)
        {
            _evaluationRepository = evaluationRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<ICommandResult> Handle(CreateEvaluationCommand request,
            CancellationToken cancellationToken)
        {
            var course_student = _courseStudentRepository.GetById(request.course_student_id);
            var evaluation = new Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation(course_student, request.stars, request.description);
            await _evaluationRepository.CreateAsync(evaluation);
            await _evaluationRepository.SaveChangesAsync();
            return new CommandResult(true, "Evaluation successfully registered!", evaluation.Id);
        }

        public async Task<ICommandResult> Handle(DeleteEvaluationCommand request, CancellationToken cancellationToken)
        {
            var evaluation = _evaluationRepository.GetById(request.id);
            _evaluationRepository.Delete(evaluation);
            await _evaluationRepository.SaveChangesAsync();
            return new CommandResult(true, "Evaluation successfully deleted!", evaluation.Id);
        }
    }
}
