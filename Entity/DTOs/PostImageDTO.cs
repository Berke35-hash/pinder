using Core.Entities;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class PostImageDTO: IDto
    {
        //[ModelBinder(BinderType = typeof(ImageToByteArrayModelBinder))]
        public byte[] ImageData { get; set; }
    }
}
