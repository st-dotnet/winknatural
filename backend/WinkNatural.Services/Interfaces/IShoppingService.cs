using System.Collections.Generic;
using WinkNatural.Services.DTO.Shopping;

namespace WinkNatural.Services.Interfaces
{
    public interface IShoppingService
    {
        //Get shop products list
        ShopProductsResponse GetShopProducts();

        //Get item category
        List<ItemCategoryResponse> GetItemCategory(int webCategoryID);
    }
}
