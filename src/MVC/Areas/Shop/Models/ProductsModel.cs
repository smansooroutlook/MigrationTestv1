using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Code;

namespace Mvc.Areas.Shop.Models
{
    // list of products ViewModel

    // ** Data Transfer Object (DTO) pattern

    public class ProductsModel
    {
        public SelectList Categories { get; set; }

        // sortable list of products

        public SortedList<ProductModel> Products { get; set; }
    }
}