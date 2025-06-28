using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITenantDbContextFactory _contextFactory;
        private BisiyonAppContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
        private bool _disposed = false;

        public UnitOfWork(ITenantDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _context = _contextFactory.CreateDbContext();
        }

        public IRepositoryBase<T> Repository<T>() where T : class, IEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IRepositoryBase<T>)_repositories[typeof(T)];

            var repositoryInstance = new RepositoryBase<T>(_context);
            _repositories.Add(typeof(T), repositoryInstance);
            return repositoryInstance;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}