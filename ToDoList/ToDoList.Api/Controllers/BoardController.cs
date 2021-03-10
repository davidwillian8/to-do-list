using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("A propriedade Id não pode ser vazia");
            }

            var board = await _boardRepository.Get(id);

            if (board == null)
            {
                return NotFound("Não foi possivel encontrar um board com esse Id.");
            }

            return Ok(new BoardViewModel { Id = Guid.Parse(board.Id), Name = board.Name });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _boardRepository.GetAll();

            return Ok(boards.Select(s => new BoardViewModel { Id = Guid.Parse(s.Id), Name = s.Name }));
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
                Name = board.Name,
                Cards = null
            });

            return Ok(new BoardViewModel { Id = Guid.Parse(newBoard.Id), Name = newBoard.Name });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BoardViewModel board)
        {
            if (board.Id == Guid.Empty)
            {
                return BadRequest("A propriedade Id não pode ser vazia");
            }

            await _boardRepository.Update(new Board
            {
                Id = board.Id.ToString(),
                Name = board.Name
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _boardRepository.Delete(id);

            return Ok();
        }
    }
}