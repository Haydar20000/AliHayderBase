using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Web.Core.Interface;

namespace AliHayderBase.Web.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
         private readonly AliHayderDbContext _context;

         public UnitOfWork(AliHayderDbContext context)
         {
             _context = context;
         }
           public int Complete()
        {
            return _context.SaveChanges();
        }

       public void Dispose()
{
    _context.Dispose();
}
    }
}