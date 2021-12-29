using Commander.Data;
using UserModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commander.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            var userItems = _repository.GetUsers();
             if (userItems == null)
            {
                return NotFound();
            }
            return Ok(userItems);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);

            if (userItem == null)
            {
                return NotFound();
            }

            return Ok (userItem);
        }
        
        //POST api/commands
        [HttpPost]
        public ActionResult <UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);      
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModelFromDto = _repository.GetUserById(id);
            if(userModelFromDto == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromDto);

            _repository.UpdateUser(userModelFromDto);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);

            if(!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}