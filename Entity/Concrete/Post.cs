using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string Email { get; set; }
        public string Prize{ get; set; }
        public string Location { get; set; }
        public DateTime PostDate { get; set; }
        public string Comment { get; set; }
        public string TelNo{ get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
