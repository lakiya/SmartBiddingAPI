using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBiddingDLL.Interfaces
{
    public interface ICommonRepository
    {
        T GetById<T>(string id) where T : class;
        DbSet<T> GetAll<T>() where T : class;
        public IEnumerable<T> GetAll<T>(string[] includeTables) where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class;
        T Add<T>(T entity) where T : class;
        void AddRange<T>(IEnumerable<T> entities) where T : class;
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        T Update<T>(T entity) where T : class;
    }
}
