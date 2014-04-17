using System.Linq;
using Solyanka.Domain.Core.WhereSpec;

namespace Solyanka.Domain.Core.Repositories
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : class;
        void SaveOrUpdate<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Query<TEntity>(Specification<TEntity> whereSpecification = null) where TEntity : class;
    }


}