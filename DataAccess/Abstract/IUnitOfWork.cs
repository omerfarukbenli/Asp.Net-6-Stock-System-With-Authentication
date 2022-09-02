using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task<int> SaveAsync();
    }
}
