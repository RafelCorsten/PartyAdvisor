using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Repositories.Members
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable(nameof(Member));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(60).IsRequired();

            // QueryFilters
            builder.HasQueryFilter(x => !x.IsDeleted);

            // RelationShips
            builder.HasMany<Gathering>(x => x.Gatherings)
                   .WithMany(x => x.Members);
        }
    }
}
