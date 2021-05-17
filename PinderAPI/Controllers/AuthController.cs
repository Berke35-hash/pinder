using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(userToLogin.Data.Id);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register([FromForm]UserForRegisterDTO userForRegisterDto)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                userForRegisterDto.UserImage = ms.ToArray();

                ms.Close();
                ms.Dispose();

            }
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            //convert işlemi
            Convert.ToBase64String(userForRegisterDto.UserImage);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public ActionResult Update([FromForm] UserForRegisterDTO userForRegisterDto)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                userForRegisterDto.UserImage = ms.ToArray();

                ms.Close();
                ms.Dispose();

            }
            //var userExists = _authService.UserExists(userForRegisterDto.Email);
            //if (!userExists.Success)
            //{
            //    return BadRequest(userExists.Message);
            //}
            //convert işlemi
            Convert.ToBase64String(userForRegisterDto.UserImage);
            var registerResult = _authService.Update(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
