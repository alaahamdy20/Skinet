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

    public async Task<TEntity> GetBySpecificationAsync(ISpecifications<TEntity> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllBySpecificationAsync(ISpecifications<TEntity> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecifications<TEntity> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    private  IQueryable<TEntity> ApplySpecification(ISpecifications<TEntity> spec)
    {
        return  SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
    }
}