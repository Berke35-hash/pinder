using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    class UserForLoginDTO:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
