using NHibernate.Criterion;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UoW.Core.Core
{
    public interface IRepository<T>
    {
        void Save(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        T GetById(int Id);
        IQueryable<T> Getall(Expression<Func<T, object>> expression);
    }
}
