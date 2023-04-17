using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentes.Evaluation.Api.Services;
using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using Studentes.Evaluation.Shared;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("")]
        [AllowAnonymous]
        public async Task<ICommandResult> Post([FromBody] AuthenticationCommand command)
        {
            command.Validate();
            if (!command.Valid)
                return new CommandResult(false, "Errors", command.Notifications);

            if (command.UserName.ToLower() == "admin" && command.PassWord == "123456")
            {
                var token = TokenService.GenerateToken(command.UserName);
                return new CommandResult(true, "", new
                {
                    token = "Bearer " + token
                });
            }
            return new CommandResult(false, "404", StatusCodes.Status404NotFound);
        }

    }
}
