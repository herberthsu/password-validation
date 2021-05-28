using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class LengthMinimumFiveMaximumTwelve : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.Length >= 5 && entity.Length <= 12;
        }
    }
}