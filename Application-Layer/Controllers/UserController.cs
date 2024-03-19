using System.Security.Claims;
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

        //[Authorize]
        //[HttpPut("updateUser")]
        //public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        //{
        //    // hämtar den inloggade användarens ID från claim
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // jämför om det ID som skickats med kommandot matchar den inloggade användarens ID
        //    if (userId != command.UserId.ToString())
        //    {
        //        return Unauthorized("Du kan bara uppdatera din egen information.");
        //    }

        //   var result = await _mediator.Send(command);

        //    try
        //    {
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Authorize]
        //[HttpDelete("deleteUser/{userId}")]
        //public async Task<IActionResult> DeleteUser()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var command = new DeleteUserCommand(userId);
        //    var result = await _mediator.Send(command);

        //    if (result.Success)
        //    {
        //        return Ok(new { result.Message, result.UserId, result.Email });
        //    }
        //    else
        //    {
        //        if (result.Message == "User not found")
        //        {
        //            return NotFound(result.Message);
        //        }
        //        else
        //        {
        //            return BadRequest(result.Message);
        //        }
        //    }
        //}

    }
}
