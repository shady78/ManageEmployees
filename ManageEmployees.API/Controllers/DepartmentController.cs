using AutoMapper;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Dtos;
using ManageEmployees.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ManageEmployees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentRepository.FindAll(predicate: rs => rs.RecordStatus == Models.Enums.RecordStatus.Active,
                include: x => x.Include(x => x.Employees));

            if (departments is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DepartmentDto>>(departments));
            //return departments.Any() ? Ok(_mapper.Map<DepartmentDto>(departments)) : NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = _departmentRepository
                .Find(predicate: p => p.Id == id, include: x => x.Include(x => x.Employees));

            if (department is null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        // All the employees for this department
        [HttpGet("{id}/employees")]
        public IActionResult GetDepartmentEmployees(int id)
        {
            var departmentEmployees = _employeeRepository.FindAll(predicate: d => d.DepartmentId == id,
                d => d.Include(c => c.Contracts));
            if (departmentEmployees is null)
            {
                return NotFound();
            }
            return Ok(departmentEmployees);
        }

        [HttpPost]
        public IActionResult Post(AddDepartment departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = _mapper.Map<Department>(departmentDto);

            if (department == null) { NotFound(); }

            _departmentRepository.Add(department!);
            _departmentRepository.Commit();

            return Created($"/api/Department/", department);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id , AddDepartment departmentDto)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return NotFound();
            }
            department = _mapper.Map(departmentDto, department);
            _departmentRepository.Update(department);
            _departmentRepository.Commit();
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return NotFound();
            }
            _departmentRepository.Remove(department);
            _departmentRepository.Commit();
            return NoContent();
        }
    }
}
