using Domain.Enums;

namespace Application.Features.Gatherings.GetGatheringById
{
    public class GetGatheringByIdResponse
    {
        public Guid Id { get; set; }

        public MembersItemResponse Creator { get; set; }

        public GatheringTypeEnum Type { get; set; }

        public DateTime ScheduledAt { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}