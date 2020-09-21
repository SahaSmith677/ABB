using ABB.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeEntity>> GetAllEmployee();
        public Task<EmployeeEntity> GetEmployeeById(int id);
        public Task<EmployeeEntity> Add(EmployeeEntity entity);
        public Task<bool> Update(EmployeeEntity entity);
        public Task<bool> Delete(int id);

    }
}
