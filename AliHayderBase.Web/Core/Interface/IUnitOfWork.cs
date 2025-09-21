using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliHayderBase.Web.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository User { get; }
        int Complete();
    }
}