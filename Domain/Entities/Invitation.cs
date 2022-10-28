using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Invitation : Entity
    {
        public Guid MemberId { get; private set; }

        public Member Member { get; private set; }

        public Guid GatheringId { get; private set; }

        public Gathering Gathering { get; private set; }

        public InvitationStatusEnum Status { get; private set; }

        public Invitation()
        {
        }

        public Invitation(Guid id, Guid memberId, Guid gatheringId, bool IsDeleted = false)
        {
            Id = id;
            MemberId = memberId;
            GatheringId = gatheringId;
        }
    }
}
