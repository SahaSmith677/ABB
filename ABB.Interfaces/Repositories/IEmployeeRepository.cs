using ABB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IQueryable<EmployeeEntity>> GetAllEmployee();
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<EmployeeEntity> Add(EmployeeEntity entity);
        Task<bool> Update(EmployeeEntity entity);
        Task<bool> Delete(int id);

    }
}
