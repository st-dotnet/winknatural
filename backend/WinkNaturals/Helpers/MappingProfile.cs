using AutoMapper;
using WinkNatural.Services.DTO.Customer;
using WinkNaturals.Models;

namespace WinkNaturals.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequest, CustomerSignInModel>().ReverseMap();
            CreateMap<CustomerCreateRequest, CustomerCreateModel>().ReverseMap();
        }
    }
}
