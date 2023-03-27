using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.UnitOfWork.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        Task<int> SaveAsync();
        int Save();
    }
}
