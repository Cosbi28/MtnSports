using Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MtnSportsAppContext _mtnSportsAppContext{ get; set; }

        public RepositoryBase(MtnSportsAppContext mtnSportsAppContext)
        {
            _mtnSportsAppContext = mtnSportsAppContext;
        }

        public IQueryable<T> FindAll()
        {
            return _mtnSportsAppContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _mtnSportsAppContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _mtnSportsAppContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _mtnSportsAppContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _mtnSportsAppContext.Set<T>().Remove(entity);
        }
    }
}