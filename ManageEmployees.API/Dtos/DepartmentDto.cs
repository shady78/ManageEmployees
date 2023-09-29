using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;

namespace ManageEmployees.API.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public List<string> EmployeeName {  get; set; }
    }
}
