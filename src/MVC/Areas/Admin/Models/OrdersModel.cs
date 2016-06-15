using Mvc.Code;

namespace Mvc.Areas.Admin.Models
{
    // ViewModel for members and their order information

    // ** Data Transfer Object (DTO) pattern

    public class OrdersModel
    {
        // sortable list of members

        public SortedList<MemberModel> Members { get; set; }
    }
}