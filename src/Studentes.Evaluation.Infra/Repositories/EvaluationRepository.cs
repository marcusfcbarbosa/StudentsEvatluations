using Dapper;
using Microsoft.EntityFrameworkCore;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Infra.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Infra.Repositories
{
    public class EvaluationRepository
        : BaseRepository<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>
        , IEvaluationRepository
    {
        private readonly Oiga_DBContext _context;
        public EvaluationRepository(Oiga_DBContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
