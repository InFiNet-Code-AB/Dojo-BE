using System.Security.Claims;
using Application_Layer.Commands.DeleteUser;
using Application_Layer.Commands.RegisterNewUser;
using Application_Layer.Commands.UpdateUser;
using Application_Layer.DTO_s;
using Application_Layer.Queries.GetAllUsers;
using Application_Layer.Queries.GetUserById;
using Application_Layer.Queries.LoginUser;
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
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO userDto)
        {
            try
            {
                return Ok(await _mediator.Send(new RegisterUserCommand(userDto)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var loginResult = await _mediator.Send(new LoginUserQuery { Email = email, Password = password });

                if (loginResult.Successful)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(loginResult.Error);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"Användaren med ID {id} hittades inte.");
            }
        }

        //[HttpGet("by-email/{email}")]
        //public async Task<IActionResult> GetUserByEmail(string email)
        //{
        //    var user = await _mediator.Send(new GetUserByEmailQuery(email));

        //    if (user != null)
        //    {
        //        return Ok(user);  // Eller anpassa till en DTO som tidigare nämnt
        //    }
        //    else
        //    {
        //        return NotFound($"Användaren med e-postadressen {email} hittades inte.");
        //    }
        //}

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllUsersQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdatingUserDTO userDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var command = new UpdateUserCommand(userDto, userId);

            try
            {
                var result = await _mediator.Send(command);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not recognized.");
            }

            var command = new DeleteUserCommand(userId);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("User successfully deleted.");
            }
            else
            {
                return BadRequest("Failed to delete the user.");
            }
        }
    }
}
