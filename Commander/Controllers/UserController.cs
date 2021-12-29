using Commander.Data;
using UserModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers{
    //apiController
    [Route("api/commands")]
    [ApiController]
    public class UserController : ControllerBase{

        private readonly MockUserRepo _repository = new MockUserRepo();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers(){
            
            var userItems = _repository.GetUsers();
            
            return Ok(userItems);
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id){
            
            var userItems = _repository.GetUserById(id);

            return Ok(userItems);
        }
    }
}