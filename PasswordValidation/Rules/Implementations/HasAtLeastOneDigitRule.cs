using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class HasAtLeastOneDigitRule : IHasAtLeastOneDigitRule
    {
        private readonly IHasAtLeastOneDigit _specification;
        public string ErrorMessage => "Password should contain at least 1 digit";
        public string ErrorType => "ContainsNoDigit";

        public HasAtLeastOneDigitRule(IHasAtLeastOneDigit specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}