using MediatR;
using Task01.Application.DTOs;

namespace Task01.Application.Lookups.Governorates.Query.GetAllGovernorates
{
    public class GetAllGovernatesQuery : IRequest<List<GovernorateSummary>>
    {
    }
}
