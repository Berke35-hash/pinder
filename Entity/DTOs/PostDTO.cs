using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class PostDTO:IDto
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string  Email{ get; set; }
        public string Prize { get; set; }
        public DateTime PostDate { get; set; }
        public string Comment { get; set; }
        public string TelNo { get; set; }
        public string Description { get; set; }

    }
}
