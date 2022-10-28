using System.Net.Mime;
using System.Reflection;
using DataBase.Repositories.Gatherings;
using DataBase.Repositories.Invitations;
using DataBase.Repositories.Members;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataBase.Contexts
{
    public class PartyDbContext : DbContext
    {
        public PartyDbContext(DbContextOptions<PartyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Gathering> Gatherings { get; set; }

        public DbSet<Invitation> Invations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MemberConfiguration());
            builder.ApplyConfiguration(new GatheringConfiguration());
            builder.ApplyConfiguration(new InvitationConfiguration());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.AuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AuditEntities()
        {
            var currentDate = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(Entity.CreatedOn)).CurrentValue = currentDate;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(Entity.UpdatedOn)).CurrentValue = currentDate;
                }
            }
        }
    }

    public class PartyDbContextFactory : IDesignTimeDbContextFactory<PartyDbContext>
    {
        public PartyDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath()
                .AddJsonFile("appsettings.json")
                .Build();
            var optionBuilder = new DbContextOptionsBuilder<PartyDbContext>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new PartyDbContext(optionBuilder.Options);
        }
    }
}
