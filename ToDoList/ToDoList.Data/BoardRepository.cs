using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Data.Base;
using ToDoList.Entities;

namespace ToDoList.Data
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {

        public BoardRepository(IContext context) : base(context)
        {

        }
    }
}
