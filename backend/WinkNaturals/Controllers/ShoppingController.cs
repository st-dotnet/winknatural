using Microsoft.AspNetCore.Mvc;
using WinkNatural.Services.Interfaces;

namespace WinkNaturals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;
        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        /// <summary>
        /// Get item category
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetItemCategory")]
        public IActionResult GetItemCategory(int webCategoryID)
        {
            return Ok(_shoppingService.GetItemCategory(webCategoryID)); 
        }
    }
}
