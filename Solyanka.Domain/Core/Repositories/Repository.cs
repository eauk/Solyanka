using System.Linq;
using Solyanka.Domain.Core.WhereSpec;

namespace Solyanka.Domain.Core.Repositories
{
    public class Repository : IRepository 
    {
        private readonly DataContext _context;
       
        public Repository(DataContext context)
        {
            this._context = context;
        }

       
        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void SaveOrUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Query<TEntity>(Specification<TEntity> whereSpecification = null) where TEntity : class
        {
            return GetQuery(whereSpecification);
        }


        IQueryable<TEntity> GetQuery<TEntity>(Specification<TEntity> whereSpecification) where TEntity : class
        {
            IQueryable<TEntity> dbSet = _context.Set<TEntity>();
            
            if (whereSpecification != null && whereSpecification.IsSatisfiedBy() != null)
                dbSet = dbSet.Where(whereSpecification.IsSatisfiedBy());


            return dbSet;
        }
    }
    
}