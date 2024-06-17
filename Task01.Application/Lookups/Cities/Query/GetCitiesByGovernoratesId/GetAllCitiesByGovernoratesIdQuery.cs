using MediatR;
using Task01.Application.DTOs;

namespace Task01.Application.Lookups.Cities.Query.GetCitiesByGovernoratesId
{
    public class GetAllCitiesByGovernoratesIdQuery:IRequest<List<CitySummary>>
    {
        public GetAllCitiesByGovernoratesIdQuery(int governorateId)
        {
            GovernorateId=governorateId;
        }
        public int GovernorateId { get; }
    }
}
