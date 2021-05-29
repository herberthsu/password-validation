using PasswordValidation.Rules.Interfaces;

namespace PasswordValidation.Rules
{
    public class PasswordValidator: Validator<string>
    {
        public PasswordValidator(IHasAtLeastOneDigitRule hasAtLeastOneDigitRule, 
            IHasAtLeastOneLetterRule hasAtLeastOneLetterRule,
            ILengthMinimumFiveMaximumTwelveRule lengthMinimumFiveMaximumTwelveRule,
            ILowercaseLettersOnlyRule lowercaseLettersOnlyRule,
            INonSpecialCharactersRule nonSpecialCharactersRule,
            INotFollowBySameSequenceOfCharactersRule notFollowBySameSequenceOfCharactersRule)
        {
            Add(hasAtLeastOneDigitRule);
            Add(hasAtLeastOneLetterRule);
            Add(lowercaseLettersOnlyRule);
            Add(lengthMinimumFiveMaximumTwelveRule);
            Add(nonSpecialCharactersRule);
            Add(notFollowBySameSequenceOfCharactersRule);
        }
    }
}