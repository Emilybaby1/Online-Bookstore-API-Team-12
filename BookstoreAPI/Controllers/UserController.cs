using BookStore__Management_system.Data;
using BookStore__Management_system.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore__Management_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger logger;
        private readonly AuthService authService;

        public UserController(ILogger logger, AuthService authService)
        {
            this.authService = authService;
            this.logger = logger;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<User[]> GetAll()
        {
            try
            {
                var users = this.authService.GetAll();
                return Ok(users);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
        }
    }
}
