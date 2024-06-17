using AutoMapper;
using Task01.Application.DTOs;
using Task01.Application.Users.Commands.Create;
using Task01.Application.Users.DTOs;
using Task01.Domain.Entities.Users;
using Task01.Domain.Lookups;

namespace Task01.API.AutoMapperProfiles
{
    public class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<CreateUserCommand, User>();
                CreateMap<Governorate, GovernorateSummary>();
                CreateMap<City, CitySummary>();
                CreateMap<AddressDto, Address>();
            }
        }
    }
}
