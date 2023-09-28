using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageEmployees.API.Models.Entities
{
    public class Department
    {
        [Key , Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.DepartmentNameRequired)]
        [StringLength(120)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = Errors.DepartmentDescriptionRequired)]
        [JsonProperty ("description")]
        public string Description { get; set; }

        public RecordStatus RecordStatus { get; set; }

        public ICollection<Employee> Employees { get; set;}
    }
}
