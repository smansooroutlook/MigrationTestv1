using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Code;

namespace Mvc.Areas.Shop.Models
{

    // search page ViewModel

    // ** Data Transfer Object (DTO) pattern

    public class SearchModel
    {
        public string ProductName { get; set; }
        public SelectList PriceRanges { get; set; }

        // sortable list of products

        public SortedList<ProductModel> Products { get; set; }
    }
}