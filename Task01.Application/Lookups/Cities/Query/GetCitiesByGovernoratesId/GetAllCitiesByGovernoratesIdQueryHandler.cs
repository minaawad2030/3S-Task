using AutoMapper;
using MediatR;
using Task01.Application.DTOs;
using Task01.Domain.Interfaces;

namespace Task01.Application.Lookups.Cities.Query.GetCitiesByGovernoratesId
{
    public class GetAllCitiesByGovernoratesIdQueryHandler : IRequestHandler<GetAllCitiesByGovernoratesIdQuery, List<CitySummary>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllCitiesByGovernoratesIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<CitySummary>> Handle(GetAllCitiesByGovernoratesIdQuery request, CancellationToken cancellationToken)
        {
            var cities=await unitOfWork.LookupRepository.GetCities(request.GovernorateId);
            List<CitySummary> citySummaries = new List<CitySummary>();

            foreach(var city in cities) 
            {
                citySummaries.Add(mapper.Map<CitySummary>(city));
            }

            return citySummaries;
        }
    }
}
