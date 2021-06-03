using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DATN.Entities;
using DATN.Models;
using DATN.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IAuthoRepository _authRepo;
        private readonly IMapper _mapper;
        public UserController(IAuthoRepository authRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }

        [Authorize(Roles = Role.Admin)]
        //[AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserModel model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                _authRepo.CreateUser(user, model.Password);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _authRepo.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _authRepo.GetById(id);
            if(user == null )
            {
                return NotFound();
            }
            // chi co admin moi co the xem ho so cua ng khac
            var currentUserId = User.Identity.Name;
            if(id.ToString() != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
            var userDto = _mapper.Map<UserModel>(user);
            return Ok(userDto);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserModel userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;
            var currentUserID = User.Identity.Name;
            if (id.ToString() != currentUserID && !User.IsInRole(Role.Admin))
                return Forbid();

            try
            {
                _authRepo.UpdateUser(user, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message );
            }

        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authRepo.DeleteUser(id);
            return Ok();
        }
    }
}
