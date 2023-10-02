using AutoMapper;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Dtos;
using ManageEmployees.API.Models.Entities;
using ManageEmployees.API.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ManageEmployees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ContractController(IMapper mapper, IContractRepository contractRepository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contracts = _contractRepository.FindAll(predicate: rs => rs.RecordStatus == RecordStatus.Active,
                include: x => x.Include(x => x.Employee));

            var contractDto = _mapper.Map<IEnumerable<ContractDto>>(contracts);
            return contracts is null ? NoContent() : Ok(contractDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contract = _contractRepository.Find(predicate: c => c.Id == id, include: c => c.Include(c => c.Employee));
            if (contract is null)
            {
                return NotFound();
            }
            var contractDto = _mapper.Map<ContractDto>(contract);
            return Ok(contractDto);
        }

        [HttpPost]
        public IActionResult Post(AddContract contractDto)
        {
            var contract = _mapper.Map<Models.Entities.Contract>(contractDto);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _contractRepository.Add(contract);
            _contractRepository.Commit();
            return Created($"/api/Contract/", contract);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AddContract contractDto)
        {
            var contract = _contractRepository.GetById(id);
            if (contract is null)
            {
                return NotFound();
            }
            contract = _mapper.Map(contractDto, contract);

            _contractRepository.Update(contract);
            _contractRepository.Commit();
            return Ok(contract);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contract = _contractRepository.GetById(id);
            if (contract is null)
            {
                return NotFound($"{id} is not found");
            }
            _contractRepository.Remove(contract);
            _contractRepository.Commit();
            return NoContent();
        }
    }
}
