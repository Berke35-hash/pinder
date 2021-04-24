using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class PostImageDTO: IDto
    {
        public byte[] ImageData { get; set; }
    }
}
