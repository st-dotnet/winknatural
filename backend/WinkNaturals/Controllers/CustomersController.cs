using Exigo.Api.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExigoResourceSet.Providers.Resource;
using System.Globalization;
using System.IO; 
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Resources;

namespace WinkNaturals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ExigoApiClient exigoApiClient = new("WinkNaturals", "API_Web", "PB45DY5J5pmq9anE");
        private readonly IWebHostEnvironment _env;

        public CustomersController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var aa = Common.Home_1;
            var aab = DbResourceProvider.GetResourceValue(new CultureInfo("en-US").ToString(), "Home_1");
            //GetResourceSetItemsRequest req = new GetResourceSetItemsRequest { SubscriptionKey= "CommonWeb", Version="2021.7.20.2",CultureCode= new CultureInfo("en-US").ToString() };
            //Create Request 
           // var req = new GetResourceSetsRequest();

            //Send Request to Server and Get Response 
           // var res = await exigoApiClient.GetResourceSetsAsync(req);

            //Create Request
            //var req3 = new GetResourceSetsRequest { ResourceSetID=1};

            //Send Request to Server and Get Response
            //var res3 = await exigoApiClient.GetResourceSetsAsync(req3);

            //Create Request 
            //var req1 = new GetResourceSetItemsRequest {  SubscriptionKey = "CommonWeb",
            //    Version = "2021.7.20.5",
            //    CultureCode="en-US"
           // }; 

            //Send Request to Server and Get Response 
            //var res1 = await exigoApiClient.GetResourceSetItemsAsync(req1);
            //Implementation pending
            return null;
        }

    }
}
