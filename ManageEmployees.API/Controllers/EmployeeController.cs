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
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IContractRepository contractRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _contractRepository = contractRepository;
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, AddEmployee employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            employee = _mapper.Map(employeeDto, employee);

            _employeeRepository.Update(employee);
            _employeeRepository.Commit();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }

            _employeeRepository.Remove(employee);
            _employeeRepository.Commit();
            return NoContent();

        }
    }
}
