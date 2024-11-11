using Microsoft.AspNetCore.Mvc;
using MyGameBackend.Services;
using MyGameBackend.Models;

namespace MyGameBackend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public ActionResult<User> SignUp([FromBody] UserDto userDto)
        {
            var user = _userService.Register(userDto.Email, userDto.Password);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] UserDto userDto)
        {
            var user = _userService.Login(userDto.Email, userDto.Password);
            if (user == null) return Unauthorized("Invalid credentials");
            return Ok(user);
        }

        [HttpGet("profile")]
        public ActionResult<User> GetUserProfile()
        {
            var user = _userService.GetUserProfile(); // Retrieve logged-in user details
            return Ok(user);
        }

        [HttpPost("complete-daily-question")]
        public ActionResult CompleteDailyQuestion()
        {
            var user = _userService.GetUserProfile(); // Retrieve logged-in user details
            _userService.CompleteDailyQuestion(user);
            return Ok();
        }

        [HttpPost("upgrade-character")]
        public ActionResult UpgradeCharacter()
        {
            var user = _userService.GetUserProfile(); // Retrieve logged-in user details
            _userService.UpgradeCharacter(user);
            return Ok();
        }
    }
}