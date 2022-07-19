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
    
    public void AddInclude(Expression<Func<TEntity,object>> include)
    {
        Includes.Add(include);
    }
}