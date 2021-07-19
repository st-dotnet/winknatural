using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WinkNatural.Services.DTO.Customer;
using WinkNatural.Services.Interfaces;
using WinkNaturals.Models;

namespace WinkNatural.Web.WinkNaturals.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticateService authenticate, IMapper mapper)
        {
            _authenticateService = authenticate;
            _mapper = mapper;
        }
        #region Customer

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateModel model)
        {
            var data = _mapper.Map<CustomerCreateRequest>(model);

            //Create customer in Exigo service
            await _authenticateService.CreateCustomer(data);
            //Generate token
            var tokenResult = await GetToken(new CustomerSignInModel
            {
                LoginName = model.LoginName,
                Password = model.LoginPassword
            });

            return Ok(new CustomerCreateResponse
            {
                Email = model.Email, LoginName = model.LoginName,Phone = model.Phone,Token = tokenResult.Token.ToString()
            });
        }

        /// <summary>
        /// Signin customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SignInCustomer")]
        public async Task<IActionResult> SignInCustomer(CustomerSignInModel model)
        {
            var data = _mapper.Map<LoginRequest>(model);
            //Signin customer in Exigo service
            var result = await _authenticateService.SignInCustomer(data);

            return Ok(result);
        }
        private async Task<CustomerCreateResponse> GetToken(CustomerSignInModel model)
        {
            var data = _mapper.Map<LoginRequest>(model);
            //Authenticate customer
            return await _authenticateService.SignInCustomer(data);
        }
        #endregion
    }
}
