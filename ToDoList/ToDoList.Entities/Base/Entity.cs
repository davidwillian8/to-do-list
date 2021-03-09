using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
