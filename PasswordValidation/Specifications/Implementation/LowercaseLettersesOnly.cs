using System.Linq;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class LowercaseLettersOnly : ILowercaseLettersOnly
    {
        public bool IsSatisfiedBy(string entity)
        {
            return !entity.Any(char.IsUpper);
        }
    }
}