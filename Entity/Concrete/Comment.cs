using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Comment:IEntity
    {
        public int CommentID { get; set; }
        public string WriterName { get; set; }
        public Post PostId { get; set; }
        public string PostComment { get; set; }

    }
}
