using Commander.Data;
using Microsoft.AspNetCore.Mvc;
using UserRolModel.Models;

namespace Commander.Controllers
{
    //apiController
    [Route("api/commands2")]
    [ApiController]
    public class UserRolController : ControllerBase
    {

        private readonly MockUserRolRepo _repository = new MockUserRolRepo();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<UserRol>> GetUserRol()
        {

            var userRol = _repository.GetUserRol();

            return Ok(userRol);
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<UserRol> GetUserRolById(int id)
        {

            var userRol = _repository.GetUserRolById(id);

            return Ok(userRol);
        }
    }
}