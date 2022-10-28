using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Repositories.Gatherings
{
    public class GatheringConfiguration : IEntityTypeConfiguration<Gathering>
    {
        public void Configure(EntityTypeBuilder<Gathering> builder)
        {
            builder.ToTable(nameof(Gathering));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
            builder.Property(x => x.ScheduledAt);
            builder.Property(x => x.Name);
            builder.Property(x => x.Location);

            // QueryFilters
            builder.HasQueryFilter(x => !x.IsDeleted);

            // RelationShips
            builder.HasOne(x => x.Creator).WithMany()
                .HasForeignKey(x => x.CreatorId);
        }
    }
}
