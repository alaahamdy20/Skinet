using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{ 
    Task<TEntity> GetByIdAsync(int id);
    Task<IReadOnlyList<TEntity>> ListAllAsync();
    Task<TEntity> GetBySpecificationAsync(ISpecifications<TEntity> spec);
    Task<IReadOnlyList<TEntity>> GetAllBySpecificationAsync(ISpecifications<TEntity> spec);
    Task<int> CountAsync(ISpecifications<TEntity> spec);
}