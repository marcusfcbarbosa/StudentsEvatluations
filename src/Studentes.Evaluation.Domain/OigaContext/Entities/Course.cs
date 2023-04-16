using Studentes.Evaluation.Shared;
using System;
using System.Collections.Generic;

namespace Studentes.Evaluation.Domain.OigaContext.Entities
{
    public class Course : Entity
    {
        public string name { get; private set; }
        public DateTime creation_date { get; private set; }
        public bool active { get; private set; }
        public IEnumerable<CourseStudent> CourseStudents { get; private set; }
        protected Course() { }
        public Course(string name)
        {
            this.name = name;
            this.creation_date = DateTime.Now;
            this.active = true;
        }


    }
}
