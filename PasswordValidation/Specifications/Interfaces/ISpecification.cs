namespace PasswordValidation.Specifications.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}