using Microsoft.AspNetCore.Mvc;
using WinkNatural.Services.Interfaces;
using WinkNatural.Services.Utilities;

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
        [HttpGet("GetItemCategory/{webCategoryID:int}")]
        public IActionResult GetItemCategory(int webCategoryID)
        {
            return Ok(_shoppingService.GetItemCategory(webCategoryID)); 
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList(int CategoryID)
        {
            return Ok(_shoppingService.GetShopProducts(CategoryID));
        }
    }
}
