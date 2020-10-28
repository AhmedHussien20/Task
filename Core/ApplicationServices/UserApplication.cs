using DataAccess;
using DataTransferObject;
using DataTransferObject.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ApplicationServices
{
    public class UserApplication
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public UserApplication(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        UserData Predata(UserRegistDTO dto)
        {
            UserData u = new UserData();
            u.MobileNo = dto.MobileNo;
            u.Email = dto.Email;
            u.UserPassword = dto.Password;
            u.UserName = dto.UserName;
            return u;
        }
        public object AddUser(UserRegistDTO dto)
        {

            var chekUserExist = _unitOfWork.UserDataRepository.GetAll().Any(x => x.Email == dto.Email || x.UserName==dto.UserName );
            UserData record = new UserData(); 
            if (chekUserExist)
                throw new BussinessException("this Email is Exist!");
          
                record= Predata(dto);
                _unitOfWork.UserDataRepository.Add(record);
                _unitOfWork.SaveChanges();
                
            
            return new
            {
                dto.UserName,
                dto.MobileNo,
                dto.Email,
                Token = CreateJwtToken(record)
            };
        }
        public object ValidateUser(UserLoginDTO userLoginDTO)
        {
            UserData userData = _unitOfWork.UserDataRepository
                            .GetAll()
                            .Where(user => user.Email == userLoginDTO.Email && user.UserPassword == userLoginDTO.Password)
                            .SingleOrDefault();

            if(userData == null)
            {
                throw new BussinessException($"User Data Not found");
            }

            return new
            {
                userData.ID,
                
                userData.Email,
                userData.UserName,
               
                Token = CreateJwtToken(userData)
            };
        }
         
        private string CreateJwtToken(UserData userData)
        {
            var signInCredentials = GetSigningCredentials();
            var claims = GetClaims(userData);
            var tokenOptions = GenerateTokenOptions(signInCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection("SECRET").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(UserData userData)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", userData.ID.ToString()),
                new Claim("Email", userData.Email.ToString())
            };
            
            
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                //issuer: jwtSettings.GetSection("validIssuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
