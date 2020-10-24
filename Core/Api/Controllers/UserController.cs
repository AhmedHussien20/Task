using DataTransferObject;
using Microsoft.AspNetCore.Mvc;

using System;
using ApplicationServices;
using DataTransferObject.User;

namespace Api.Controllers.Edarah
{
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly UserApplication _userApplication;
        public UserController(UserApplication userApplication)
        {
            
            _userApplication = userApplication;
        }

        [Route("Api/UserData")]
        [HttpPost]
        public IActionResult Adduser(UserRegistDTO userRegistDTO)
        {
            var userObjectWithToken = _userApplication.AddUser(userRegistDTO);
            return Ok(userObjectWithToken);
        }
        
        [Route("Api/UserLogin")]
        [HttpPost]
        public IActionResult LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            var userObjectWithToken = _userApplication.ValidateUser(userLoginDTO);
            return Ok(userObjectWithToken);
        }
    }
}
