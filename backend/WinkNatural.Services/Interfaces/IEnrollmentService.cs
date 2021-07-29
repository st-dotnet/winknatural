using Exigo.Api.Client;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WinkNatural.Services.DTO;

namespace WinkNatural.Services.Interfaces
{
    public interface IEnrollmentService
    {
        //Get packs data
        List<EnrollmentResponse> GetItems();

        //Get product images
        FileContentResult GetProductImage(string imageName);

    }
}
