using AliHayderBase.Shared.Models;
using AliHayderBase.Web.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace AliHayderBase.Web.Persistence.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}