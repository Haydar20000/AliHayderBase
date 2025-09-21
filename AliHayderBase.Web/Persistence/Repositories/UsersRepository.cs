using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliHayderBase.Web.Core.Domain;
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