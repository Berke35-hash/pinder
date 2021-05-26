using Business.Abstract;
using Business.Constants;
using Core.Security.JWT;
using Core.Utilities.Hashing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserImage = userForRegisterDto.UserImage,
                Status = true,
                //phone number sonradan eklendi
                PhoneNumber = userForRegisterDto.PhoneNumber
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.EmailAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }
        public IDataResult<User> Update(UserForRegisterDTO userForRegisterDto, string password)
        {
            var user = new User();
            var result = _userService.GetById(userForRegisterDto.Id);
            byte[] passwordHash, passwordSalt;
           
            if (password!=null)
            {
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user = new User
                {
                    Id = userForRegisterDto.Id,
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    UserImage = userForRegisterDto.UserImage,
                    Status = true,
                    //phone number sonradan eklendi
                    PhoneNumber = userForRegisterDto.PhoneNumber
                };
            }
            else
            {
                user = new User
                {
                    Id = userForRegisterDto.Id,
                    Email = userForRegisterDto.Email!=null?userForRegisterDto.Email:result.Email,
                    FirstName = userForRegisterDto.FirstName !=null ? userForRegisterDto.FirstName : result.FirstName,
                    LastName = userForRegisterDto.LastName != null ? userForRegisterDto.LastName : result.LastName,
                    PasswordHash = result.PasswordHash,
                    PasswordSalt = result.PasswordSalt,
                    UserImage = userForRegisterDto.UserImage != null ? userForRegisterDto.UserImage : result.UserImage,
                    Status = true,
                    //phone number sonradan eklendi
                    PhoneNumber = userForRegisterDto.PhoneNumber != null ? userForRegisterDto.PhoneNumber : result.PhoneNumber
                };
               
            }
           



            _userService.Update(user);
            return new SuccessDataResult<User>(user, userForRegisterDto.PhoneNumber);
        }
    }
}
