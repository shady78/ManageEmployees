using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEmployees.API.Models.Entities
{
    public class Contract
    {
        [Key,Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.ContractName)]
        [StringLength(120)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public int Amount { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
