using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string LirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }

    }
}
