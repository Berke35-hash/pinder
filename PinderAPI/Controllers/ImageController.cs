using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IPostImageService _imageService;
        //PinderContext _context;
        public static IWebHostEnvironment _environment;
        //public ImageController(IWebHostEnvironment environment)
        //{
        //    _environment = environment;
        //}
        public ImageController(IPostImageService imageService)
        {
            _imageService = imageService;
        }

        //[HttpPost]
        //public async Task<string> Post([FromForm] FileUpload objfile) 
        //{
        //    if (objfile.ImageData.Length>0)
        //    {
        //        try
        //        {
        //            if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
        //            {
        //                Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + objfile.ImageData.FileName))
        //            {
        //                objfile.ImageData.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\uploads\\" + objfile.ImageData.FileName;
        //            }

        //        }
        //        catch (Exception ex) 
        //        {
        //            return ex.ToString();
        //        }
        //    }
        //    else
        //    {
        //        return "unsuccesful";
        //    }
        //}
        //[HttpPost("uploadimage")]
        //public IActionResult Add(PostImage postImage)
        //{

        //    var result = _imageService.Add(postImage);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}
        [HttpPost("upload")]
        public IActionResult UploadImage([FromForm]PostImage img)
        {
            foreach (var file in Request.Form.Files)
            {
                //PostImage img = new PostImage();
                //img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
                //_imageService.Add(img);
                //_imageService.SaveChanges();
            }
            var result= _imageService.Add(img);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("retrive")]
        public ActionResult RetrieveImage(int Id)
        {
            var result = _imageService.Get(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
