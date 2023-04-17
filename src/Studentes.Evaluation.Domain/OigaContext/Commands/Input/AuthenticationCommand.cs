using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using Studentes.Evaluation.Shared;
using Studentes.Evaluation.Shared.Commands;

namespace Studentes.Evaluation.Domain.OigaContext.Commands.Input
{
    public class AuthenticationCommand : Notifiable, ICommand, IRequest<ICommandResult>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNullOrEmpty(UserName, "UserName", "UserName  is required")
             );
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(PassWord, "PassWord", "PassWord  is required")
            );
        }
    }
}
