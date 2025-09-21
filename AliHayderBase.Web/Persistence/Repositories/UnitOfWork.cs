


using AliHayderBase.Web.Core.Interface;

namespace AliHayderBase.Web.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AliHayderDbContext _context;
        public IUsersRepository User { get; private set; }

        public UnitOfWork(AliHayderDbContext context)
        {
            _context = context;
            User = new UsersRepository(_context);
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