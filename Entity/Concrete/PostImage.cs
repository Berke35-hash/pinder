using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class PostImage: IEntity
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        //[ModelBinder(BinderType = typeof(ImageToByteArrayModelBinder))]
        public byte[] ImageData { get; set; }

    }
}
