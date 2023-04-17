using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studentes.Evaluation.Domain.OigaContext.Queries;
using Studentes.Evaluation.Shared;
using System.Threading.Tasks;
using System;

namespace Studentes.Evaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController : BaseController
    {
        [HttpGet]
        [Route("")]
        public async Task<IQueryResult> Get([FromServices] IMediator mediator,
                [FromQuery] string id)
        {
            var query = new GetCourseStudentQuerie { id = new Guid(id) };
            query.Validate();
            if (query.Valid)
                return await mediator.Send(query);
            return new QueryResult(false, "Errors", query.Notifications);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IQueryResult> GetAll([FromServices] IMediator mediator,
            [FromQuery] GetAllCourseStudentQuerie query)
        {
            return await mediator.Send(query);
        }
    }
}
