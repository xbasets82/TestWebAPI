using System.Collections.Generic;

namespace RedArbor.Process.Interfaces
{
   public interface IEmployeeProcess
    {
        IEnumerable<RedArbor.Process.Models.Employee> GetAll();
        RedArbor.Process.Models.Employee GetById(int id);
        RedArbor.Process.Models.Employee Add(RedArbor.Process.Models.Employee employee);
        void Update(int id, RedArbor.Process.Models.Employee employee);
        void Delete(int id);
    }
}
