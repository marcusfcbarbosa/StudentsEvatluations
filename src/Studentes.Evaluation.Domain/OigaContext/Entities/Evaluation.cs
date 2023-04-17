using Studentes.Evaluation.Shared;
using System;

namespace Studentes.Evaluation.Domain.OigaContext.Entities
{
    public class Evaluation : Entity
    {
        public Guid course_student_id { get; private set; }
        public CourseStudent courseStudent { get; private set; }
        public int stars { get; private set; }
        public string description { get; private set; }
        public DateTime creation_date { get; private set; }

        protected Evaluation() { }
        public Evaluation(CourseStudent courseStudents, 
                          int stars, 
                          string description)
        {
            this.courseStudent = courseStudents;
            this.stars = stars;
            this.description = description;
            this.creation_date = DateTime.Now;
        }



    }
}
