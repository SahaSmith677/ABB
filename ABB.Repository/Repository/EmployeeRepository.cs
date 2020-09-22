using ABB.Entity;
using ABB.Interfaces.Repositories;
using ABB.Repository.ContextModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ABB.Repository.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DBContext _context = null;
        public EmployeeRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntity> Add(EmployeeEntity entity)
        {
            try
            {
                Employee employee = new Employee()
                {
                    FirstName=entity.FirstName,
                    LastName=entity.LastName,
                    MiddleName=entity.MiddleName,
                    Mobile=entity.Mobile,
                    Email=entity.Email,
                    CreatedBy="sys",
                    CreatedDate=DateTime.Now,
                    IsActive=true
                    
                };
                _context.Employee.Add(employee);

               var result=  _context.SaveChanges();

                if (result == 1)
                    return entity;
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var employee = _context.Employee.Where(x => x.EmployeeId == id).FirstOrDefault();

                if (employee != null)
                {
                    employee.IsActive = false;
                    await _context.SaveChangesAsync();
                }
    
               return true;
            }
            catch(Exception ex)
            {

                return false;
            }
           
        }

        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return (from emp in _context.Employee
                    where emp.EmployeeId == id && emp.IsActive == true
                    select new EmployeeEntity
                    {
                        EmployeeId = emp.EmployeeId,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        MiddleName = emp.MiddleName,
                        Mobile = emp.Mobile,
                        Email = emp.Email

                    }).FirstOrDefault();
        }

        public async Task<bool> Update(EmployeeEntity entity)
        {
            try
            {
                var employee = _context.Employee.Where(x => x.EmployeeId == entity.EmployeeId).FirstOrDefault();

                if (employee != null)
                {
                    employee.FirstName = entity.FirstName;
                    employee.MiddleName = entity.MiddleName;
                    employee.LastName = entity.LastName;
                    employee.Email = entity.Email;
                    employee.Mobile = entity.Mobile;
                    employee.ModifiedBy = "sys";
                    employee.ModifiedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {

                return false;
            }
        }

       public async Task<IQueryable<EmployeeEntity>> GetAllEmployee()
        {
            IQueryable<EmployeeEntity> employees=(from emp in _context.Employee
                        where emp.IsActive == true
                        select new EmployeeEntity
                        {
                            EmployeeId=emp.EmployeeId,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            MiddleName = emp.MiddleName,
                            Mobile = emp.Mobile,
                            Email = emp.Email

                        }).AsQueryable();
            return employees;
            
        }
    }
}
