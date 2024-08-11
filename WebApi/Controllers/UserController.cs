using Application.Features.Users.Commands.SoftDelete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SoftDelete([FromBody] UserSoftDeleteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
