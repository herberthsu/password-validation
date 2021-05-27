using System.Collections.Generic;
using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Rules
{
    public class Validator<TEntity> : IValidator<TEntity>
    {
        private readonly Dictionary<string, IRule<TEntity>> _rules;

        protected Validator()
        {
            _rules = new Dictionary<string, IRule<TEntity>>();
        }
        
        public ValidationResult Validate(TEntity entity)
        {
            var validation = new ValidationResult();
            foreach (var rule in _rules)
            {
                if (!rule.Value.Validate(entity))
                {
                    validation.SetError(new ValidationError(rule.Key, rule.Value.ErrorMessage));
                }
            }

            return validation;
        }
        
        protected void Add(string type, IRule<TEntity> rule) => _rules.Add(type, rule);
    }
}