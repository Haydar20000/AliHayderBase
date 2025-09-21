
using AliHayderBase.Web.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySchoolBackend.HelperFunctions.SeedConfiguration;

namespace AliHayderBase.Web.Persistence
{
    public class AliHayderDbContext(DbContextOptions<AliHayderDbContext> options) : IdentityDbContext<User, Role, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}