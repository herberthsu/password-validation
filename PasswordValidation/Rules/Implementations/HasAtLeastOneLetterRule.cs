using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class HasAtLeastOneLetterRule : IHasAtLeastOneLetterRule
    {
        private readonly IHasAtLeastOneLetter _specification;
        public string ErrorMessage => "Password should contain at least 1 letter";

        public HasAtLeastOneLetterRule(IHasAtLeastOneLetter specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}