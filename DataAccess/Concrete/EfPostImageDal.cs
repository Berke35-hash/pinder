using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfPostImageDal: EfEntityRepositoryBase<PostImage,PinderContext>, IPostImageDal
    {
        public List<PostImageDTO> GetPostImageDetails()
        {
            using (PinderContext context = new PinderContext())
            {
                var result = from p in context.PostImage
                             select new PostImageDTO
                             { 
                                 ImageData = p.ImageData
                             };
                return result.ToList();
            }
        }
    }
}
