using Domain.Common;

namespace Domain.Entities
{
    public class Member : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public ICollection<Gathering> Gatherings { get; private set; }

        public Member()
        {
        }

        public Member(Guid id, string firstName, string lastName, string email, bool isDeleted = false)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsDeleted = isDeleted;
            Gatherings = new List<Gathering>();
        }

        public void AddGatherings(Gathering gathering)
        {
            this.Gatherings.Add(gathering);
        }
    }
}
