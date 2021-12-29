using Commander.Data;
using UserModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commander.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using UserRolModel.Models;

namespace Commander.Controllers
{
    [Route("api/[controller1]")]
    [ApiController]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRolRepo _repository;
        private readonly IMapper _mapper;

        public UserRolController(IUserRolRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserRol>> GetUserRol()
        {
            var userRol = _repository.GetUserRol();
             if (userRol == null)
            {
                return NotFound();
            }
            return Ok(userRol);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserRol> GetUserRolById(int id)
        {
            var userRol = _repository.GetUserRolById(id);

            if (userRol == null)
            {
                return NotFound();
            }

            return Ok (userRol);
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <UserRolReadDto> CreateUserRol(UserRolCreateDto userRolCreateDto)
        {
            var userRolModel = _mapper.Map<UserRol>(userRolCreateDto);
            _repository.CreateUserRol(userRolModel);
            _repository.SaveChanges();

            var userRolReadDto = _mapper.Map<UserRolReadDto>(userRolModel);

            return CreatedAtRoute(nameof(GetUserRolById), new {Id = userRolReadDto.Id}, userRolReadDto);      
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUserRol(int id, UserRolUpdateDto userRolUpdateDto)
        {
            var userRolModelFromDto = _repository.GetUserRolById(id);
            if(userRolModelFromDto == null)
            {
                return NotFound();
            }
            _mapper.Map(userRolUpdateDto, userRolModelFromDto);

            _repository.UpdateUserRol(userRolModelFromDto);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUserRolUpdate(int id, JsonPatchDocument<UserRolUpdateDto> patchDoc)
        {
            var userRolModelFromRepo = _repository.GetUserRolById(id);
            if(userRolModelFromRepo == null)
            {
                return NotFound();
            }

            var userRolToPatch = _mapper.Map<UserRolUpdateDto>(userRolModelFromRepo);
            patchDoc.ApplyTo(userRolToPatch, ModelState);

            if(!TryValidateModel(userRolToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userRolToPatch, userRolModelFromRepo);

            _repository.UpdateUserRol(userRolModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUserRol(int id)
        {
            var userRolModelFromRepo = _repository.GetUserRolById(id);
            if(userRolModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUserRol(userRolModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}