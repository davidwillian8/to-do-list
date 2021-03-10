using System;
using System.Collections.Generic;
using ToDoList.Entities.Base;

namespace ToDoList.Entities
{
    public class Board : Entity
    {
        public string Name { get; set; }

        public List<Card> Cards { get; set; }
    }
}
