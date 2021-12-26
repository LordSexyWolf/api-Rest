using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers{
    //apiController
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase{

        private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
            
            var commandsItems = _repository.GetAllCommands();
            
            return Ok(commandsItems);
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id){
            
            var commandsItems = _repository.GetCommandById(id);

            return Ok(commandsItems);
        }
    }
}