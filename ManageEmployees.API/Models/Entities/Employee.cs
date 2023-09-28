using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEmployees.API.Models.Entities
{
    public class Employee
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.FirstName)]
        [StringLength(120)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = Errors.LastName)]
        [StringLength(120)]
        public string LastName { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public RecordStatus RecordStatus { get; set; }

        [Required]
        public JobPosition JobPosition { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Contract> Contracts { get; set;}
    }
}
