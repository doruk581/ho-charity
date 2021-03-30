using Ho.Charity.Core;
using Microsoft.EntityFrameworkCore;

namespace Ho.Charity.Persistence
{
    public class CharityOrganizationDbContext : DbContext
    {
        public CharityOrganizationDbContext(DbContextOptions<CharityOrganizationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<CharityOrganization> CharityOrganizations { get; set; }
    }
}