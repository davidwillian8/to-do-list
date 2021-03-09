using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Api.ViewModels;

namespace ToDoList.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
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
            return Ok();
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