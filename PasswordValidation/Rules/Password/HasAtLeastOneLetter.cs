using System.Linq;
using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Rules.Password
{
    public class HasAtLeastOneLetter : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.Any(char.IsLetter);
        }
    }
}