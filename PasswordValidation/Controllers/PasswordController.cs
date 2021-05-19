using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private static ILogger<PasswordController> _logger;

        public PasswordController(IValidator<string> passwordValidator, ILogger<PasswordController> logger)
        {
            _passwordValidator = passwordValidator;
            _logger = logger;
        }
        
        [Route("validate"), HttpGet]
        public IActionResult Get([FromQuery] string password)
        {
            try
            {
                var result = _passwordValidator.Validate(password);
            
                if (result.IsValid)
                {
                    return Ok();
                }
            
                _logger.LogInformation($"Password: {password} | Type: {result.Type} | Message: {result.Message}");
            
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
            catch (Exception e)
            {
                _logger.LogError($"Exception Caught | StackTrace: {e.StackTrace} | Message: {e.Message}");
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}
