﻿using System.Linq.Expressions;

namespace Core.Specifications;

public interface ISpecifications<TEntity> 
{
    Expression<Func<TEntity,bool>> Criteria { get; }
    List<Expression<Func<TEntity,object>>> Includes { get; }
}