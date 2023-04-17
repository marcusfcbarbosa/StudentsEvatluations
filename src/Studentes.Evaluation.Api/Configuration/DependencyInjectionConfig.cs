using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using Studentes.Evaluation.Infra.Repositories;
using Studentes.Evaluation.Infra.SqlContext;
using System.Reflection;

namespace Studentes.Evaluation.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region"Context"
            services.AddScoped<Oiga_DBContext, Oiga_DBContext>();
            #endregion

            #region"Repositories"
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            #endregion


            #region"mediator"
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateEvaluationCommand).GetTypeInfo().Assembly);
            #endregion

        }
    }
}
