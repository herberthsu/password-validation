using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class LengthMinimumFiveMaximumTwelve : ILengthMinimumFiveMaximumTwelve
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.Length >= 5 && entity.Length <= 12;
        }
    }
}