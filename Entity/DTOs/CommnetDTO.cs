using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CommentDTO:IDto
    {
        public string WriterName { get; set; }
        public string Description { get; set; }

    }
}
