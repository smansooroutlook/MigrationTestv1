using System.Collections.Generic;

namespace Mvc.Areas.Admin.Models
{
    // list of order details ViewModel

    // ** Data Transfer Object (DTO) pattern


    public class OrderDetailsModel
    {
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}