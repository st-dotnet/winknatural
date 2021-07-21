﻿using Exigo.Api.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinkNatural.Services.Interfaces;

namespace WinkNatural.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ExigoApiClient exigoApiClient = new("WinkNaturals", "API_Web", "PB45DY5J5pmq9anE");
        private readonly IConfiguration _config;

        public CustomerService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<GetCustomersResponse> GetCustomer(int customerId)
        {
            try
            {
                return await exigoApiClient.GetCustomersAsync(new GetCustomersRequest { CustomerID = customerId });
            }
            catch (Exception ex)
            {
                //handle exception
                return null;
            }
        }
    }
}