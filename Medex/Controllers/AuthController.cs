using Medex.Businnes.Interfaces;
using Medex.Data.VO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medex.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVerssion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBussines _loginBussines;

        public AuthController(ILoginBussines loginBussines)
        {
            _loginBussines = loginBussines;
        }


        // POST api/<AuthController>
        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVo user)
        {
            if (user == null) return BadRequest("Ivalid client requesrt");
            var token =_loginBussines.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        
    }
}
