using System.Collections.Generic;

namespace RedArbor.DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        IEnumerable<DAL.Models.Employee> GetAll();
        DAL.Models.Employee GetByID(int id);
        DAL.Models.Employee Add(DAL.Models.Employee employee);
        void Update(int id,DAL.Models.Employee employee);
        void Delete(int id);
    }
}
