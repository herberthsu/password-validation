using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class LowercaseLettersOnlyRule : ILowercaseLettersOnlyRule
    {
        private readonly ILowercaseLettersOnly _specification;
        public string ErrorMessage => "Password should not contain any uppercase letter";

        public LowercaseLettersOnlyRule(ILowercaseLettersOnly specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}