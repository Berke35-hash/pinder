using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ImageToByteArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // ...
            // implement it based on your actual requirement
            // code logic here
            // ...



            if (bindingContext.ActionContext.HttpContext.Request.Form.Files["ImagePath"]?.Length > 0)
            {
                var fileBytes = new byte[bindingContext.ActionContext.HttpContext.Request.Form.Files["ImagePath"].Length];

                using (var ms = new MemoryStream())
                {
                    bindingContext.ActionContext.HttpContext.Request.Form.Files["ImagePath"].CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                bindingContext.Result = ModelBindingResult.Success(fileBytes);
            }



            return Task.CompletedTask;
        }
    }
}
