using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrasturcure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly StoreContext _context;

    public GenericRepository(StoreContext context)
    {
        _context = context;
    }
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> ListAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public Task<TEntity> GetBySpecificationAsync(ISpecifications<TEntity> spec)
    {
        return ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllBySpecificationAsync(ISpecifications<TEntity> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
    private  IQueryable<TEntity> ApplySpecification(ISpecifications<TEntity> spec)
    {
        return  SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
    }
}