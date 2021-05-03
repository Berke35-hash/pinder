using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Comment:IEntity
    {
        public int Id{ get; set; }
        public string WriterName { get; set; }
        public string PostComment { get; set; }
        public int UserId { get; set; }
    }
}
