using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PinderAPI.Controllers
{
    public class ImageControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Uploadımage()
        {
            foreach (var file in Request.Form.Files)
            {
                PostImage postImage = new PostImage();
                postImage.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                postImage.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                Contexr
            }

        }
    }
}
