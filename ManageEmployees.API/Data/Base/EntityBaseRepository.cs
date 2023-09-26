using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;

namespace ManageEmployees.API.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _context;

        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.AsQueryable();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
        int Id;
        public T GetSingle(int id)
        {
            return _context.Set<T>().Find(id)!;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate)!;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.Where(predicate).FirstOrDefault()!;
        }


        //public void SetStatusActive(T entity)
        //{
        //    entity.RecordStatus = RecordStatus.Active;
        //}

        //public void SetStatusArchived(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetStatusDeleted(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetStatusPending(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
