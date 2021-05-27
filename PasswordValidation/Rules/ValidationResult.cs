using System.Collections.Generic;
using System.Linq;

namespace PasswordValidation.Rules
{
    public class ValidationResult
    {
        public string Message => Errors.Any()
            ? Errors.Select(error => error.Message).Aggregate((current, next) => current + "," + next)
            : string.Empty;

        public string Type => Errors.Any()
            ? Errors.Select(error => error.Type).Aggregate((current, next) => current + "," + next)
            : string.Empty;

        public List<ValidationError> Errors { get; }

        public bool IsValid => !Errors.Any();

        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }
        
        public void SetError(ValidationError error)
        {
            Errors.Add(error);
        }
    }
}