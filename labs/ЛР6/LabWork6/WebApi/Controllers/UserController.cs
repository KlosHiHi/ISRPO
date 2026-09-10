using Microsoft.AspNetCore.Mvc;

public class User()
{
    public User(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users =
        [
            new User(1, "Андрей"),
            new User(2, "Виктор"),
            new User(3, "Елена"),
        ];

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            if (!int.TryParse(id, out int uid))
            {

                return BadRequest(new { error = "Invalid ID format", statusCode = "404" });
            }

            var user = Users.FirstOrDefault(u => u.Id == uid);
            if (user is null)
            {

                return NotFound();
            }
            return user;
        }
    }
}
