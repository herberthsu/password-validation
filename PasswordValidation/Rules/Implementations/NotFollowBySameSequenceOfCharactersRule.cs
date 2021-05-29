using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules.Implementations
{
    public class NotFollowBySameSequenceOfCharactersRule : INotFollowBySameSequenceOfCharactersRule
    {
        private readonly INotFollowBySameSequenceOfCharacters _specification;
        public string ErrorMessage => "Password should not contain any sequence of characters";
        public string ErrorType => "NotFollowBySameSequenceOfCharacters";

        public NotFollowBySameSequenceOfCharactersRule(INotFollowBySameSequenceOfCharacters specification)
        {
            _specification = specification;
        }
        
        public bool Validate(string entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}