namespace PasswordValidation.Rules.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}