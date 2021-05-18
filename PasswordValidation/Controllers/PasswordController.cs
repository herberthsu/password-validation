using System.Net;
using Microsoft.AspNetCore.Mvc;
using PasswordValidation.Model;
using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IValidator<string> _passwordValidator;

        public PasswordController(IValidator<string> passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }
        
        [Route("validate"), HttpGet]
        public IActionResult Get([FromQuery] string password)
        {
            var result = _passwordValidator.Validate(password);
            
            if (result.IsValid)
            {
                return Ok();
            }

            return Conflict(new ResponseErrorModel
            {
                Error = new ErrorModel
                {
                    Code = (int) HttpStatusCode.Conflict,
                    Type = result.Type,
                    Message = result.Message
                }
            });
        }
    }
}
