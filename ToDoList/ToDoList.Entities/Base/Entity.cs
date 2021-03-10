using System;

namespace ToDoList.Entities.Base
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }


        public string partition { 
            get 
            {
                return "TST";
            } 
            set { } 
        }
    }
}