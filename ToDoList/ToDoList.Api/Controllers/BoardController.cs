using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Api.ViewModels;
using ToDoList.Entities;

namespace ToDoList.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;

        public BoardController(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoardViewModel board)
        {
            if (board.Id != Guid.Empty)
            {
                return BadRequest("A propriedade Id não deve ser preenchida.");
            }

            var newBoard = await _boardRepository.Insert(new Board
            { 
                Nome = board.Name, Cards = null 
            });

            return Ok(newBoard);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BoardViewModel board)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok();
        }
    }
}