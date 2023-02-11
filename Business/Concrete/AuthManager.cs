using Business.Abstract;
using Core.Entites;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _UserService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _UserService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto , string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);


            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.FirstName,
                Email = userForRegisterDto.Email,
                NormalizedUserName = userForRegisterDto.FirstName.ToUpper(),
                PhoneNumber = userForRegisterDto.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _UserService.Add(user);
            return new SuccessDataResult<User>(user, "Saved");
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _UserService.GetByMail(userForLoginDto.Email);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("User not exist.");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Password Wrong");
            }
            return new SuccessDataResult<User>(userToCheck.Data, "Success login");
        }
        public IResult UserExists(string email)
        {
            if (_UserService.GetByMail(email).Data != null)
            {
                return new ErrorResult("User already exist.");
            }
            return new SuccessResult();
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _UserService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token created.");
        }

    }
}
