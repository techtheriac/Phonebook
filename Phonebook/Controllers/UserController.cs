using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Phonebook.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Phonebook.Domain.Models;
using Phonebook.Domain.DTO;

namespace Phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(
            ILogger<UserController> logger,
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            _logger.LogInformation($"Registration attempt from {model.Email}");

            if(!ModelState.IsValid)
                 return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<User>(model);
                user.UserName = model.Email;
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, model.Roles);

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(Register)}");
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var result = _mapper.Map<UserDto>(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(GetUser)}");
                return StatusCode(500, "Internal Server error. Please try again later");
            }
        }
        
        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                var result = _mapper.Map<UserDto>(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(GetUser)}");
                return StatusCode(500, "Internal Server error. Please try again later");
            }
        }
        
        [HttpGet]
        [Route("all-users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                var result = _mapper.Map<IList<UserDto>>(users);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong in {nameof(GetUser)}");
                return StatusCode(500, "Internal Server error. Please try again later");
            }
        }

        [HttpDelete]
        //[Route("delete-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                var result = _mapper.Map<UserDto>(user);

                if (user == null)
                    return NotFound();

                await _userManager.DeleteAsync(user);

                return Ok(result);
            }
            catch (Exception e)
            {

                _logger.LogError(e, $"Something went wrong in {nameof(DeleteUser)}");
                return StatusCode(500, "Internal Server error. Please try again later");
            }
        }

        [HttpGet("{name?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchUser(string name)
        {
            try
            {
                
                var users = await _userManager.Users.Where(e => e.FirstName.Contains(name) ||
                e.LastName.Contains(name)).ToListAsync();

                var result = _mapper.Map<IList<GetUserDto>>(users);

                return Ok(result);

            }
            catch (Exception e)
            {

                _logger.LogError(e, $"Something went wrong in {nameof(SearchUser)}");
                return StatusCode(500, "Internal Server error. Please try again later");
            }
        }
    }
}
