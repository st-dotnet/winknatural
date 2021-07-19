using Exigo.Api.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WinkNatural.Common.Utils.Enum;
using WinkNatural.Services.DTO.Customer;
using WinkNatural.Services.Interfaces;

namespace WinkNatural.Services.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ExigoApiClient exigoApiClient = new("WinkNaturals", "API_Web", "PB45DY5J5pmq9anE");
        private readonly IConfiguration _config;
        private readonly ICustomerService _customerService;

        #region constructor

        public AuthenticateService(IConfiguration config, ICustomerService customerService)
        {
            _config = config;
            _customerService = customerService;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateCustomerResponse> CreateCustomer(CustomerCreateRequest request)
        {
            try
            { 
            var customerCreateRequest = new CreateCustomerRequest
            {
                InsertEnrollerTree = true,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                MobilePhone = request.MobilePhone,
                Email = request.Email,
                CanLogin = true,
                LoginName = request.LoginName,
                LoginPassword = request.LoginPassword,
                CustomerType = (int)CustomerTypeEnum.RetailCustomer,
                CustomerStatus = (int)CustomerStatuses.Active,
                EntryDate = GetCSTSateTime(),
                DefaultWarehouseID = 1,
                CurrencyCode = "usd",
                EnrollerID = request.EnrollerID == 0 ? 2 : request.EnrollerID,
                LanguageID = 0,
                MainCountry = "US",
                BirthDate=request.BirthDate
            };

            return await exigoApiClient.CreateCustomerAsync(customerCreateRequest);
            }
            catch (Exception ex)
            {
                //handle exception
                return null;
            }
        }

        /// <summary>
        /// Signin customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CustomerCreateResponse> SignInCustomer(LoginRequest request)
        {
            try
            {
                //Exigo service login request
                var authenticateRequest = new AuthenticateCustomerRequest
                {
                    LoginName = request.LoginName,
                    Password = request.Password
                };

                var result = await exigoApiClient.AuthenticateCustomerAsync(authenticateRequest);
                if (result.CustomerID == 0)
                {
                    return new CustomerCreateResponse { ErrorMessage = "User is not authenticated." };
                }

                // Get customer
                var customer = await _customerService.GetCustomer(result.CustomerID);

                var token = GenerateJwtToken(result);
                return new CustomerCreateResponse
                {
                    Email = customer.Customers[0].Email,
                    LoginName = customer.Customers[0].LoginName,
                    Phone = customer.Customers[0].Phone,
                    Token = token.ToString()
                };
            }
            catch (Exception ex)
            {
                //handle exception
                return null;
            }
        }

        #endregion

        #region private methods

        private static DateTime GetCSTSateTime()
        {
            DateTime datetimeNow = DateTime.Now;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTime(datetimeNow, cstZone);
        }

        private string GenerateJwtToken(AuthenticateCustomerResponse customer)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("customerId", customer.CustomerID.ToString()),
                    new Claim("firstName", customer.FirstName.ToString()),
                    new Claim("lastName", customer.LastName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
