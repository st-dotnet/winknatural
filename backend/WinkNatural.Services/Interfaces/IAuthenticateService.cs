using Exigo.Api.Client;
using System.Threading.Tasks;
using WinkNatural.Services.DTO.Customer;

namespace WinkNatural.Services.Interfaces
{
    public interface IAuthenticateService
    {
        //create customer
        Task<CreateCustomerResponse> CreateCustomer(CustomerCreateRequest request);
        //Signin customer
        Task<string> SignInCustomer(LoginRequest request);
    }
}
