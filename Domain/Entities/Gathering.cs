using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Gathering : Entity
    {

        public Member Creator { get; private set; }

        public Guid CreatorId { get; private set; }

        public GatheringTypeEnum Type { get; private set; }

        public DateTime ScheduledAt { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public ICollection<Member> Members { get; private set; }

        public Gathering()
        {
        }

        public Gathering(Guid id, Member creator, GatheringTypeEnum type, DateTime scheduledAt, string name, string location
            , bool isDeleted = false)
        {
            Id = id;
            Creator = creator;
            Type = type;
            ScheduledAt = scheduledAt;
            Name = name;
            Location = location;
            Members = new List<Member>();
        }

        public void AddMembers(Member member)
        {
            this.Members.Add(member);
        }
    }
}