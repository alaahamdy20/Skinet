using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcure;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    private readonly IQueryable<TEntity> _query;

    public SpecificationEvaluator(IQueryable<TEntity> query)
    {
        _query = query;
    }

    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> queryable, ISpecifications<TEntity> specification)
    {
        var query = queryable;
        if (specification.Criteria != null)
            query = query.Where(specification.Criteria);
        
        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);
        
        if (specification.OrderByDescending != null)
            query = query.OrderByDescending(specification.OrderByDescending);

        if (specification.IsPagingEnabled)
            query = query.Skip(specification.Skip).Take(specification.Take);
        
        if (specification.Includes.Any())
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return query;
    }
}