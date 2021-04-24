using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IPostImageService _imageService;
        public ImageController(IPostImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost("uploadimage")]
        public IActionResult UploadImage(PostImage postImage)
        {
            var result = _imageService.Add(postImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
