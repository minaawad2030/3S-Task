using AutoMapper;
using MediatR;
using Task01.Application.DTOs;
using Task01.Domain.Contracts.Services;
using Task01.Domain.Interfaces;

namespace Task01.Application.Lookups.Governorates.Query.GetAllGovernorates
{
    public class GetAllGovernateQueryHandler : IRequestHandler<GetAllGovernatesQuery, List<GovernorateSummary>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllGovernateQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GovernorateSummary>> Handle(GetAllGovernatesQuery request, CancellationToken cancellationToken)
        {
            var governates = await _unitOfWork.LookupRepository.GetGovernorates();
            List<GovernorateSummary> governateSummaries = new();
            foreach (var governate in governates)
            {
                governateSummaries.Add(_mapper.Map<GovernorateSummary>(governate));
            }
            return governateSummaries;
        }
    }
}
