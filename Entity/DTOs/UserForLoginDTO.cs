using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class UserForLoginDTO:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public byte[] UserImage { get; set; }
    }
}
