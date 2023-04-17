using Studentes.Evaluation.Shared.Extensions;
using Studentes.Evaluation.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces
{
    public interface IEvaluationRepository : 
        IBaseRepository<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>
    {
        public Task<PagedResult<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>> 
            GetAllEvaluationsPaged(int pageSize, int pageIndex, string query = null);
    }
}
