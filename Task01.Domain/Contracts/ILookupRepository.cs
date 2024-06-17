using System.Threading.Tasks;
using Task01.Domain.Lookups;

namespace Task01.Domain.Interfaces
{
    public interface ILookupRepository
    {
        Task<List<Governorate>> GetGovernorates();
        Task<List<City>> GetCities(int governateId);
    }
}
