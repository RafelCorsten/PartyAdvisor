using Domain.Entities;

namespace Application.Features.Gatherings.GetGatheringById
{
    public class GetGatheringByIdResponse
    {
        public IEnumerable<GetGatheringByIdItemResponse> Gatherings { get; set; }
    }
}