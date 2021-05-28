using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class LowercaseLettersOnlyRule : ILowercaseLettersOnlyRule
    {
        private readonly ILowercaseLetterOnly _specification;
        public string ErrorMessage => "Password should not contain any uppercase letter";

        public LowercaseLettersOnlyRule(ILowercaseLetterOnly specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}