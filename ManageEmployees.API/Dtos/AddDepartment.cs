using ManageEmployees.API.Data.Consts;
using ManageEmployees.API.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ManageEmployees.API.Dtos
{
    public class AddDepartment
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}
