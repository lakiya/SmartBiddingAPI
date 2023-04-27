using Microsoft.EntityFrameworkCore;
using SmartBiddingDLL.Data;
using SmartBiddingDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL
{
    public class CommonRepository : ICommonRepository
    {
        protected readonly ApplicationDbContext _context;
        public CommonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add<T>(T entity) where T : class
        {
            var currentEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return currentEntity;
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _context.Set<T>().Where(expression);
        }

        public DbSet<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAll<T>(string[] includeTables) where T : class
        {
            var resultSet = _context.Set<T>().AsQueryable();
            foreach (string includeTable in includeTables)
            {
                resultSet = resultSet.Include(includeTable);
            }

            return resultSet.AsEnumerable();
        }

        public T GetById<T>(string id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public T Update<T>(T entity) where T : class
        {
            var currentEntity = _context.Set<T>().Update(entity).Entity;
            _context.SaveChanges();
            return currentEntity;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            _context.Set<T>().UpdateRange(entities);
            _context.SaveChanges();
        }
    }
}
