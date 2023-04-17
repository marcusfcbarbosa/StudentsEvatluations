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
        [Route("")]
        public async Task<IQueryResult> Get([FromServices] IMediator mediator, 
                        [FromQuery]string id)
        {
            var query = new GetEvaluationQuerie { id = new Guid(id) };
            query.Validate();
            if (query.Valid)
                return await mediator.Send(query);
            return new QueryResult(false, "Errors", query.Notifications);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IQueryResult> GetAll([FromServices] IMediator mediator,
            [FromQuery] GetAllEvaluationQuerie query)
        {
            return await mediator.Send(query);
        }

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
