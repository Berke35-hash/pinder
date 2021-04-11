using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --
            Thread.Sleep(5000);
            var result = _postService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
