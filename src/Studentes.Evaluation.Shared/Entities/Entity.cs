using FluentValidator;
using System;

namespace Studentes.Evaluation.Shared
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
