namespace PasswordValidation.Rules.Interfaces
{
    public interface IValidator<TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}