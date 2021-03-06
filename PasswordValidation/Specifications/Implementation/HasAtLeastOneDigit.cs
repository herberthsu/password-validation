using System.Linq;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class HasAtLeastOneDigit : IHasAtLeastOneDigit
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.Any(char.IsDigit);
        }
    }
}