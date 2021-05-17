using Core.Security.JWT;
using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entity.DTOs;
namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDTO userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> Update(UserForRegisterDTO userForRegisterDto, string password);
    }
}
