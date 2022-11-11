namespace Application.Features.Gatherings.GetGatheringById
{
    public class MembersItemResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}