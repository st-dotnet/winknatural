using AutoMapper;
using WinkNatural.Services.DTO;
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
            CreateMap<ContactRequest, ContactModel>().ReverseMap();
            CreateMap<CustomerUpdateRequest, CustomerUpdateModel>().ReverseMap();
            CreateMap<CustomerValidationRequest, CustomerValidationModel>().ReverseMap();
            CreateMap<EnrollmentResponse, EnrollmentModel>().ReverseMap();
        }
    }
}
