using RedArbor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace RedArbor.Process
{
    public class EmployeeProcess : Interfaces.IEmployeeProcess
    {

        private readonly IEmployeeDAL _employeeDAL;
        private readonly IMapper _mapper;
        public EmployeeProcess(IEmployeeDAL employeeDAL) { }
        public EmployeeProcess(IMapper mapper, IEmployeeDAL employeeDAL)
        {

            _employeeDAL = employeeDAL;
            _mapper = mapper;

        }
        public IEnumerable<RedArbor.Process.Models.Employee> GetAll()
        {
            try
            {
                return _mapper.Map<List<RedArbor.Process.Models.Employee>>(_employeeDAL.GetAll().ToList());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
       public Process.Models.Employee GetById(int id)
        {
            try
            {
                return _mapper.Map<RedArbor.Process.Models.Employee>(_employeeDAL.GetByID(id));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public Process.Models.Employee Add(Process.Models.Employee employee)       
        {
            try
            {
                return _mapper.Map<Process.Models.Employee>(_employeeDAL.Add(_mapper.Map<DAL.Models.Employee>(employee)));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void Update(int id, Process.Models.Employee employee)
        {
            try
            {
               _employeeDAL.Update(id, _mapper.Map<DAL.Models.Employee>(employee));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void Delete(int id)
        {
            try
            {
                _employeeDAL.Delete(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
