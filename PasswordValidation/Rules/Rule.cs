using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Rules
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;
        
        public string ErrorMessage { get; }
        public string ErrorType { get; }

        public Rule(ISpecification<TEntity> spec, string errorMessage)
        {
            _specification = spec;
            ErrorMessage = errorMessage;
        }
        
        public bool Validate(TEntity entity)
        {
            return _specification.IsSatisfiedBy(entity);
        }
    }
}