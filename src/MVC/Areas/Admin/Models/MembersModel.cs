using Mvc.Code;

namespace Mvc.Areas.Admin.Models
{
    // members ViewModel

    // ** Data Transfer Object (DTO) pattern

    public class MembersModel
    {
        public string Message { get; set; }

        // sortable list of members

        public SortedList<MemberModel> Members { get; set; }
    }
}