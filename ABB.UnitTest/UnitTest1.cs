using ABB.API.Controllers;
using ABB.Entity;
using ABB.Interfaces.Repositories;
using ABB.Interfaces.Services;
using ABB.Repository.ContextModel;
using ABB.Repository.Repository;
using ABB.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;

namespace ABB.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
    
        /// <summary>
        /// Get All Employees
        /// </summary>
        [TestMethod]
        public  void TestMethod1()
        {

            var serviceProvider = new ServiceCollection()
           .AddLogging()
           .BuildServiceProvider();
            DBContext dBContext = new DBContext();
            IEmployeeRepository employeeRepository = new EmployeeRepository(dBContext);
            IEmployeeService employeeService = new EmployeeService(employeeRepository);
            EmployeeController obj = new EmployeeController(employeeService);
            var result = obj.GetAllEmployees();
            var data = result.Result;

        }
        /// <summary>
        /// Add Employee
        /// </summary>
        [TestMethod]
 
        public  void TestMethod2()
        {
            EmployeeEntity entity = new EmployeeEntity()
            {
                FirstName = "Smith",
                MiddleName = "Kumar",
                LastName = "Saha",
                Mobile = "8999878899",
                Email = "sahasmith677@gmail.com"
            };
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            DBContext dBContext = new DBContext();
            IEmployeeRepository employeeRepository = new EmployeeRepository(dBContext);
            IEmployeeService employeeService = new EmployeeService(employeeRepository);
            EmployeeController obj = new EmployeeController(employeeService);
            var result =  obj.AddEmployee(entity);
            dBContext.SaveChanges();

        }
        /// <summary>
        /// Update Employee
        /// </summary>
        [TestMethod]
        public  void TestMethod3()
        {
            EmployeeEntity entity = new EmployeeEntity()
            {
                EmployeeId = 1,
                FirstName = "Smith",
                MiddleName = "Kumar",
                LastName = "Saha",
                Mobile = "8999878899",
                Email = "sahasmith677@gmail.com"
            };
            DBContext dBContext = new DBContext();
            IEmployeeRepository employeeRepository = new EmployeeRepository(dBContext);
            IEmployeeService employeeService = new EmployeeService(employeeRepository);
            EmployeeController obj = new EmployeeController(employeeService);
            var result =  obj.UpdateEmployee(entity);
            Assert.AreEqual(result, true);

        }
        /// <summary>
        /// Delete Employee
        /// </summary>
        [TestMethod]
        public  void TestMethod4()
        {
            var serviceProvider = new ServiceCollection()
      .AddLogging()
      .BuildServiceProvider();
            DBContext dBContext = new DBContext();
            IEmployeeRepository employeeRepository = new EmployeeRepository(dBContext);
            IEmployeeService employeeService = new EmployeeService(employeeRepository);
            EmployeeController obj = new EmployeeController(employeeService);
            var result =  obj.DeleteEmployee(1);
            Assert.AreEqual(result, true);

        }
    }
}
