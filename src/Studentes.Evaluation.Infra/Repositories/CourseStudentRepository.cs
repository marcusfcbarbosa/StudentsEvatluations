using Studentes.Evaluation.Domain.OigaContext.Entities;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Infra.SqlContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Studentes.Evaluation.Infra.Repositories
{
    public class CourseStudentRepository :BaseRepository<CourseStudent>,
        ICourseStudentRepository
    {
        private readonly Oiga_DBContext _context;
        public CourseStudentRepository(Oiga_DBContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
