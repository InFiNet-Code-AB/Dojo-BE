using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application_Layer.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            try
            {
                return await _mediator.Send(new RegisterUserCommand(userDto));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            try
            {
                return await _mediator.Send(new LoginUserQuery { Email = email, Password = password });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserByIdCommand command)
        {
            // hämtar den inloggade användarens ID från claim
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // jämför om det ID som skickats med kommandot matchar den inloggade användarens ID
            if (userId != command.UserId.ToString())
            {
                return Unauthorized("Du kan bara uppdatera din egen information.");
            }

            try
            {
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new DeleteUserCommand(userId);
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new { result.Message, result.UserId, result.Email });
            }
            else
            {
                if (result.Message == "User not found")
                {
                    return NotFound(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
        }

    }
}
