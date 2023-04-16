using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using Studentes.Evaluation.Domain.OigaContext.Queries;
using Studentes.Evaluation.Shared;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Studentes.Evaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : BaseController
    {

        [HttpPost]
        [Route("")]
        public async Task<ICommandResult> Post([FromServices] IMediator mediator,
                                                 [FromBody] CreateEvaluationCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await mediator.Send(command);
            return new CommandResult(false, "Errors", command.Notifications);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IQueryResult> Get([FromServices] IMediator mediator, Guid id)
        {
            var query = new GetEvaluationQuerie { id = id };
            query.Validate();
            if (query.Valid)
                return await mediator.Send(query);
            return new QueryResult(false, "Errors", query.Notifications);
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IQueryResult> GetAll([FromServices] IMediator mediator, [FromQuery] BuscaTodosAnunciosQuery query)
        //{
        //    return await mediator.Send(query);
        //}

        //[HttpDelete]
        //public async Task<ICommandResult> Delete([FromServices] IMediator mediator, DeletaAnuncioCommand command)
        //{
        //    command.Validate();
        //    if (command.Valid)
        //        return await mediator.Send(command);
        //    return new CommandResult(false, "Erros", command.Notifications);
        //}
    }
}
