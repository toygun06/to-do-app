using Application.Features.Tasks.Commands.Add;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    public class TaskController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
