using System.Collections;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.Repository.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly StoreContext _context;
        #region get data form database
        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        #endregion

        #region save changes
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region dispose
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion

        #region get type generic

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
        #endregion
    }
}
