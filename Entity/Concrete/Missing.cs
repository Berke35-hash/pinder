using Core.Entities;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Missing:IEntity
    {
        public int MissingId { get; set; }
        public int MyProperty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public DateTime MissinDate { get; set; }
        public bool Status { get; set; }


    }
}
