using System.Collections.Generic;
using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Rules
{
    public class Validator<TEntity> : IValidator<TEntity>
    {
        private readonly List<IRule<TEntity>> _rules;

        protected Validator()
        {
            _rules = new List<IRule<TEntity>>();
        }
        
        public ValidationResult Validate(TEntity entity)
        {
            var validation = new ValidationResult();
            foreach (var rule in _rules)
            {
                if (!rule.Validate(entity))
                {
                    validation.SetError(new ValidationError(rule.ErrorType, rule.ErrorMessage));
                }
            }

            return validation;
        }
        
        protected void Add(IRule<TEntity> rule) => _rules.Add(rule);
    }
}