using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
            var createCustomerRequest = _mapper.Map<CustomerCreateRequest>(model);

            //Create customer in Exigo service
            await _authenticateService.CreateCustomer(createCustomerRequest);

            //Get Jwt token
            var tokenRequest = _mapper.Map<LoginRequest>(model);

            //Authenticate customer
            var result= await _authenticateService.SignInCustomer(tokenRequest);

            return Ok(new CustomerCreateResponse
            {
                Email = model.Email, LoginName = model.LoginName, Phone = model.Phone, Token = result.Token.ToString()
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
            var signinRequest = _mapper.Map<LoginRequest>(model);

            //Signin customer in Exigo service
            return Ok(await _authenticateService.SignInCustomer(signinRequest));
        }

        /// <summary>
        /// Send forgot password email
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SendForgotPasswordEmail")]
        public async Task<IActionResult> SendForgotPasswordEmail(CustomerUpdateModel model)
        {
            var customerEmailRequest = _mapper.Map<CustomerUpdateRequest>(model);

            //Send email with Exigo service
            return Ok(await _authenticateService.SendForgotPasswordEmail(customerEmailRequest));
        }

        /// <summary>
        /// Update customer password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateModel model)
        {
            var customerUpdateRequest = _mapper.Map<CustomerUpdateRequest>(model);

            //Update customer password with Exigo service
            return Ok(await _authenticateService.UpdateCustomerPassword(customerUpdateRequest));
        }

        /// <summary>
        /// Validate customer email/username
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ValidateCustomer")]
        public async Task<IActionResult> ValidateCustomer(CustomerValidationModel model)
        {
            var customerValidationRequest = _mapper.Map<CustomerValidationRequest>(model);

            //Validate username/email with Exigo service
            return Ok(await _authenticateService.IsEmailOrUsernameExists(customerValidationRequest));
        }

        #endregion
    }
}
