using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Interfaces;
using MediatR;

namespace Application.Features.Gatherings.GetGatheringById
{
    public class GetGatheringByIdQueryHandler : IRequestHandler<GetGatheringByIdQuery, GetGatheringByIdResponse>
    {
        private readonly IRepository<Gathering> _repository;

        private readonly IMapper _mapper;

        public GetGatheringByIdQueryHandler(IRepository<Gathering> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<GetGatheringByIdResponse> Handle(
            GetGatheringByIdQuery request,
            CancellationToken cancellationToken)
        {
            var response = await this._repository.FindAsync(request.Id);
            return this._mapper.Map<Gathering, GetGatheringByIdResponse>(response);
        }
    }
}
