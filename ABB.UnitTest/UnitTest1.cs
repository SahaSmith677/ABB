using ABB.API.Controllers;
using ABB.Entity;
using ABB.Interfaces.Repositories;
using ABB.Interfaces.Services;
using ABB.Repository.ContextModel;
using ABB.Repository.Repository;
using ABB.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ABB.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
    
        /// <summary>
        /// Add  Employee
        /// </summary>
        [TestMethod]
        public  void TestMethod1()
        {
            EmployeeEntity entity = new EmployeeEntity()
            {
                FirstName = "Smith",
                MiddleName = "Kumar",
                LastName = "Saha",
                Mobile = "8999878899",
                Email = "sahasmith677@gmail.com"
            };

            var mockSet = new Mock<DbSet<Employee>>();
            var mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.Employee).Returns(mockSet.Object);


            var mockRepo = new Mock<EmployeeRepository>(mockContext.Object);
          

            var mockService = new Mock<EmployeeService>(mockRepo.Object);

            EmployeeController obj = new EmployeeController(mockService.Object);
            obj.AddEmployee(entity);

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(),Times.Once());

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
                LastName = "Das",
                Mobile = "8999878899",
                Email = "sahasmith677@gmail.com"
            };
            var mockSet = new Mock<DbSet<Employee>>();
            var mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.Employee).Returns(mockSet.Object);


            var mockRepo = new Mock<EmployeeRepository>(mockContext.Object);


            var mockService = new Mock<EmployeeService>(mockRepo.Object);

            EmployeeController obj = new EmployeeController(mockService.Object);
            obj.UpdateEmployee(entity);

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
        /// <summary>
        /// Delete Employee
        /// </summary>
        [TestMethod]
        public  void TestMethod4()
        {
            var mockSet = new Mock<DbSet<Employee>>();
            var mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.Employee).Returns(mockSet.Object);


            var mockRepo = new Mock<EmployeeRepository>(mockContext.Object);


            var mockService = new Mock<EmployeeService>(mockRepo.Object);

            EmployeeController obj = new EmployeeController(mockService.Object);
            obj.DeleteEmployee(1);

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
