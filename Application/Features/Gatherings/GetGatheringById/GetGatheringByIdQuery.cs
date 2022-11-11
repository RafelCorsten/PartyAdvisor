using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Gatherings.GetGatheringById
{
    public class GetGatheringByIdQuery : IRequest<GetGatheringByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
