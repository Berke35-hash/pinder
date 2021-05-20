using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entity.Concrete;
using Business.Concrete;
using Newtonsoft.Json;
using System.IO;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;
        ICommentService _commentService;
        public PostController(IPostService postService,ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --
            var result = _postService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            
            var result = _postService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]Post post)
        {
            foreach (var file in Request.Form.Files)
            {
               
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                post.PostImage = ms.ToString();

                ms.Close();
                ms.Dispose();
              
            }
            var result = _postService.Add(post);
            //convert işlemi
            //Convert.ToBase64String(post.PostImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm]Post post)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                post.PostImage = ms.ToString();

                ms.Close();
                ms.Dispose();

            }
            var result = _postService.Update(post);
            //convert işlemi
            //Convert.ToBase64String(post.PostImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm]Post post)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                post.PostImage = ms.ToString();

                ms.Close();
                ms.Dispose();

            }
            var result = _postService.Delete(post);
            //convert işlemi
            //Convert.ToBase64String(post.PostImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbypostname")]
        public IActionResult GetbyName(string name)
        {
            var result = _postService.GetByPostName(name);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getpostbyuserid")]
        public IActionResult GetbyUserId(int userid)
        {
            var result = _postService.GetByUserId(userid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getcommentbypostid")]
        public IActionResult GetbyPostId(int postid)
        {
            var result = _commentService.GetByPostId(postid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}
