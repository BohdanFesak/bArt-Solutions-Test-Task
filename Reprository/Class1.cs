using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reprository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);

        TEntity FindById(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity item);

        void Remove(TEntity item);
    }
    public class EFGenercRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenercRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
    public class GenericUnitOfWork : IDisposable
    {
        DbContext context;

        public GenericUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new EFGenercRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
