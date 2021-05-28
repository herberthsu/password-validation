﻿using System.Linq;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation.Specifications.Implementation
{
    public class HasAtLeastOneLetter : ISpecification<string>
    {
        public bool IsSatisfiedBy(string entity)
        {
            return entity.Any(char.IsLetter);
        }
    }
}