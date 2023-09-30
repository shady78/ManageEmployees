using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployees.API.Dtos
{
    public class ContractDto
    {
            public int Id { get; set; }


            public string Name { get; set; }

            public DateTime StartDate { get; set; }


            public DateTime EndDate { get; set; }

            public int Amount { get; set; }

            public RecordStatus RecordStatus { get; set; }
            public string EmployeeName { get; set; } = string.Empty;
    }
}
