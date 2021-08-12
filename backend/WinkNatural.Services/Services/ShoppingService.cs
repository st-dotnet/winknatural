using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WinkNatural.Services.DTO.Shopping;
using WinkNatural.Services.Interfaces;

namespace WinkNatural.Services.Services
{
    public class ShoppingService : IShoppingService
    {
        public List<ItemCategoryResponse> GetItemCategory(int webCategoryID)
        { 
            webCategoryID = webCategoryID == 0 ? 1 : webCategoryID; 
            var categories = new List<ItemCategoryResponse>();

            using (var context = Common.Utils.DbConnection.Sql())
            {
                var data = context.Query<ItemCategoryResponse>(@"
			        ;WITH webcat (WebCategoryID, WebCategoryDescription, ParentID, NestedLevel, SortOrder) 
				         AS (SELECT WebCategoryID, 
							        WebCategoryDescription, 
							        ParentID = COALESCE(ParentID, 0), 
							        NestedLevel,
                                    SortOrder
					         FROM   WebCategories 
					         WHERE  WebCategoryID = @webcategoryid
							        AND WebID = @webid 
					         UNION ALL 
					         SELECT w.WebCategoryID, 
							        w.WebCategoryDescription, 
							        w.ParentID, 
							        w.NestedLevel,
                                    w.SortOrder
					         FROM   WebCategories w 
							        INNER JOIN webcat c 
									        ON c.WebCategoryID = w.ParentID) 
			        SELECT * 
			        FROM   webcat 
		        ", new
                {
                    webid = 1,
                    webcategoryid = webCategoryID
                }).ToList();

                categories = GetWebCategoriesRecursively(categories, data, webCategoryID);
            }

            return categories.OrderBy(c => c.SortOrder).ToList();
        } 

        public ShopProductsResponse GetShopProducts()
        {
            throw new NotImplementedException();
        }

        #region Private methods

        private static List<ItemCategoryResponse> GetWebCategoriesRecursively(List<ItemCategoryResponse> categories, List<ItemCategoryResponse> data, int parentID)
        {
            foreach (var category in data.Where(c => c.ParentID == parentID))
            {
                categories.Add(category);
                if (data.Count(c => c.ParentID == category.WebCategoryID) > 0)
                {
                    GetWebCategoriesRecursively(category.Subcategories, data, category.WebCategoryID);
                }
            }

            return categories.OrderBy(c => c.SortOrder).ToList();
        }

        #endregion
    }
}
