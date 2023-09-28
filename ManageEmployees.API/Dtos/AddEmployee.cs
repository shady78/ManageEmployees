using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployees.API.Dtos
{
    public class AddEmployee
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

 
        public DateTime BirthDate { get; set; }

        public RecordStatus RecordStatus { get; set; }

        
        public JobPosition JobPosition { get; set; }

        //public string Department { get; set; }

    }
}
