using AutoMapper;
using ManageEmployees.API.Data;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Dtos;
using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IContractRepository contractRepository, ApplicationDbContext context, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _contractRepository = contractRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeRepository.GetAll();

            if (employees.Any())
            {
                return Ok(employees);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeRepository.GetById(id);

            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpGet("{id}/contracts")]
        public IActionResult GetEmployeeContracts(int id)
        {
            var employeeContracts = _contractRepository.GetAll().Where(p => p.EmployeeId == id).Where(rs => rs.RecordStatus == RecordStatus.Active);

            return employeeContracts is null ? NotFound() : Ok(employeeContracts);

        }
        [HttpPost]
        public IActionResult Post(AddEmployee employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = _mapper.Map<Employee>(employeeDto);

            if (employee == null) throw new ArgumentNullException(nameof(employee));

            _employeeRepository.Add(employee);
            _employeeRepository.Commit();

            return Created($"/api/Employee/", employee);
        }


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Employee employee)
        //{
        //    try
        //    {
        //        var _employee = _employeeRepository.GetSingle(id);

        //        if (_employee == null)
        //            throw new ArgumentNullException(nameof(_employee));

        //        _employee.FirstName = employee.FirstName;
        //        _employee.LastName = employee.LastName;
        //        _employee.BirthDate = employee.BirthDate;
        //        _employee.JobPosition = employee.JobPosition;
        //        _employee.RecordStatus = employee.RecordStatus;

        //        if (_departmentRepository.GetSingle(employee.DepartmentId) == null)
        //            throw new ArgumentNullException($"No departments exist with ID you have selected.");

        //        _employee.DepartmentId = employee.DepartmentId;
        //        _employeeRepository.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    Employee employee = _employeeRepository.GetSingle(id);

        //    if (employee == null) return NotFound();

        //    var employeeContracts = _contractRepository.FindBy(a => a.EmployeeId == id);

        //    foreach (var contract in employeeContracts)
        //        _contractRepository.Delete(contract);

        //    _employeeRepository.Delete(employee);
        //    _employeeRepository.Commit();

        //    return new NoContentResult();
        //}
    }
}
