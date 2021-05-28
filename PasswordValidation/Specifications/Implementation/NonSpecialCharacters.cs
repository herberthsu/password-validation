using System.Linq;
using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class NonSpecialCharacters : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.All(char.IsLetterOrDigit);
        }
    }
}