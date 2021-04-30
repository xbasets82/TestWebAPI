using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RedArbor.Process.Interfaces;

namespace RedArbor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class redarborController : ControllerBase
    {
        private readonly ILogger<redarborController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeProcess _employeeProcess;

        public redarborController(ILogger<redarborController> logger, IMapper mapper, IEmployeeProcess employeeProcess)
        {
            _logger = logger;
            _mapper = mapper;
            _employeeProcess = employeeProcess;
        }

        /// <summary>Get all employee items</summary>
        /// <returns>Array of Employee items</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Models.Employee>> GetAllEmployees()
        {
            try
            {
                return _mapper.Map<List<Models.Employee>>(_employeeProcess.GetAll().ToList());       
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, Constants.Errors.GETALLEMPLOYEESERROR);                  
            }
        }

        /// <summary>Get Employee By ID</summary>
        /// <param name="id"></param>
        /// <returns>Employee item</returns>
        [HttpGet("{id:int}")]
        public ActionResult<Models.Employee> Get([FromRoute]int id)
        {
            try
            {
                return _mapper.Map<Models.Employee>(_employeeProcess.GetById(id));
            }
            catch (Exception exception)
            {
                 _logger.LogError(exception.ToString());
                return StatusCode(500, Constants.Errors.GETEMPLOYEEBYIDERROR);
            }
        }

        /// <summary>Add a new Employee</summary>
        /// <param name="newEmployee"></param>
        /// <returns>Employee item</returns>
        [HttpPost]
        public ActionResult<Models.Employee> Post([FromBody] Models.Employee newEmployee)
        {
            try
            {
                return _mapper.Map<Models.Employee>(_employeeProcess.Add(_mapper.Map<RedArbor.Process.Models.Employee>(newEmployee)));
            }
            catch(Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, Constants.Errors.ADDEMPLOYEEERROR);
            }
        }

        /// <summary>Update Employee</summary>
        /// <param name="updatedEmployee"></param>
        /// <param name="id"></param>
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Models.Employee updatedEmployee, [FromRoute]int id)
        {
            try
            {
                _employeeProcess.Update(id,_mapper.Map<RedArbor.Process.Models.Employee>(updatedEmployee));
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, Constants.Errors.UPDATEEMPLOYEEERROR);
            }
        }

        /// <summary>Delete Employee </summary>
        /// <param name="id"></param>
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                _employeeProcess.Delete(id);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, Constants.Errors.DELETEEMPLOYEEERROR);
            }
        }
       
    }
  
}
