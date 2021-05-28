﻿using System.Linq;
using PasswordValidation.Specifications.Interfaces;

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