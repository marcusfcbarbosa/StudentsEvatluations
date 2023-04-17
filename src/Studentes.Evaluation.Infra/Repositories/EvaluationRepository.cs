using Dapper;
using Microsoft.EntityFrameworkCore;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Infra.SqlContext;
using Studentes.Evaluation.Shared.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Infra.Repositories
{
    public class EvaluationRepository 
        : BaseRepository<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>
        ,IEvaluationRepository
    {
        private readonly Oiga_DBContext _context;
        public EvaluationRepository(Oiga_DBContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<PagedResult<Domain.OigaContext.Entities.Evaluation>> GetAllEvaluationsPaged(int pageSize, int pageIndex, string query = null)
        {
            var sql = @$"SELECT * FROM Titulos 
                      WHERE (@Nome IS NULL OR NomeLoja LIKE '%' + @Nome + '%') 
                      ORDER BY [NomeLoja] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY 
                      SELECT COUNT(Id) FROM Titulos 
                      WHERE (@Nome IS NULL OR NomeLoja LIKE '%' + @Nome + '%')";

            var multi = await _context.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = query });

            var cars = multi.Read<Domain.OigaContext.Entities.Evaluation>();
            var total = multi.Read<int>().FirstOrDefault();
            return new PagedResult<Domain.OigaContext.Entities.Evaluation>()
            {
                List = cars,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }
    }
}
