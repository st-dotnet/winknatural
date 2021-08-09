using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinkNatural.Services.Interfaces;
using WinkNaturals.Models;

namespace WinkNaturals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        /// <summary>
        /// Get packs data
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPacks")]
        public IActionResult GetPacks()
        {
            try
            {
                var items = _enrollmentService.GetItems();

                foreach (var item in items)
                {
                    item.ProductImage = _enrollmentService.GetProductImage(item.LargeImageUrl);
                }

                return Ok(items);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
