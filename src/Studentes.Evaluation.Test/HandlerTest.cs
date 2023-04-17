using Moq;
using Studentes.Evaluation.Domain.OigaContext;
using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using Studentes.Evaluation.Domain.OigaContext.Repositories.Interfaces;
using System;
using System.Threading;
using Xunit;

namespace Studentes.Evaluation.Test
{
    public class HandlerTest
    {
        [Fact(DisplayName = "Add Evaluation Successfully")]
        [Trait("Category", "Handler")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var validCommand = new CreateEvaluationCommand { stars = 20, description = "sdsdsdsad", course_student_id = Guid.NewGuid() };
            var evaluationRepo = new Mock<IEvaluationRepository>();
            var courseStudentRepo = new Mock<ICourseStudentRepository>();
            var handler = new EvaluationHandler(evaluationRepo.Object, courseStudentRepo.Object);
            //Act
            handler.Handle(validCommand,new CancellationToken());
            //Assert
            courseStudentRepo.Verify(r => r.GetById(validCommand.course_student_id), times: Times.Once);
            evaluationRepo.Verify(r => r.CreateAsync(It.IsAny<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>()), times: Times.Once);
        }

        [Theory]
        [InlineData(20, "wewerwer", "471d319f-37f3-41e4-a485-e77141a5e9f7")]
        [InlineData(10, "wewerwer", "412716b2-b107-4d3b-bc33-c0c6b43fa47a")]
        [InlineData(2, "wewerwer", "f2c315a2-c25a-494a-9a87-05c3ffea1a8e")]
        [InlineData(21, "wewerwer", "439c75d6-d437-4770-97f3-060861087cae")]
        public void Invalid_Command_Create_Evaluation_Succees(int stars, string description, string course_student_id)
        {
            var validCommand = new CreateEvaluationCommand { stars = stars, description = description, course_student_id = new Guid(course_student_id) };
            var evaluationRepo = new Mock<IEvaluationRepository>();
            var courseStudentRepo = new Mock<ICourseStudentRepository>();
            var handler = new EvaluationHandler(evaluationRepo.Object, courseStudentRepo.Object);
            //Act
            handler.Handle(validCommand, new CancellationToken());
            //Assert
            courseStudentRepo.Verify(r => r.GetById(validCommand.course_student_id), times: Times.Once);
            evaluationRepo.Verify(r => r.CreateAsync(It.IsAny<Studentes.Evaluation.Domain.OigaContext.Entities.Evaluation>()), times: Times.Once);
        }

    }
}
