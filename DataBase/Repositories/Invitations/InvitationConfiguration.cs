using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Repositories.Invitations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable(nameof(Invitation));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MemberId);
            builder.Property(x => x.GatheringId);
            builder.Property(x => x.Status);

            // QueryFilters
            builder.HasQueryFilter(x => !x.IsDeleted);

            // RelationShips
            builder.HasOne(x => x.Gathering).WithMany()
                .HasForeignKey(x => x.GatheringId);
            builder.HasOne(x => x.Member).WithMany()
                .HasForeignKey(x => x.GatheringId);
        }
    }
}
