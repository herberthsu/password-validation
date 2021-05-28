using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class NonSpecialCharactersRule : INonSpecialCharactersRule
    {
        private readonly INonSpecialCharacters _specification;
        public string ErrorMessage => "Password should not contain any non-digit and non-letter character";

        public NonSpecialCharactersRule(INonSpecialCharacters specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}