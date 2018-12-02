using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api.Models.Database;
using WebScanner_api.Models.Repositories;

namespace WebScanner_api.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private DatabaseContext _databaseContext;
        private ResponseRepository _responseRepository;
        private bool disposed = false;
        #endregion
        #region Constructors
        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion
        #region Properties

        public ResponseRepository ResponseRepository
        {
            get
            {
                if (this._responseRepository == null)
                {
                    this._responseRepository = new ResponseRepository(this._databaseContext);
                }

                return this._responseRepository;
            }
        }
        #endregion
        #region Methods
        public async Task Save() => await this._databaseContext.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
