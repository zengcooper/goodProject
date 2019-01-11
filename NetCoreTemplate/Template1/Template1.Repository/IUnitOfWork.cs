using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template1.Repository
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }
}
