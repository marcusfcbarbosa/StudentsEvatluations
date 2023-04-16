using Studentes.Evaluation.Shared;
using System;
using System.Collections.Generic;

namespace Studentes.Evaluation.Domain.OigaContext.Entities
{
    public class Student : Entity
    {
        public string name { get; private set; }
        public string last_name { get; private set; }
        public DateTime creation_date { get; private set; }
        public bool active { get; private set; }
        public IEnumerable<CourseStudent> CourseStudents { get; private set; }
        protected Student() { }
        public Student(string name, string last_name)
        {
            this.name = name;
            this.last_name = last_name;
            this.active = true;
            this.creation_date = DateTime.Now;
        }
    }
}
