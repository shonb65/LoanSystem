namespace LoanSystem.Repository;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(Guid id, T updatedEntity);
    Task DeleteAsync(Guid id);
}