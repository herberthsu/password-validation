namespace PasswordValidation.Rules.Interfaces
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }
        string ErrorType { get; }
        bool Validate(TEntity entity);
    }
}