using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _userService.GetByName(name);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbymail")]
        public User GetByMail(string email)
        {
            //bakarız
            var result = _userService.GetByMail(email);
            if (result==null||result!= _userService.GetByMail(email))
            {
                BadRequest(result);
            }
            return result;
        }
        //postumuzu user maili üzerinden açmamızı sağlıyor
        [HttpGet("getpostbyusermail")]
        public Post GetByUserMail(string email)
        {
            var result = _userService.GetByUserMail(email);
            if (result == null || result != _userService.GetByUserMail(email))
            {
                BadRequest(result);
            }
            return result;

        }
        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
