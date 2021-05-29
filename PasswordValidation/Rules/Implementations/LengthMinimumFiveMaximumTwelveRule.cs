using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class LengthMinimumFiveMaximumTwelveRule : ILengthMinimumFiveMaximumTwelveRule
    {
        private readonly ILengthMinimumFiveMaximumTwelve _specification;
        public string ErrorMessage => "Password Length should be between 5 and 12";
        public string ErrorType => "LengthMinimumFiveMaximumTwelve";

        public LengthMinimumFiveMaximumTwelveRule(ILengthMinimumFiveMaximumTwelve specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}