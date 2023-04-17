using Studentes.Evaluation.Domain.OigaContext.Commands.Input;
using System;
using Xunit;

namespace Studentes.Evaluation.Test
{
    public class CommandEvaluationTest
    {
        [Theory]
        [InlineData(0, "wewerwer", "00000000-0000-0000-0000-000000000000")]
        [InlineData(0, "wewerwer", "00000000-0000-0000-0000-000000000000")]
        [InlineData(-2, "", "f2c315a2-c25a-494a-9a87-05c3ffea1a8e")]
        [InlineData(-1, "wewerwer", "439c75d6-d437-4770-97f3-060861087cae")]
        public void Invalid_Command_Create_Evaluation_Error(int stars, string description, string course_student_id)
        {
            var _invalidCommand = new CreateEvaluationCommand { stars = stars, description = description, course_student_id = new Guid(course_student_id) };
            _invalidCommand.Validate();
            Assert.Equal(_invalidCommand.Valid, false);
        }

        [Theory]
        [InlineData(20, "wewerwer", "471d319f-37f3-41e4-a485-e77141a5e9f7")]
        [InlineData(10, "wewerwer", "412716b2-b107-4d3b-bc33-c0c6b43fa47a")]
        [InlineData(2, "wewerwer", "f2c315a2-c25a-494a-9a87-05c3ffea1a8e")]
        [InlineData(21, "wewerwer", "439c75d6-d437-4770-97f3-060861087cae")]
        public void Valid_Command_Create_Evaluation_Sucess(int stars, string description,string course_student_id)
        {
            var _validCommand = new CreateEvaluationCommand { stars = stars, description = description, course_student_id = new Guid(course_student_id) };
            _validCommand.Validate();
            Assert.Equal(_validCommand.Valid, true);
        }
    }
}
