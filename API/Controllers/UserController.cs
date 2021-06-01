using System.Threading.Tasks;
using API.Controllers.Base;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService) : base(mapper)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List(int id)
        {
            var result = await _userService.List();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            var result = await _userService.Create(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(User model)
        {
            var result = await _userService.Update(model);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}