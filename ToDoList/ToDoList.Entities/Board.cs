using System;
using System.Collections.Generic;
using ToDoList.Entities.Base;

namespace ToDoList.Entities
{
    public class Board : Entity
    {
        public string Nome { get; set; }

        public List<Card> Cards { get; set; }
    }
}
