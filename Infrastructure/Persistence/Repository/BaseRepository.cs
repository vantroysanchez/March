using Application.Common.Interfaces;
using Infrastructure.Persistence.Context;
using LinqKit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void DetacheEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "")
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
                query = query.AsExpandable().Where(where);

            return query;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] include)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
                query = query.AsExpandable().Where(where);

            return query;
        }

        public virtual IQueryable<T> Get(params Expression<Func<T, object>>[] include)
        {
            var query = _context.Set<T>().AsQueryable().AsExpandable();

            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public virtual IEnumerable<T> InsertRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual T Update(T entity, object id)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var attachedEntity = GetById(id);

                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            return entity;
        }

        public virtual void UpdateProperty<Type>(Expression<Func<T, Type>> property, T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).Property<Type>(property).IsModified = true;
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }


        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> primaryKeys)
        {
            var entity = Get(primaryKeys).FirstOrDefault();
            Delete(entity);
        }
        public virtual SqlDataReader Run(string query)
        {
            var connection = _context.Database.GetDbConnection();

            SqlConnection conn = new SqlConnection(connection.ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();

            return command.ExecuteReader();
        }
    }
}
