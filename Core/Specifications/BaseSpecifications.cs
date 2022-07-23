using System.Linq.Expressions;

namespace Core.Specifications;

public class BaseSpecifications<TEntity> : ISpecifications<TEntity>
{
    public BaseSpecifications()
    {
        
    }
    public BaseSpecifications(Expression<Func<TEntity,bool>> criteria)
    {
        Criteria = criteria;
        
    }
    public Expression<Func<TEntity,bool>> Criteria { get; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
    public Expression<Func<TEntity, object>> OrderBy { get; private set; } 
    public Expression<Func<TEntity, object>> OrderByDescending { get;private set; }

    public void AddInclude(Expression<Func<TEntity,object>> include)
    {
        Includes.Add(include);
    }
    public void AddOrderBy(Expression<Func<TEntity,object>> orderBy)
    {
        OrderBy = orderBy;
    }
    public void AddOrderByDescending(Expression<Func<TEntity,object>> orderByDescending)
    {
        OrderByDescending = orderByDescending;
    }
}