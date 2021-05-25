using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationsRules.FluentValidation
{
    public class PostValidator: AbstractValidator<Post>
    {

        public PostValidator()
        {
            //RuleFor(p => p.Id).NotEmpty();
            //RuleFor(p => p.Id).MinimumLength(3);
            //RuleFor(p => p.Location).NotEmpty();
            //RuleFor(p => p.TelNo).NotEmpty();
        }
    }
}
