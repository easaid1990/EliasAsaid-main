using Medfar.Interview.DAL.Repositories;
using Medfar.Interview.Types;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository repo, ILogger<UserController> logger)
        : ControllerBase
    {
        private readonly IUserRepository _repo = repo;
        private readonly ILogger<UserController> _logger = logger;

        /// <summary>
        /// Gets all users.
        /// </summary>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var users = await _repo.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
