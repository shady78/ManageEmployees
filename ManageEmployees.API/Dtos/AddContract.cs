using ManageEmployees.API.Models.Enums;

namespace ManageEmployees.API.Dtos
{
    public class AddContract
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Amount { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}
