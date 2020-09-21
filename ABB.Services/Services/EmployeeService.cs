using ABB.Entity;
using ABB.Interfaces.Repositories;
using ABB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Services.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _repo = null;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task<EmployeeEntity> Add(EmployeeEntity entity)
        {
            return _repo.Add(entity);
        }

        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            IQueryable<EmployeeEntity> employees = await _repo.GetAllEmployee();

            return employees.ToList();
        }

        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return await _repo.GetEmployeeById(id);
        }

        public async Task<bool> Update(EmployeeEntity entity)
        {
            return await _repo.Update(entity);
        }
    }
}
