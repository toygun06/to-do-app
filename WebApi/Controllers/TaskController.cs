using Application.Features.Tasks.Commands.Add;
using Application.Features.Tasks.Commands.Delete;
using Application.Features.Tasks.Commands.Update;
using Application.Features.Tasks.Commands.UpdateTaskStatus;
using Application.Features.Tasks.Queries.GetById;
using Application.Features.Tasks.Queries.GetByUserId;
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] UpdateTaskStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskById([FromQuery] GetTaskByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskByUserId([FromQuery] GetTasksByUserIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
