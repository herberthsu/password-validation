namespace PasswordValidation.Rules.Interfaces
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Validate(TEntity entity);
    }
}