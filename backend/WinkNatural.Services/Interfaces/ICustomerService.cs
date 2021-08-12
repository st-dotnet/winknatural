﻿using Exigo.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkNatural.Services.Interfaces
{
    public interface ICustomerService
    {
        //Get customer
        Task<GetCustomersResponse> GetCustomer(int customerId);
        Task<string> GetImage();

        Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request);
    }
}
