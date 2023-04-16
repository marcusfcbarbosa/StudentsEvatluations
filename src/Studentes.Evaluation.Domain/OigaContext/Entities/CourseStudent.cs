using Studentes.Evaluation.Shared;
using System;
using System.Collections.Generic;

namespace Studentes.Evaluation.Domain.OigaContext.Entities
{
    public class CourseStudent : Entity
    {
        public Guid course_id { get; private set; }
        public Course course { get; private set; }
        public Guid student_id { get; private set; }
        public Student student { get; private set; }
        public IEnumerable<Evaluation> Evaluations { get; private set; }
        public int grade { get; private set; }
        protected CourseStudent() { }
        public CourseStudent(Course course,
                              Student student,
                              int grade)
        {
            
            this.course = course;
            this.student = student;
            this.grade = grade;
        }



    }
}
