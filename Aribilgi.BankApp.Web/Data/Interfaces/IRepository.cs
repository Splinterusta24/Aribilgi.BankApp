using Aribilgi.BankApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aribilgi.BankApp.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        bool Any(Expression<Func<T, bool>> predicate);
      

    }
}
